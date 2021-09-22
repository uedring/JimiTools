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
        JArray templateList;
        private readonly object latch = new object();
        SynchronizationContext syncContext = null;

        public FrmExcelTemplate()
        {
            InitializeComponent();

            syncContext = SynchronizationContext.Current;

            txtSource.Text = Properties.Settings.Default.ExcelTemplateSource;

            Init();
        }

        void Init()
        {
            var templateJson = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Data", "ExcelTemplate.json"));
            templateList = Newtonsoft.Json.Linq.JArray.Parse(templateJson);

            var templateNames= templateList.Select(r => r["TemplateName"].ToString()).ToList();

            cmbTemplateList.DataSource = templateNames;

        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            txtSaveFolder.Text = Path.Combine(txtSource.Text, "生成成功");
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

        }
    }
}
