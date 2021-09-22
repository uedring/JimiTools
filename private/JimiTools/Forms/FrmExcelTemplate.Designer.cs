namespace JimiTools.Forms
{
    partial class FrmExcelTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExcelTemplate));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.dgvSource = new System.Windows.Forms.DataGridView();
            this.dgvOutput = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.txtSplitColumn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInputCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnViewOutput = new System.Windows.Forms.Button();
            this.txtSaveFolder = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTemplateList = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据表格";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(122, 48);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(509, 20);
            this.txtSource.TabIndex = 1;
            this.txtSource.TextChanged += new System.EventHandler(this.txtSource_TextChanged);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(637, 46);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "选择表格";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // dgvSource
            // 
            this.dgvSource.AllowUserToAddRows = false;
            this.dgvSource.AllowUserToDeleteRows = false;
            this.dgvSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSource.Location = new System.Drawing.Point(122, 180);
            this.dgvSource.Name = "dgvSource";
            this.dgvSource.ReadOnly = true;
            this.dgvSource.Size = new System.Drawing.Size(509, 151);
            this.dgvSource.TabIndex = 3;
            // 
            // dgvOutput
            // 
            this.dgvOutput.AllowUserToAddRows = false;
            this.dgvOutput.AllowUserToDeleteRows = false;
            this.dgvOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutput.Location = new System.Drawing.Point(122, 388);
            this.dgvOutput.Name = "dgvOutput";
            this.dgvOutput.ReadOnly = true;
            this.dgvOutput.Size = new System.Drawing.Size(509, 161);
            this.dgvOutput.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "筛选数据";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(122, 81);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(189, 20);
            this.txtFilter.TabIndex = 6;
            this.txtFilter.Text = "送货状态!=已送达";
            // 
            // txtSplitColumn
            // 
            this.txtSplitColumn.Location = new System.Drawing.Point(442, 81);
            this.txtSplitColumn.Name = "txtSplitColumn";
            this.txtSplitColumn.Size = new System.Drawing.Size(189, 20);
            this.txtSplitColumn.TabIndex = 8;
            this.txtSplitColumn.Text = "承运商";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "拆分列名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "模板预览";
            // 
            // lblInputCount
            // 
            this.lblInputCount.Location = new System.Drawing.Point(52, 180);
            this.lblInputCount.Name = "lblInputCount";
            this.lblInputCount.Size = new System.Drawing.Size(55, 69);
            this.lblInputCount.TabIndex = 10;
            this.lblInputCount.Text = "数据预览";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 354);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "保存位置";
            // 
            // btnViewOutput
            // 
            this.btnViewOutput.Location = new System.Drawing.Point(637, 349);
            this.btnViewOutput.Name = "btnViewOutput";
            this.btnViewOutput.Size = new System.Drawing.Size(75, 23);
            this.btnViewOutput.TabIndex = 13;
            this.btnViewOutput.Text = "查看输出";
            this.btnViewOutput.UseVisualStyleBackColor = true;
            this.btnViewOutput.Click += new System.EventHandler(this.btnViewOutput_Click);
            // 
            // txtSaveFolder
            // 
            this.txtSaveFolder.Location = new System.Drawing.Point(122, 350);
            this.txtSaveFolder.Name = "txtSaveFolder";
            this.txtSaveFolder.Size = new System.Drawing.Size(509, 20);
            this.txtSaveFolder.TabIndex = 12;
            // 
            // btnCreate
            // 
            this.btnCreate.AutoSize = true;
            this.btnCreate.BackColor = System.Drawing.Color.GreenYellow;
            this.btnCreate.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreate.Location = new System.Drawing.Point(122, 144);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(509, 30);
            this.btnCreate.TabIndex = 14;
            this.btnCreate.Text = "生成模板";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "选择模板";
            // 
            // cmbTemplateList
            // 
            this.cmbTemplateList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemplateList.FormattingEnabled = true;
            this.cmbTemplateList.Location = new System.Drawing.Point(122, 117);
            this.cmbTemplateList.Name = "cmbTemplateList";
            this.cmbTemplateList.Size = new System.Drawing.Size(189, 21);
            this.cmbTemplateList.TabIndex = 16;
            this.cmbTemplateList.SelectedIndexChanged += new System.EventHandler(this.cmbTemplateList_SelectedIndexChanged);
            // 
            // FrmExcelTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 558);
            this.Controls.Add(this.cmbTemplateList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnViewOutput);
            this.Controls.Add(this.txtSaveFolder);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblInputCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSplitColumn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvOutput);
            this.Controls.Add(this.dgvSource);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmExcelTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "表格模板生成";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.DataGridView dgvSource;
        private System.Windows.Forms.DataGridView dgvOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.TextBox txtSplitColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInputCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnViewOutput;
        private System.Windows.Forms.TextBox txtSaveFolder;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbTemplateList;
    }
}