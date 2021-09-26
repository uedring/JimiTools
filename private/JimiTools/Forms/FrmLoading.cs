using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JimiTools.Forms
{
    public partial class FrmLoading : Form
    {
        SynchronizationContext syncContext = null;
        public FrmLoading()
        {
            InitializeComponent();

            syncContext = SynchronizationContext.Current;
        }

        public void StartProcess()
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 1000;
            progressBar1.Step = 10;
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.MarqueeAnimationSpeed = 100;

            Task.Run(() => {
                while (true)
                {
                    Task.Delay(1000);

                    syncContext.Post(d => {
                        progressBar1.PerformStep();
                    }, null);

                }
            });
        }
    }
}
