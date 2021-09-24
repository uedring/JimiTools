using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JimiTools.Forms
{
    public partial class FrmDeliveryTime : Form
    {
        static Dictionary<string, Tuple<string, int>> DeliveryTime = new Dictionary<string, Tuple<string, int>>();
        public FrmDeliveryTime()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BuildDeliveryTime();

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("请输入地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var address = txtAddress.Text.Trim().ToCharArray().ToList();
            Tuple<string, int> matchDelivery = null;
            var matchKey = string.Empty;
            while (address.Count>1)
            {
                matchKey = new string(address.ToArray());
                if (DeliveryTime.ContainsKey(matchKey))
                {
                    matchDelivery = DeliveryTime[matchKey];
                    break;
                }
                address.RemoveAt(address.Count - 1);
            }

            txtResult.Text += txtAddress.Text.Trim() + "\t"
                + (matchDelivery == null ? "无匹配结果" : $"匹配区域： {matchKey}\t时效: {matchDelivery.Item2} 天")
                + Environment.NewLine;
        }

        void BuildDeliveryTime()
        {
            if (DeliveryTime.Any())
            {
                return;
            }

            var deliveryTimeFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Data", "HiltiDeliveryTime.txt");
            var deliveryTimeContent = File.ReadAllLines(deliveryTimeFile);
            var municipality = "上海,北京,天津,重庆";
            var specialProvince = "黑龙江,内蒙古";
            foreach (var item in deliveryTimeContent)
            {
                var vals = item.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                DeliveryTime[vals[0] + vals[1]]= new Tuple<string, int>(vals[1], ToInt32(vals[2]));

                if (municipality.Contains(vals[0].Substring(0,2)))
                {
                    DeliveryTime[vals[0].Replace("市", "")]= new Tuple<string, int>(vals[1],ToInt32(vals[2]));
                }
                else
                {
                    var isSpecialProvince = specialProvince.Contains(vals[0].Substring(0, 2));
                    var province = vals[0].Substring(0, isSpecialProvince ? 3: 2);

                    DeliveryTime[province+"省"+ vals[1]] = new Tuple<string, int>(vals[1], ToInt32(vals[2]));
                    DeliveryTime[province+ vals[1]] = new Tuple<string, int>(vals[1], ToInt32(vals[2]));
                }
            }
        }

        int ToInt32(string s)
        {
            int i;
            int.TryParse(s, out i);
            return i;
        }
    }
}
