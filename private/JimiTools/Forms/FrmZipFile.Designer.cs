namespace JimiTools.Forms
{
    partial class FrmZipFile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmZipFile));
            this.txtSouceFolder = new System.Windows.Forms.TextBox();
            this.btnZip = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSeparator = new System.Windows.Forms.TextBox();
            this.txtSourceFiles = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtOutputLog = new System.Windows.Forms.TextBox();
            this.lblFiles = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOpenOutput = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSouceFolder
            // 
            this.txtSouceFolder.Location = new System.Drawing.Point(110, 26);
            this.txtSouceFolder.Name = "txtSouceFolder";
            this.txtSouceFolder.Size = new System.Drawing.Size(617, 20);
            this.txtSouceFolder.TabIndex = 0;
            this.txtSouceFolder.TextChanged += new System.EventHandler(this.txtSouceFolder_TextChanged);
            // 
            // btnZip
            // 
            this.btnZip.BackColor = System.Drawing.SystemColors.Control;
            this.btnZip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnZip.Image = global::JimiTools.Properties.Resources._047_books;
            this.btnZip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZip.Location = new System.Drawing.Point(110, 132);
            this.btnZip.Name = "btnZip";
            this.btnZip.Size = new System.Drawing.Size(617, 23);
            this.btnZip.TabIndex = 1;
            this.btnZip.Text = "批量压缩";
            this.btnZip.UseVisualStyleBackColor = false;
            this.btnZip.Click += new System.EventHandler(this.btnZip_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "文件目录";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "扩展名";
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(110, 59);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(87, 20);
            this.txtExtension.TabIndex = 3;
            this.txtExtension.Text = "*.jpg";
            this.txtExtension.TextChanged += new System.EventHandler(this.txtExtension_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "保存路径";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(110, 93);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(617, 20);
            this.txtSavePath.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "文件名分隔符";
            // 
            // txtSeparator
            // 
            this.txtSeparator.Location = new System.Drawing.Point(343, 59);
            this.txtSeparator.Name = "txtSeparator";
            this.txtSeparator.Size = new System.Drawing.Size(87, 20);
            this.txtSeparator.TabIndex = 7;
            this.txtSeparator.Text = "-";
            // 
            // txtSourceFiles
            // 
            this.txtSourceFiles.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtSourceFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSourceFiles.Location = new System.Drawing.Point(45, 0);
            this.txtSourceFiles.Multiline = true;
            this.txtSourceFiles.Name = "txtSourceFiles";
            this.txtSourceFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSourceFiles.Size = new System.Drawing.Size(340, 357);
            this.txtSourceFiles.TabIndex = 9;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(726, 25);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFolder.TabIndex = 10;
            this.btnSelectFolder.Text = "选择目录";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // txtOutputLog
            // 
            this.txtOutputLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtOutputLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOutputLog.Location = new System.Drawing.Point(450, 0);
            this.txtOutputLog.Multiline = true;
            this.txtOutputLog.Name = "txtOutputLog";
            this.txtOutputLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutputLog.Size = new System.Drawing.Size(376, 357);
            this.txtOutputLog.TabIndex = 11;
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point(41, 8);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(55, 13);
            this.lblFiles.TabIndex = 12;
            this.lblFiles.Text = "文件列表";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(447, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "压缩日志";
            // 
            // btnOpenOutput
            // 
            this.btnOpenOutput.Location = new System.Drawing.Point(726, 92);
            this.btnOpenOutput.Name = "btnOpenOutput";
            this.btnOpenOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOpenOutput.TabIndex = 14;
            this.btnOpenOutput.Text = "查看输出";
            this.btnOpenOutput.UseVisualStyleBackColor = true;
            this.btnOpenOutput.Click += new System.EventHandler(this.btnOpenOutput_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtOutputLog);
            this.panel1.Controls.Add(this.txtSourceFiles);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 203);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(45, 0, 20, 20);
            this.panel1.Size = new System.Drawing.Size(846, 377);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblFiles);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 174);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(846, 29);
            this.panel2.TabIndex = 16;
            // 
            // FrmZipFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 580);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOpenOutput);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSeparator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnZip);
            this.Controls.Add(this.txtSouceFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmZipFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件批量压缩";
            this.SizeChanged += new System.EventHandler(this.FrmZipFile_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSouceFolder;
        private System.Windows.Forms.Button btnZip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSeparator;
        private System.Windows.Forms.TextBox txtSourceFiles;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox txtOutputLog;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnOpenOutput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}