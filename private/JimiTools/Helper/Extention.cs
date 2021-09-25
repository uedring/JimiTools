using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimiTools
{
    public static class Extention
    {
        public static ICell CreateCell(this IRow row,int column,ICellStyle cellStyle)
        {
            if (row==null)
            {
                return null;
            }

            var newCell= row.CreateCell(column);
            newCell.CellStyle = cellStyle;

            return newCell;
        }

        public static ICell CreateCell(this IRow row, int column, ICellStyle cellStyle,CellType cellType)
        {
            if (row == null)
            {
                return null;
            }

            var newCell = row.CreateCell(column,cellType);
            newCell.CellStyle = cellStyle;

            return newCell;
        }

        public static bool IsNumeric(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }
            double i;
            return double.TryParse(s,out i);
        }

        public static int ToInt32(this string s)
        {
            int i;
            int.TryParse(s, out i);

            return i;
        }

        public static long ToInt64(this string s)
        {
            long i;
            long.TryParse(s, out i);

            return i;
        }

        public static double ToNumeric(this string s)
        {
            double i;
            double.TryParse(s, out i);
            return i;
        }
    }
}
