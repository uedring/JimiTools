using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimiTools.Model
{
    public class DeliveryTimeFilter
    {
        public string SendDate { get; set; }
        public string SendCity { get; set; }
        public string Address { get; set; }
        public string RecieveDate { get; set; }
        public string SendStatus { get; set; }
        public string OrderNO { get; set; }
    }
}
