using ICSharpCode.SharpZipLib.Zip;
using JimiTools.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JimiTools.Forms
{
    public partial class FrmZipFile : Form
    {
        private readonly object latch = new object();
        SynchronizationContext syncContext = null;
        List<string> filterFiles = new List<string>();
        Dictionary<string, bool> isZipped = new Dictionary<string, bool>();

        public FrmZipFile()
        {
            InitializeComponent();

            syncContext = SynchronizationContext.Current;

            txtSouceFolder.Text = Properties.Settings.Default.SourceFolder;
        }

        private void txtSouceFolder_TextChanged(object sender, EventArgs e)
        {
            txtSavePath.Text = Path.Combine(txtSouceFolder.Text, "压缩完成");

            LoadingFiles(txtSouceFolder.Text);
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            //folderBrowserDialog.RootFolder = Environment.SpecialFolder.UserProfile;
            folderBrowserDialog.SelectedPath = txtSouceFolder.Text;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtSouceFolder.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void LoadingFiles(string folder)
        {
            ResetValues();

            if (!Directory.Exists(folder))
            {
                return;
            }

            Properties.Settings.Default.SourceFolder = folder;
            Properties.Settings.Default.Save();

            Task.Run(() =>
            {
                lock (latch)
                {
                    var files = Directory.GetFiles(folder, txtExtension.Text);
                    if (files != null && files.Any())
                    {
                        this.filterFiles = files.ToList();
                        var content = string.Join(Environment.NewLine, files.Select(r => Path.GetFileName(r)));

                        syncContext.Post(o =>
                        {
                            var data = (string[])o;
                            txtSourceFiles.Text = data[0].ToString();
                            lblFiles.Text = "文件列表     " + data[1].ToString();
                        },
                        new string[] { content, files.Length.ToString() });

                    }
                }
            });

        }

        private void ResetValues()
        {
            lblFiles.Text = "文件列表";
            txtSourceFiles.Clear();
            this.filterFiles.Clear();
        }


        private void btnZip_Click(object sender, EventArgs e)
        {
            if (!this.filterFiles.Any())
            {
                MessageBox.Show("无可压缩的文件，请选择正确的目录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Dictionary<string, List<string>> groupFiles = new Dictionary<string, List<string>>();

            foreach (var file in this.filterFiles)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var groupKey = fileName.Split(txtSeparator.Text.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).First();

                if (!groupFiles.ContainsKey(groupKey))
                {
                    groupFiles[groupKey] = new List<string>();
                }

                groupFiles[groupKey].Add(file);
            }

            DoZip(groupFiles, txtSavePath.Text);

        }

        private void DoZip(Dictionary<string, List<string>> groupFiles, string outputFolder)
        {
            btnZip.Enabled = false;
            this.Enabled = false;
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            txtOutputLog.Clear();

            Task.Run(() =>
            {

                int idx = 0;
                foreach (var item in groupFiles)
                {
                    var zipFileName = item.Key + ".zip";
                    var zipFilePath = Path.Combine(outputFolder, zipFileName);
                    CreateZipFile(item.Value, zipFilePath);

                    syncContext.Post(d => {
                        txtOutputLog.Text += d.ToString();
                        txtOutputLog.SelectionStart = txtOutputLog.Text.Length;
                        txtOutputLog.ScrollToCaret();
                    }, $"{++idx}\t 压缩文件：{zipFileName} 创建成功{Environment.NewLine}");
                }


                isZipped[outputFolder] = true;

                syncContext.Post(d => {
                    btnZip.Enabled = true;
                    this.Enabled = true;

                    MessageBox.Show($"压缩完成，共生成压缩文件： {groupFiles.Count} 个", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }, null);

            });
        }

        private static void CreateZipFile(List<string> files, string zipFilePath)
        {

            try
            {
                using (ZipOutputStream s = new ZipOutputStream(File.Create(zipFilePath)))
                {

                    s.SetLevel(9); // 压缩级别 0-9
                                   //s.Password = "123"; //Zip压缩文件密码
                    byte[] buffer = new byte[4096]; //缓冲区大小
                    foreach (string file in files)
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);
                        using (FileStream fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }
                    s.Finish();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("压缩文件失败！" + Environment.NewLine + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenOutput_Click(object sender, EventArgs e)
        {
            if (isZipped.ContainsKey(txtSavePath.Text) && isZipped[txtSavePath.Text])
            {
                System.Diagnostics.Process.Start(txtSavePath.Text);
            }
            else
            {
                MessageBox.Show($"请先执行压缩操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void FrmZipFile_SizeChanged(object sender, EventArgs e)
        {

        }

        private void txtExtension_TextChanged(object sender, EventArgs e)
        {
            LoadingFiles(txtSouceFolder.Text);
        }
    }
}
