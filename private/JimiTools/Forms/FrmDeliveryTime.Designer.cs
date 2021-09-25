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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "查询地址";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(114, 53);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(539, 66);
            this.txtAddress.TabIndex = 1;
            this.txtAddress.Text = "四川省成都市高新区天府五街美年广场A座444";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(659, 53);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(114, 144);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(539, 332);
            this.txtResult.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "查询结果";
            // 
            // FrmDeliveryTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 500);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDeliveryTime";
            this.Text = "派送时效查询";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label2;
    }
}