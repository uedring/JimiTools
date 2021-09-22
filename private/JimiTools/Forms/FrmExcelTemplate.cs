using JimiTools.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JimiTools.Forms
{
    public partial class FrmExcelTemplate : Form
    {
        DataTable inputTable = new DataTable();
        List<ExcelTemplate> templateList;
        private readonly object latch = new object();
        SynchronizationContext syncContext = null;


        public FrmExcelTemplate()
        {
            InitializeComponent();

            syncContext = SynchronizationContext.Current;

            txtSource.Text = Properties.Settings.Default.ExcelTemplateSource;

            var templateJson = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "ExcelTemplate.json"));
            templateList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExcelTemplate>>(templateJson);

            Init();
        }

        void Init()
        {
            //Dropdown list
            cmbTemplateList.DataSource = templateList;
            cmbTemplateList.DisplayMember = "TemplateName";
            cmbTemplateList.ValueMember = "TemplateName";

            //Output data grid view
            dgvOutput.ColumnHeadersVisible = true;
            dgvOutput.AutoGenerateColumns = false;

            var selectTemplate = templateList.FirstOrDefault(r => r.TemplateName == cmbTemplateList.SelectedValue.ToString()).Columns.OrderBy(r => r.Index).ToList();

            foreach (var item in selectTemplate)
            {
                dgvOutput.Columns.Add(new DataGridViewTextBoxColumn() { Name = Guid.NewGuid().ToString(), DataPropertyName = "SampleValue", HeaderText = item.Name, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            }

            InitOutputGridData();

        }

        void InitOutputGridData()
        {
            if (dgvOutput.Columns.Count > 0)
            {
                dgvOutput.Rows.Clear();
                var selectTemplate = templateList.FirstOrDefault(r => r.TemplateName == cmbTemplateList.SelectedValue.ToString()).Columns.OrderBy(r => r.Index).ToList();
                var rowIdx = dgvOutput.Rows.Add();
                var colIdx = 0;
                foreach (var item in selectTemplate)
                {
                    dgvOutput.Rows[rowIdx].Cells[colIdx++].Value = item.SampleValue;
                }
            }

        }


        void InitInputGridData()
        {
            Task.Run(() =>
            {
                lock (latch)
                {
                    NPOI.XSSF.UserModel.XSSFWorkbook workbook = new NPOI.XSSF.UserModel.XSSFWorkbook(new FileStream(txtSource.Text, FileMode.Open, FileAccess.Read));
                    var sheet = workbook.GetSheetAt(0);
                    var headerRow = sheet.GetRow(0);
                    var lastCellNum = headerRow.LastCellNum;

                    inputTable = new DataTable();
                    inputTable.Columns.Add(new DataColumn("行号"));

                    for (int i = 0; i < lastCellNum; i++)
                    {
                        inputTable.Columns.Add(new DataColumn(headerRow.GetCell(i).StringCellValue));
                    }

                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        var currentRow = sheet.GetRow(i);

                        var newRow = inputTable.NewRow();
                        newRow[0] = i;
                        for (int j = 0; j < lastCellNum; j++)
                        {
                            newRow[j + 1] = GetCellValue(currentRow.GetCell(j));
                        }
                        inputTable.Rows.Add(newRow);
                    }

                    syncContext.Post(d =>
                    {
                        lblInputCount.Text = "数据预览\r\n\r\n行数 " + (sheet.LastRowNum + 1).ToString() + Environment.NewLine + "含表头";
                        dgvSource.Columns.Clear();
                        dgvSource.Rows.Clear();

                        dgvSource.DataSource = inputTable;

                    }, null);
                }

            });
        }

        object GetCellValue(NPOI.SS.UserModel.ICell cell)
        {
            if (cell.CellType == NPOI.SS.UserModel.CellType.Numeric)
            {
                return cell.NumericCellValue;
            }
            else if (cell.CellType == NPOI.SS.UserModel.CellType.Boolean)
            {
                return cell.BooleanCellValue.ToString();
            }
            else
            {
                return cell.StringCellValue.Replace(" 0:00:00", "");
            }
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            txtSaveFolder.Text = Path.Combine(Path.GetDirectoryName(txtSource.Text), "生成成功");

            if (File.Exists(txtSource.Text))
            {
                InitInputGridData();
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.FileName = txtSource.Text;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "*.xls|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtSource.Text = openFileDialog.FileName;

                Properties.Settings.Default.ExcelTemplateSource = txtSource.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void btnViewOutput_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtSaveFolder.Text))
            {
                System.Diagnostics.Process.Start(txtSaveFolder.Text);
            }
            else
            {
                MessageBox.Show($"请先执行生成操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            #region 验参数

            if (inputTable.Rows.Count < 1)
            {
                MessageBox.Show($"选择的表无任何数据，无法执行此操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Dictionary<string, string> filerParams = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                var filter = txtFilter.Text.Trim().Split(",，".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in filter)
                {
                    if (item.Contains("!=") || item.Contains("="))
                    {
                        var arr = item.Split("!=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                        if (!inputTable.Columns.Contains(arr[0]))
                        {
                            MessageBox.Show($"筛选列名：[{arr[0]}] 不存在于表中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        filerParams[arr[0]] = arr[1];
                    }
                    else
                    {
                        MessageBox.Show($"筛选参数输入有误！\r\n示例值如下（多个筛选用 , 分开）：\r\n送货状态!=已送达\r\n送货状态=已送达", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(txtSplitColumn.Text) || !inputTable.Columns.Contains(txtSplitColumn.Text.Trim()))
            {
                MessageBox.Show($"拆分列名：[txtSplitColumn.Text] 不存在于表中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



            if (!templateList.Any())
            {
                MessageBox.Show($"模板配置不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            var selectTemplate = templateList.FirstOrDefault(r => r.TemplateName == cmbTemplateList.SelectedValue.ToString()).Columns.OrderBy(r => r.Index).ToList();


            if (!selectTemplate.Any())
            {
                MessageBox.Show($"模板配置不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            #endregion


            CreateExcelTemplate(selectTemplate.OrderBy(r=>r.Index).ToList());

            MessageBox.Show($"生成模板数据成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void CreateExcelTemplate(IList<ColumnsItem> columnsItems)
        {
            NPOI.XSSF.UserModel.XSSFWorkbook workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
            var sheet = workbook.CreateSheet("sheet1");
            var headerRow = sheet.CreateRow(0);

            for (int i = 0; i < columnsItems.Count; i++)
            {
                headerRow.CreateCell(i).SetCellValue(columnsItems[i].Name);
            }

            for (int i = 0; i < inputTable.Rows.Count; i++)
            {
                var dataRow = inputTable.Rows[i];
                var newRow = sheet.CreateRow(i + 1);

                for (int j = 0; j < columnsItems.Count; j++)
                {
                    var columnInfo = columnsItems[j];
                    string cellValue = string.Empty;

                    if (!string.IsNullOrWhiteSpace(columnInfo.ReferenceColumn))
                    {
                        cellValue = dataRow[columnInfo.ReferenceColumn] + "";
                    }

                    newRow.CreateCell(j).SetCellValue(cellValue);
                }
            }


            if (!Directory.Exists(txtSaveFolder.Text))
            {
                Directory.CreateDirectory(txtSaveFolder.Text);
            }

            var saveFile = Path.Combine(txtSaveFolder.Text,DateTime.Now.ToString("MM-dd")+".xlsx");

            workbook.Write(new FileStream(saveFile, FileMode.Create));

        }

        private void cmbTemplateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitOutputGridData();
        }
    }
}
