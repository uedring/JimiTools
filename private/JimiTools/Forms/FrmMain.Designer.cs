namespace JimiTools
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.linkAuthor = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateTemplate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnTime = new System.Windows.Forms.Button();
            this.btnZipFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkAuthor
            // 
            this.linkAuthor.AutoSize = true;
            this.linkAuthor.Location = new System.Drawing.Point(421, 466);
            this.linkAuthor.Name = "linkAuthor";
            this.linkAuthor.Size = new System.Drawing.Size(67, 13);
            this.linkAuthor.TabIndex = 5;
            this.linkAuthor.TabStop = true;
            this.linkAuthor.Text = "联系开发者";
            this.linkAuthor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAuthor_LinkClicked);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(65, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "本工具完全免费，绿色无毒，请放心使用";
            // 
            // btnCreateTemplate
            // 
            this.btnCreateTemplate.FlatAppearance.BorderSize = 0;
            this.btnCreateTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateTemplate.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreateTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCreateTemplate.Image = global::JimiTools.Properties.Resources._005_exam;
            this.btnCreateTemplate.Location = new System.Drawing.Point(329, 74);
            this.btnCreateTemplate.Name = "btnCreateTemplate";
            this.btnCreateTemplate.Size = new System.Drawing.Size(159, 37);
            this.btnCreateTemplate.TabIndex = 7;
            this.btnCreateTemplate.Text = "表格模板生成";
            this.btnCreateTemplate.UseVisualStyleBackColor = true;
            this.btnCreateTemplate.Click += new System.EventHandler(this.btnCreateTemplate_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.Image = global::JimiTools.Properties.Resources.exit;
            this.btnExit.Location = new System.Drawing.Point(188, 382);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(159, 37);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退  出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTime
            // 
            this.btnTime.FlatAppearance.BorderSize = 0;
            this.btnTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTime.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTime.Image = global::JimiTools.Properties.Resources._002_alarm_clock;
            this.btnTime.Location = new System.Drawing.Point(188, 163);
            this.btnTime.Name = "btnTime";
            this.btnTime.Size = new System.Drawing.Size(159, 37);
            this.btnTime.TabIndex = 2;
            this.btnTime.Text = "时效审核查询";
            this.btnTime.UseVisualStyleBackColor = true;
            this.btnTime.Click += new System.EventHandler(this.btnTime_Click);
            // 
            // btnZipFile
            // 
            this.btnZipFile.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnZipFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnZipFile.Image = global::JimiTools.Properties.Resources._047_books;
            this.btnZipFile.Location = new System.Drawing.Point(68, 74);
            this.btnZipFile.Name = "btnZipFile";
            this.btnZipFile.Size = new System.Drawing.Size(159, 37);
            this.btnZipFile.TabIndex = 0;
            this.btnZipFile.Text = "批量压缩文件";
            this.btnZipFile.UseVisualStyleBackColor = true;
            this.btnZipFile.Click += new System.EventHandler(this.btnZipFile_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 499);
            this.Controls.Add(this.btnCreateTemplate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkAuthor);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnTime);
            this.Controls.Add(this.btnZipFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "吉米办公助手";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnZipFile;
        private System.Windows.Forms.Button btnTime;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.LinkLabel linkAuthor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateTemplate;
    }
}

