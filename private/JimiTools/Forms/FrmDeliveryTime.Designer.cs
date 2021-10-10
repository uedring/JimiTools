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
            this.btnViewDeliveryFile = new System.Windows.Forms.Button();
            this.rdoByCity = new System.Windows.Forms.RadioButton();
            this.rdoByDetails = new System.Windows.Forms.RadioButton();
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
            this.txtOrderNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInputExcel = new System.Windows.Forms.TextBox();
            this.txtSelectFile = new System.Windows.Forms.Button();
            this.btnAudit = new System.Windows.Forms.Button();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnViewOutput = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvInputExcel = new System.Windows.Forms.DataGridView();
            this.txtCarrier = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIsSellOrder = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIgnoreCarier = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputExcel)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "查询信息";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(117, 21);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(411, 66);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Text = "四川省成都市高新区天府五街美年广场A座444";
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddress_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Chartreuse;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(626, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 29);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(117, 103);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(611, 108);
            this.txtResult.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "查询结果";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btnViewDeliveryFile);
            this.groupBox1.Controls.Add(this.rdoByCity);
            this.groupBox1.Controls.Add(this.rdoByDetails);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtResult);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 354);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 222);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询时效";
            // 
            // btnViewDeliveryFile
            // 
            this.btnViewDeliveryFile.BackColor = System.Drawing.Color.SkyBlue;
            this.btnViewDeliveryFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDeliveryFile.Location = new System.Drawing.Point(626, 60);
            this.btnViewDeliveryFile.Name = "btnViewDeliveryFile";
            this.btnViewDeliveryFile.Size = new System.Drawing.Size(102, 29);
            this.btnViewDeliveryFile.TabIndex = 7;
            this.btnViewDeliveryFile.Text = "查看修改时效表";
            this.btnViewDeliveryFile.UseVisualStyleBackColor = false;
            this.btnViewDeliveryFile.Click += new System.EventHandler(this.btnViewDeliveryFile_Click);
            // 
            // rdoByCity
            // 
            this.rdoByCity.AutoSize = true;
            this.rdoByCity.Location = new System.Drawing.Point(535, 67);
            this.rdoByCity.Name = "rdoByCity";
            this.rdoByCity.Size = new System.Drawing.Size(85, 17);
            this.rdoByCity.TabIndex = 6;
            this.rdoByCity.Text = "按目的城市";
            this.rdoByCity.UseVisualStyleBackColor = true;
            // 
            // rdoByDetails
            // 
            this.rdoByDetails.AutoSize = true;
            this.rdoByDetails.Checked = true;
            this.rdoByDetails.Location = new System.Drawing.Point(535, 26);
            this.rdoByDetails.Name = "rdoByDetails";
            this.rdoByDetails.Size = new System.Drawing.Size(85, 17);
            this.rdoByDetails.TabIndex = 5;
            this.rdoByDetails.TabStop = true;
            this.rdoByDetails.Text = "按详细地址";
            this.rdoByDetails.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "发货日期列名";
            // 
            // txtSendDate
            // 
            this.txtSendDate.Location = new System.Drawing.Point(117, 16);
            this.txtSendDate.Name = "txtSendDate";
            this.txtSendDate.Size = new System.Drawing.Size(100, 20);
            this.txtSendDate.TabIndex = 7;
            this.txtSendDate.Text = "发货日期";
            // 
            // txtToCity
            // 
            this.txtToCity.Location = new System.Drawing.Point(350, 16);
            this.txtToCity.Name = "txtToCity";
            this.txtToCity.Size = new System.Drawing.Size(100, 20);
            this.txtToCity.TabIndex = 9;
            this.txtToCity.Text = "目的城市";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "目的城市列名";
            // 
            // txtToAddress
            // 
            this.txtToAddress.Location = new System.Drawing.Point(578, 16);
            this.txtToAddress.Name = "txtToAddress";
            this.txtToAddress.Size = new System.Drawing.Size(100, 20);
            this.txtToAddress.TabIndex = 11;
            this.txtToAddress.Text = "送货地址";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "送货地址列名";
            // 
            // txtRevieveDate
            // 
            this.txtRevieveDate.Location = new System.Drawing.Point(117, 41);
            this.txtRevieveDate.Name = "txtRevieveDate";
            this.txtRevieveDate.Size = new System.Drawing.Size(100, 20);
            this.txtRevieveDate.TabIndex = 13;
            this.txtRevieveDate.Text = "按时效应到日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "应到日期列名";
            // 
            // txtSendStatus
            // 
            this.txtSendStatus.Location = new System.Drawing.Point(350, 41);
            this.txtSendStatus.Name = "txtSendStatus";
            this.txtSendStatus.Size = new System.Drawing.Size(100, 20);
            this.txtSendStatus.TabIndex = 15;
            this.txtSendStatus.Text = "送货状态";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "送货状态列名";
            // 
            // txtOrderNum
            // 
            this.txtOrderNum.Location = new System.Drawing.Point(578, 41);
            this.txtOrderNum.Name = "txtOrderNum";
            this.txtOrderNum.Size = new System.Drawing.Size(100, 20);
            this.txtOrderNum.TabIndex = 17;
            this.txtOrderNum.Text = "订单编号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(471, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "订单编号列名";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "选择审核表格";
            // 
            // txtInputExcel
            // 
            this.txtInputExcel.Location = new System.Drawing.Point(129, 134);
            this.txtInputExcel.Name = "txtInputExcel";
            this.txtInputExcel.Size = new System.Drawing.Size(480, 20);
            this.txtInputExcel.TabIndex = 19;
            this.txtInputExcel.TextChanged += new System.EventHandler(this.txtInputExcel_TextChanged);
            // 
            // txtSelectFile
            // 
            this.txtSelectFile.Location = new System.Drawing.Point(615, 131);
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
            this.btnAudit.Location = new System.Drawing.Point(129, 267);
            this.btnAudit.Name = "btnAudit";
            this.btnAudit.Size = new System.Drawing.Size(561, 29);
            this.btnAudit.TabIndex = 21;
            this.btnAudit.Text = "审核表格订单";
            this.btnAudit.UseVisualStyleBackColor = false;
            this.btnAudit.Click += new System.EventHandler(this.btnAudit_Click);
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(129, 312);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(480, 20);
            this.txtSavePath.TabIndex = 22;
            // 
            // btnViewOutput
            // 
            this.btnViewOutput.Location = new System.Drawing.Point(615, 311);
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
            this.label10.Location = new System.Drawing.Point(44, 316);
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
            this.dgvInputExcel.Location = new System.Drawing.Point(129, 156);
            this.dgvInputExcel.Name = "dgvInputExcel";
            this.dgvInputExcel.ReadOnly = true;
            this.dgvInputExcel.Size = new System.Drawing.Size(561, 103);
            this.dgvInputExcel.TabIndex = 25;
            // 
            // txtCarrier
            // 
            this.txtCarrier.Location = new System.Drawing.Point(117, 67);
            this.txtCarrier.Name = "txtCarrier";
            this.txtCarrier.Size = new System.Drawing.Size(100, 20);
            this.txtCarrier.TabIndex = 27;
            this.txtCarrier.Text = "承运商";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "承运商列名";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtIsSellOrder);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtSendDate);
            this.groupBox2.Controls.Add(this.txtCarrier);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtToCity);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtToAddress);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtRevieveDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtSendStatus);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtOrderNum);
            this.groupBox2.Location = new System.Drawing.Point(12, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(748, 91);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "表格列名配置";
            // 
            // txtIsSellOrder
            // 
            this.txtIsSellOrder.Location = new System.Drawing.Point(350, 64);
            this.txtIsSellOrder.Name = "txtIsSellOrder";
            this.txtIsSellOrder.Size = new System.Drawing.Size(100, 20);
            this.txtIsSellOrder.TabIndex = 29;
            this.txtIsSellOrder.Text = "销售单/非销售单";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(253, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "是否销售单列名";
            // 
            // txtIgnoreCarier
            // 
            this.txtIgnoreCarier.Location = new System.Drawing.Point(129, 102);
            this.txtIgnoreCarier.Name = "txtIgnoreCarier";
            this.txtIgnoreCarier.Size = new System.Drawing.Size(227, 20);
            this.txtIgnoreCarier.TabIndex = 30;
            this.txtIgnoreCarier.Text = "顺丰快递，自提";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(44, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "不审核承运商";
            // 
            // FrmDeliveryTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 583);
            this.Controls.Add(this.txtIgnoreCarier);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvInputExcel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnViewOutput);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.btnAudit);
            this.Controls.Add(this.txtSelectFile);
            this.Controls.Add(this.txtInputExcel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDeliveryTime";
            this.Text = "订单审核 | 时效查询";
            this.Load += new System.EventHandler(this.FrmDeliveryTime_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputExcel)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.TextBox txtOrderNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInputExcel;
        private System.Windows.Forms.Button txtSelectFile;
        private System.Windows.Forms.Button btnAudit;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnViewOutput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvInputExcel;
        private System.Windows.Forms.RadioButton rdoByCity;
        private System.Windows.Forms.RadioButton rdoByDetails;
        private System.Windows.Forms.Button btnViewDeliveryFile;
        private System.Windows.Forms.TextBox txtCarrier;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtIgnoreCarier;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIsSellOrder;
        private System.Windows.Forms.Label label13;
    }
}