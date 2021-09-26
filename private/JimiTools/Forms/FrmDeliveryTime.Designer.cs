namespace JimiTools.Forms
{
    partial class FrmDeliveryTime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeliveryTime));
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSendDate = new System.Windows.Forms.TextBox();
            this.txtToCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtToAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRevieveDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSendStatus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOutputColumnStart = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInputExcel = new System.Windows.Forms.TextBox();
            this.txtSelectFile = new System.Windows.Forms.Button();
            this.btnAudit = new System.Windows.Forms.Button();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnViewOutput = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvInputExcel = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "查询地址";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(84, 32);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(539, 66);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Text = "四川省成都市高新区天府五街美年广场A座444";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(638, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(84, 123);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(539, 99);
            this.txtResult.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "查询结果";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtResult);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 330);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 241);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询时效";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "发货日期列名";
            // 
            // txtSendDate
            // 
            this.txtSendDate.Location = new System.Drawing.Point(129, 12);
            this.txtSendDate.Name = "txtSendDate";
            this.txtSendDate.Size = new System.Drawing.Size(100, 20);
            this.txtSendDate.TabIndex = 7;
            this.txtSendDate.Text = "发货日期";
            // 
            // txtToCity
            // 
            this.txtToCity.Location = new System.Drawing.Point(362, 12);
            this.txtToCity.Name = "txtToCity";
            this.txtToCity.Size = new System.Drawing.Size(100, 20);
            this.txtToCity.TabIndex = 9;
            this.txtToCity.Text = "目的城市";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "目的城市列名";
            // 
            // txtToAddress
            // 
            this.txtToAddress.Location = new System.Drawing.Point(590, 12);
            this.txtToAddress.Name = "txtToAddress";
            this.txtToAddress.Size = new System.Drawing.Size(100, 20);
            this.txtToAddress.TabIndex = 11;
            this.txtToAddress.Text = "送货地址";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(483, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "送货地址列名";
            // 
            // txtRevieveDate
            // 
            this.txtRevieveDate.Location = new System.Drawing.Point(129, 58);
            this.txtRevieveDate.Name = "txtRevieveDate";
            this.txtRevieveDate.Size = new System.Drawing.Size(100, 20);
            this.txtRevieveDate.TabIndex = 13;
            this.txtRevieveDate.Text = "按时效应到日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "应到日期列名";
            // 
            // txtSendStatus
            // 
            this.txtSendStatus.Location = new System.Drawing.Point(362, 58);
            this.txtSendStatus.Name = "txtSendStatus";
            this.txtSendStatus.Size = new System.Drawing.Size(100, 20);
            this.txtSendStatus.TabIndex = 15;
            this.txtSendStatus.Text = "送货状态";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(277, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "送货状态列名";
            // 
            // txtOutputColumnStart
            // 
            this.txtOutputColumnStart.Location = new System.Drawing.Point(590, 58);
            this.txtOutputColumnStart.Name = "txtOutputColumnStart";
            this.txtOutputColumnStart.Size = new System.Drawing.Size(100, 20);
            this.txtOutputColumnStart.TabIndex = 17;
            this.txtOutputColumnStart.Text = "BC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(483, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "审核结果输出列";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "选择审核表格";
            // 
            // txtInputExcel
            // 
            this.txtInputExcel.Location = new System.Drawing.Point(129, 107);
            this.txtInputExcel.Name = "txtInputExcel";
            this.txtInputExcel.Size = new System.Drawing.Size(480, 20);
            this.txtInputExcel.TabIndex = 19;
            this.txtInputExcel.TextChanged += new System.EventHandler(this.txtInputExcel_TextChanged);
            // 
            // txtSelectFile
            // 
            this.txtSelectFile.Location = new System.Drawing.Point(615, 104);
            this.txtSelectFile.Name = "txtSelectFile";
            this.txtSelectFile.Size = new System.Drawing.Size(75, 23);
            this.txtSelectFile.TabIndex = 20;
            this.txtSelectFile.Text = "选择文件";
            this.txtSelectFile.UseVisualStyleBackColor = true;
            this.txtSelectFile.Click += new System.EventHandler(this.txtSelectFile_Click);
            // 
            // btnAudit
            // 
            this.btnAudit.BackColor = System.Drawing.Color.LawnGreen;
            this.btnAudit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAudit.Location = new System.Drawing.Point(129, 283);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(561, 29);
            this.btnAudit.TabIndex = 21;
            this.btnAudit.Text = "表格订单时效审核";
            this.btnAudit.UseVisualStyleBackColor = false;
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(129, 243);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(480, 20);
            this.txtSavePath.TabIndex = 22;
            // 
            // btnViewOutput
            // 
            this.btnViewOutput.Location = new System.Drawing.Point(615, 242);
            this.btnViewOutput.Name = "btnViewOutput";
            this.btnViewOutput.Size = new System.Drawing.Size(75, 23);
            this.btnViewOutput.TabIndex = 23;
            this.btnViewOutput.Text = "查看结果";
            this.btnViewOutput.UseVisualStyleBackColor = true;
            this.btnViewOutput.Click += new System.EventHandler(this.btnViewOutput_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(44, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "结果保存位置";
            // 
            // dgvInputExcel
            // 
            this.dgvInputExcel.AllowUserToAddRows = false;
            this.dgvInputExcel.AllowUserToDeleteRows = false;
            this.dgvInputExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputExcel.Location = new System.Drawing.Point(129, 129);
            this.dgvInputExcel.Name = "dgvInputExcel";
            this.dgvInputExcel.ReadOnly = true;
            this.dgvInputExcel.Size = new System.Drawing.Size(561, 103);
            this.dgvInputExcel.TabIndex = 25;
            // 
            // FrmDeliveryTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 583);
            this.Controls.Add(this.dgvInputExcel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnViewOutput);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.btnAudit);
            this.Controls.Add(this.txtSelectFile);
            this.Controls.Add(this.txtInputExcel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtOutputColumnStart);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSendStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRevieveDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtToAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtToCity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSendDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDeliveryTime";
            this.Text = "时效审核查询";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSendDate;
        private System.Windows.Forms.TextBox txtToCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtToAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRevieveDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSendStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOutputColumnStart;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInputExcel;
        private System.Windows.Forms.Button txtSelectFile;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnViewOutput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvInputExcel;
    }
}