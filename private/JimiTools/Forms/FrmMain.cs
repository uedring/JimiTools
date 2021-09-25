using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JimiTools.Forms;

namespace JimiTools
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnZipFile_Click(object sender, EventArgs e)
        {
            var frm = new FrmZipFile();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            var frm = new FrmDeliveryTime();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void linkAuthor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new FrmMessage();
            frm.ShowDialog();
        }

        private void btnCreateTemplate_Click(object sender, EventArgs e)
        {
            var frm = new FrmExcelTemplate();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
