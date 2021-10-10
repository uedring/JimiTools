using JimiTools.Helper;
using JimiTools.Model;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JimiTools.Forms
{
    public enum DeliverySearchType
    {
        City=1,
        Address=2
    }

    public partial class FrmDeliveryTime : Form
    {
        static string deliveryTimeFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "HiltiDeliveryTime.txt");
        Dictionary<string, Tuple<string, int>> DeliveryTime = new Dictionary<string, Tuple<string, int>>();
        Dictionary<string, Tuple<string, int>> CityDeliveryTime = new Dictionary<string, Tuple<string, int>>();

        DateTime FileLastWriteTime = DateTime.MinValue;
        DataTable inputTable = new DataTable();
        private readonly object latch = new object();
        SynchronizationContext syncContext = null;
        static string municipality = "上海,北京,天津,重庆";

        public FrmDeliveryTime()
        {
            InitializeComponent();

            syncContext = SynchronizationContext.Current;

            txtInputExcel.Text = Properties.Settings.Default.ExcelDeliveryTimeSource;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("请输入地址！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var match = GetDeliveryTime(txtAddress.Text.Trim(),rdoByCity.Checked? DeliverySearchType.City: DeliverySearchType.Address);

            txtResult.Text += txtAddress.Text.Trim() + "\t"
                + (match == null ? "无匹配结果" : $"匹配区域： {match.Item1}\t时效: {match.Item3} 天")
                + Environment.NewLine;
            ScrollToBottom();
        }

        Tuple<string,string,int> GetDeliveryTime(string address, DeliverySearchType searchType = DeliverySearchType.Address)
        {
            BuildDeliveryTime();

            if (string.IsNullOrWhiteSpace(address))
            {
                return null;
            }

            if (searchType== DeliverySearchType.City)
            {
                if (CityDeliveryTime.ContainsKey(address))
                {
                    return new Tuple<string, string, int>(CityDeliveryTime[address].Item1, address, CityDeliveryTime[address].Item2);
                }
                return null;
            }

            Tuple<string, int> matchDelivery = null;

            var addressLevel3 = GetAddressLevel3(address);
            if (addressLevel3 != null)
            {
                if (DeliveryTime.ContainsKey(addressLevel3))
                {
                    return new Tuple<string, string, int>(addressLevel3, DeliveryTime[addressLevel3].Item1, DeliveryTime[addressLevel3].Item2);
                }
            }

            var addressArr = address.ToCharArray().ToList();

            var matchKey = string.Empty;
            while (addressArr.Count > 1)
            {
                matchKey = new string(addressArr.ToArray());
                if (DeliveryTime.ContainsKey(matchKey))
                {
                    matchDelivery = DeliveryTime[matchKey];
                    break;
                }
                addressArr.RemoveAt(addressArr.Count - 1);
            }

            return matchDelivery==null?null: new Tuple<string, string, int>(matchKey, matchDelivery.Item1, matchDelivery.Item2);
        }


        void ScrollToBottom()
        {
            txtResult.SelectionStart = txtResult.Text.Length;
            txtResult.ScrollToCaret();
        }

        public static string GetAddressLevel3(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                return null;
            }
            var addressSeparator = "省市区县镇自治州".ToCharArray();

            var arr= address.Split(addressSeparator,StringSplitOptions.RemoveEmptyEntries);

            if (arr.Length>2)
            {
                return arr[0] + arr[2];
            }

            return null;
        }

        void BuildDeliveryTime()
        {
            var fileLastWriteTime = File.GetLastWriteTime(deliveryTimeFile);
            if (fileLastWriteTime==this.FileLastWriteTime)
            {
                return;
            }

            DeliveryTime.Clear();
            CityDeliveryTime.Clear();
            this.FileLastWriteTime = fileLastWriteTime;

            var deliveryTimeContent = File.ReadAllLines(deliveryTimeFile);
            var specialProvince = "黑龙江,内蒙古";

            foreach (var item in deliveryTimeContent)
            {
                var vals = item.Split("\t ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (vals.Length<3)
                {
                    continue;
                }

                DeliveryTime[vals[0] + vals[1]]= new Tuple<string, int>(vals[1], ToInt32(vals[2]));
                CityDeliveryTime[vals[1]]= new Tuple<string, int>(vals[0] + vals[1], ToInt32(vals[2]));

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

        private void txtSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.FileName = txtInputExcel.Text;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Excel数据表|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtInputExcel.Text = openFileDialog.FileName;

                Properties.Settings.Default.ExcelDeliveryTimeSource = txtInputExcel.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void btnViewOutput_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtSavePath.Text))
            {
                System.Diagnostics.Process.Start(txtSavePath.Text);
            }
            else
            {
                MessageBox.Show($"保存目录不存在，请先执行审核操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtInputExcel_TextChanged(object sender, EventArgs e)
        {
            txtSavePath.Text = Path.Combine(Path.GetDirectoryName(txtInputExcel.Text), "订单审核结果");

            InitInputGridData();
        }

        void InitInputGridData()
        {
            if (!File.Exists(txtInputExcel.Text))
            {
                inputTable = new DataTable();
                dgvInputExcel.DataSource = inputTable;
                return;
            }

            Task.Run(() =>
            {
                try
                {
                    lock (latch)
                    {
                        NPOI.XSSF.UserModel.XSSFWorkbook workbook = new NPOI.XSSF.UserModel.XSSFWorkbook(new FileStream(txtInputExcel.Text, FileMode.Open, FileAccess.Read));
                        var sheet = workbook.GetSheetAt(0);
                        var headerRow = sheet.GetRow(0);
                        var lastCellNum = headerRow.LastCellNum;

                        inputTable = new DataTable();
                        inputTable.Columns.Add(new DataColumn("行号"));

                        for (int i = 0; i < lastCellNum; i++)
                        {
                            inputTable.Columns.Add(new DataColumn(headerRow.GetCell(i).StringCellValue));
                        }

                        for (int i = 1; i <= sheet.LastRowNum; i++)
                        {
                            var currentRow = sheet.GetRow(i);

                            if (currentRow == null)
                            {
                                continue;
                            }

                            var newRow = inputTable.NewRow();
                            newRow[0] = i;
                            for (int j = 0; j < lastCellNum; j++)
                            {
                                newRow[j + 1] = currentRow.GetCell(j).GetCellValue();
                            }
                            inputTable.Rows.Add(newRow);
                        }

                        syncContext.Post(d =>
                        {
                            dgvInputExcel.DataSource = inputTable;

                        }, null);
                    }
                }
                catch (Exception ex)
                {
                    syncContext.Post(d =>
                    {
                        MessageBox.Show(d.ToString(), "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoggerHelper.Error(d.ToString());

                    }, ex.Message + Environment.NewLine + ex.StackTrace);
                }


            });
        }

        public DeliveryTimeFilter DeliveryTimeFilter
        {
            get
            {
                return new DeliveryTimeFilter()
                {
                    Address = txtToAddress.Text.Trim(),
                    RecieveDate = txtRevieveDate.Text.Trim(),
                    SendCity = txtToCity.Text.Trim(),
                    SendDate = txtSendDate.Text.Trim(),
                    SendStatus = txtSendStatus.Text.Trim(),
                    OrderNO = txtOrderNum.Text.Trim(),
                    Carrier = txtCarrier.Text.Trim(),
                    IsSellOrder = txtIsSellOrder.Text.Trim(),
                };
            }
        }

        private void btnAudit_Click(object sender, EventArgs e)
        {
            if (inputTable.Rows.Count < 1)
            {
                MessageBox.Show($"选择的表无任何数据，无法执行此操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Read input excel
            NPOI.XSSF.UserModel.XSSFWorkbook inputWorkbook = new NPOI.XSSF.UserModel.XSSFWorkbook(new FileStream(txtInputExcel.Text, FileMode.Open, FileAccess.Read));
            var inputSheet = inputWorkbook.GetSheetAt(0);

            // Check headers exists
            int colIdx = 0;
            var inputFirstRow = inputSheet.GetRow(0);
            var inputHeaders = new HashSet<string>();
            while (true)
            {
                var cell = inputFirstRow.GetCell(colIdx++);
                if (cell==null)
                {
                    break;
                }
                inputHeaders.Add(cell.GetCellStringValue());
            }

            var deliveryTimeFilter = this.DeliveryTimeFilter;
            var deliveryTimeFilterSet = deliveryTimeFilter.GetType().GetProperties().Select(r => r.GetValue(deliveryTimeFilter) + "").ToHashSet<string>();
            var notFoundCols = deliveryTimeFilterSet.Except(inputHeaders);

            if (notFoundCols.Any())
            {
                MessageBox.Show($"所选的表格不包含以下列，无法进行时效审核！\r\n\r\n"+string.Join(Environment.NewLine,notFoundCols), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create output excel
            NPOI.XSSF.UserModel.XSSFWorkbook outputWorkbook = new NPOI.XSSF.UserModel.XSSFWorkbook();
            var outputSheet = outputWorkbook.CreateSheet("sheet1");
            var headerRow = outputSheet.CreateRow(0);

            var cellStyle = outputWorkbook.CreateCellStyle(null);
            var coloredCellStyle = outputWorkbook.CreateCellStyle(NPOI.HSSF.Util.HSSFColor.Tan.Index);
            var dateTimeCellStyle = outputWorkbook.CreateDateTimeCellStyle(null);
            var dateTimeColoredCellStyle = outputWorkbook.CreateDateTimeCellStyle(NPOI.HSSF.Util.HSSFColor.Tan.Index);

            Dictionary<string, ICellStyle> cellStyles = new Dictionary<string, ICellStyle>()
            {
                { "General",cellStyle},
                { "Colored",coloredCellStyle},
                { "DateTime",dateTimeCellStyle},
                { "DateTimeColored",dateTimeColoredCellStyle},
            };

            //                  0       1           2         3         4           5             6        7        8
            var columns = "客户运单号,收货人姓名,收货人电话,送货地址,按时效应到日期,预计到货日日期,审核原因,匹配区域,匹配时效,发货日期,目的城市,承运商,是否销售单".Split(',');
            for (int i = 0; i < columns.Length; i++)
            {
                headerRow.CreateCell(i, i>5? coloredCellStyle : cellStyle).SetCellValue(columns[i]);
            }
            //Set column width
            outputSheet.SetColumnWidth(0,15 * 256);
            outputSheet.SetColumnWidth(3,73 * 256);
            outputSheet.SetColumnWidth(6,28 * 256);
            outputSheet.SetColumnWidth(7,18 * 256);

            //Check orders
            var newRowNum = 1;
            var inputHeadersList = inputHeaders.ToList();
            var ignorCarriers = txtIgnoreCarier.Text.Split(",，;；".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            for (int i = 1; i < inputSheet.LastRowNum; i++)
            {
                var row = inputSheet.GetRow(i);
                var orderNum=row.GetCell(inputHeadersList.IndexOf(deliveryTimeFilter.OrderNO)).GetCellStringValue();
                var toAddress=row.GetCell(inputHeadersList.IndexOf(deliveryTimeFilter.Address)).GetCellStringValue();
                var recieveDate=row.GetCell(inputHeadersList.IndexOf(deliveryTimeFilter.RecieveDate)).GetCellStringValue();
                var sendDate=row.GetCell(inputHeadersList.IndexOf(deliveryTimeFilter.SendDate)).GetCellStringValue().ToDateTime();
                var sendCity=row.GetCell(inputHeadersList.IndexOf(deliveryTimeFilter.SendCity)).GetCellStringValue();
                var sendStatus=row.GetCell(inputHeadersList.IndexOf(deliveryTimeFilter.SendStatus)).GetCellStringValue();
                var carrier=row.GetCell(inputHeadersList.IndexOf(deliveryTimeFilter.Carrier)).GetCellStringValue();
                var isSellOrder=row.GetCell(inputHeadersList.IndexOf(deliveryTimeFilter.IsSellOrder)).GetCellStringValue();

                if ("已送达".Equals(sendStatus) || ignorCarriers.Contains(carrier))
                {
                    continue;
                }

                var deliveryTime = GetDeliveryTime(toAddress);
                IRow newRow=null;
                if (deliveryTime == null)
                {
                    newRow=CreaeRow(outputSheet, ref newRowNum, cellStyles, orderNum, toAddress, 
                        recieveDate.ToDateTime(), "未匹配到时效", "", null,sendDate, sendCity,carrier, isSellOrder);
                }
                else
                {
                    var newRecieveDate = sendDate.AddDays(deliveryTime.Item3);
                    if ((sendCity == deliveryTime.Item2 || sendCity.StartsWith(deliveryTime.Item2)) && deliveryTime.Item1.Substring(0,2)==toAddress.Substring(0,2))
                    {
                        if (newRecieveDate != recieveDate.ToDateTime().Date)
                        {
                            newRow=CreaeRow(outputSheet, ref newRowNum, cellStyles, orderNum, toAddress,
                                newRecieveDate,string.IsNullOrWhiteSpace(recieveDate)? "按时效应到日期为空" : "应到日期与时效不符", 
                                deliveryTime.Item1, deliveryTime.Item3, sendDate, sendCity, carrier, isSellOrder);
                        }
                    }
                    else
                    {
                        if (!municipality.Contains(toAddress.Substring(0, 2)))
                        {
                            newRow=CreaeRow(outputSheet, ref newRowNum, cellStyles, orderNum, toAddress,
                                newRecieveDate, "目地城市不一致", deliveryTime.Item1, deliveryTime.Item3, sendDate, sendCity, carrier, isSellOrder);
                        }
                    }
                }

                var extraReason = string.Empty;
                if (string.IsNullOrWhiteSpace(carrier))
                {
                    extraReason += "、承运商为空";
                }

                if ((orderNum.StartsWith("27") && isSellOrder !="销售单")|| (!orderNum.StartsWith("27") && isSellOrder == "销售单"))
                {
                    extraReason += "、是否为销售单有误";
                }

                if (!string.IsNullOrWhiteSpace(extraReason))
                {
                    if (newRow == null)
                    {
                        newRow = CreaeRow(outputSheet, ref newRowNum, cellStyles, orderNum, toAddress,
                            recieveDate.ToDateTime(), extraReason.Trim('、'), "", null, sendDate, sendCity, carrier, isSellOrder);
                    }
                    else
                    {
                        newRow.GetCell(6).SetCellValue(newRow.GetCell(6).GetCellStringValue() + extraReason);
                    }
                }


            }


            if (!Directory.Exists(txtSavePath.Text))
            {
                Directory.CreateDirectory(txtSavePath.Text);
            }

            var saveFile = Path.Combine(txtSavePath.Text, "订单审核结果"+DateTime.Now.ToString("M-d") + ".xlsx");

            outputWorkbook.Write(new FileStream(saveFile, FileMode.Create));


            MessageBox.Show("审核完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        IRow CreaeRow(ISheet sheet,ref int rowIndex,Dictionary<string,ICellStyle> cellStyles,
            string orderNum,string address,DateTime revieveDate,string reason,string area,
            int? deliveryTime,DateTime sendDate,string sendCity,string carrier,string isSellOrder)
        {
            //"客户运单号,收货人姓名,收货人电话,送货地址,按时效应到日期,预计到货日日期,审核原因,匹配区域,匹配时效,发货日期,目的城市".Split(',');
            var newRow = sheet.CreateRow(rowIndex++);
            newRow.CreateCell(0, cellStyles["General"]).SetCellValueFromObject(orderNum);
            newRow.CreateCell(1, cellStyles["General"]).SetCellValueFromObject(string.Empty);
            newRow.CreateCell(2, cellStyles["General"]).SetCellValueFromObject(string.Empty);
            newRow.CreateCell(3, cellStyles["General"]).SetCellValueFromObject(address);


            newRow.CreateCell(4, cellStyles["DateTime"]).SetCellValueFromObject(revieveDate);
            newRow.CreateCell(5, cellStyles["DateTime"]).SetCellValueFromObject(revieveDate);

            newRow.CreateCell(6, cellStyles["Colored"]).SetCellValueFromObject(reason);
            newRow.CreateCell(7, cellStyles["Colored"]).SetCellValueFromObject((area+"").Replace("省",""));
            newRow.CreateCell(8, cellStyles["Colored"]).SetCellValueFromObject(deliveryTime);
            newRow.CreateCell(9, cellStyles["DateTimeColored"]).SetCellValueFromObject(sendDate);
            newRow.CreateCell(10, cellStyles["Colored"]).SetCellValueFromObject(sendCity);
            newRow.CreateCell(11, cellStyles["Colored"]).SetCellValueFromObject(carrier);
            newRow.CreateCell(12, cellStyles["Colored"]).SetCellValueFromObject(isSellOrder);

            return newRow;
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
            }
        }

        private void btnViewDeliveryFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(deliveryTimeFile))
            {
                System.Diagnostics.Process.Start(deliveryTimeFile);
            }
            else
            {
                MessageBox.Show($"时效文件不存在！文件名：\r\n"+deliveryTimeFile, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmDeliveryTime_Load(object sender, EventArgs e)
        {
            if (!File.Exists(deliveryTimeFile))
            {
                MessageBox.Show($"时效文件不存在！无法进行后续操作，请检查文件是否存在！文件名：\r\n" + deliveryTimeFile, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Task.Run(async()=> {

                while (true)
                {
                    BuildDeliveryTime();
                    await Task.Delay(2 * 1000);
                }
            });
        }
    }
    }
