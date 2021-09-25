using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimiTools.Model
{
    public class ColumnsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SampleValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReferenceColumn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Index { get; set; }
        public string ValueType { get; set; }
    }

    public class ExcelTemplate
    {
        /// <summary>
        /// 惠仕三笑模板
        /// </summary>
        public string TemplateName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ColumnsItem> Columns { get; set; }
    }

}
