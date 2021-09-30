using JimiTools.Helper;
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
                try
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

                            if (currentRow == null)
                            {
                                continue;
                            }

                            var newRow = inputTable.NewRow();
                            newRow[0] = i;
                            for (int j = 0; j < lastCellNum; j++)
                            {
                                newRow[j + 1] = currentRow.GetCell(j).GetCellValue(" 0:00:00");
                            }
                            inputTable.Rows.Add(newRow);
                        }

                        syncContext.Post(d =>
                        {
                            lblInputCount.Text = "数据预览\r\n\r\n行数 " + (sheet.LastRowNum + 1).ToString() + Environment.NewLine + "含表头";

                            dgvSource.DataSource = inputTable;

                        }, null);
                    }
                }
                catch (Exception ex)
                {
                    syncContext.Post(d =>
                    {
                        MessageBox.Show(d.ToString(), "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoggerHelper.Error(d.ToString());

                    }, ex.Message+Environment.NewLine+ex.StackTrace);
                }


            });
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
            openFileDialog.Filter = "Excel数据表|*.xlsx";
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
                MessageBox.Show($"选择的表无任何数据，无法执行此操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Dictionary<string, Tuple<int,string>> filerParams = new Dictionary<string, Tuple<int, string>>();

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
                            MessageBox.Show($"筛选列名：[{arr[0]}] 不存在于表中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        filerParams[arr[0]] = new Tuple<int, string>(item.Contains("!=")?0:1, arr[1]);
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
                MessageBox.Show($"拆分列名：[txtSplitColumn.Text] 不存在于表中", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



            if (!templateList.Any())
            {
                MessageBox.Show($"模板配置不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var selectTemplate = templateList.FirstOrDefault(r => r.TemplateName == cmbTemplateList.SelectedValue.ToString()).Columns.OrderBy(r => r.Index).ToList();


            if (!selectTemplate.Any())
            {
                MessageBox.Show($"模板配置不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var columnNameValidate = new List<string>();
            foreach (var item in selectTemplate)
            {
                if (!string.IsNullOrWhiteSpace(item.ReferenceColumn) && !inputTable.Columns.Contains(item.ReferenceColumn))
                {
                    columnNameValidate.Add(item.ReferenceColumn);
                }
            }

            if (columnNameValidate.Any())
            {
                columnNameValidate.Insert(0,"选择的数据表格：\r\n" + txtSource.Text + "\r\n不包含列名：\r\n");

                MessageBox.Show(string.Join(Environment.NewLine, columnNameValidate), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #endregion

            var filterRows = new Dictionary<string, List<DataRow>>();
            
            foreach (DataRow row in inputTable.Rows)
            {
                var matchCount = filerParams.Count;
                foreach (var p in filerParams)
                {
                    if (p.Value.Item1==0)
                    {
                        if ((row[p.Key] + "") != p.Value.Item2)
                        {
                            matchCount--;
                        }
                    }
                    else
                    {
                        if ((row[p.Key] + "") == p.Value.Item2)
                        {
                            matchCount--;
                        }
                    }
                    
                }

                if (matchCount<1)
                {
                    var splitColValue = row[txtSplitColumn.Text] + "";
                    if (!filterRows.ContainsKey(splitColValue))
                    {
                        filterRows[splitColValue] = new List<DataRow>();

                    }

                    filterRows[splitColValue].Add(row);
                }
            }


            foreach (var item in filterRows)
            {
                CreateExcelTemplate(selectTemplate.OrderBy(r => r.Index).ToList(), item.Value, item.Key+DateTime.Now.ToString("MM-dd"));
            }


            MessageBox.Show($"生成模板数据成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void CreateExcelTemplate(IList<ColumnsItem> columnsItems,List<DataRow> rows,string excelName)
        {
            NPOI.XSSF.UserModel.XSSFWorkbook workbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
            var sheet = workbook.CreateSheet("sheet1");
            var headerRow = sheet.CreateRow(0);

            var cellFont = workbook.CreateFont();
            cellFont.FontName = "SimSun";
            cellFont.FontHeightInPoints = 9;

            var cellStyle = workbook.CreateCellStyle();
            cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.SetFont(cellFont);

            var dateTimeCellStyle= workbook.CreateCellStyle();
            var dateTimeFormat = workbook.CreateDataFormat();
            dateTimeCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            dateTimeCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            dateTimeCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            dateTimeCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            dateTimeCellStyle.SetFont(cellFont);
            dateTimeCellStyle.DataFormat = dateTimeFormat.GetFormat("yyyy/M/d");

            for (int i = 0; i < columnsItems.Count; i++)
            {
                headerRow.CreateCell(i, cellStyle).SetCellValue(columnsItems[i].Name);
            }

            for (int i = 0; i < rows.Count; i++)
            {
                var dataRow = rows[i];
                var newRow = sheet.CreateRow(i + 1);

                for (int j = 0; j < columnsItems.Count; j++)
                {
                    var columnInfo = columnsItems[j];
                    string cellValue = string.Empty;

                    if (!string.IsNullOrWhiteSpace(columnInfo.ReferenceColumn))
                    {
                        cellValue = dataRow[columnInfo.ReferenceColumn] + "";
                    }

                    if (columnInfo.ValueType == "Numeric" && cellValue.IsNumeric())
                    {
                        newRow.CreateCell(j, cellStyle).SetCellValue(cellValue.ToNumeric());
                    }
                    else if (columnInfo.ValueType == "DateTime")
                    {
                        var newDateCell = newRow.CreateCell(j, dateTimeCellStyle);
                        if (!string.IsNullOrWhiteSpace(cellValue))
                        {
                            newDateCell.SetCellValue(cellValue.ToDateTime());
                        }
                    }
                    else
                    {
                        newRow.CreateCell(j, cellStyle).SetCellValue(cellValue);
                    }  

                }
            }


            if (!Directory.Exists(txtSaveFolder.Text))
            {
                Directory.CreateDirectory(txtSaveFolder.Text);
            }

            var saveFile = Path.Combine(txtSaveFolder.Text, excelName + ".xlsx");

            workbook.Write(new FileStream(saveFile, FileMode.Create));

        }

        private void cmbTemplateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitOutputGridData();
        }
    }
}
