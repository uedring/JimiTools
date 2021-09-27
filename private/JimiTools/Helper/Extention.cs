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

        public static ICell SetCellValueFromObject(this ICell cell,object value)
        {
            if (value==null)
            {
                cell.SetCellValue(string.Empty);
            }
            else
            {
                if (value.ToString().IsNumeric())
                {
                    cell.SetCellValue(value.ToString().ToNumeric());
                }
                else
                {
                    cell.SetCellValue(value.ToString());
                }
            }

            return cell;
        }

        public static DateTime ToDateTime(this string s)
        {
            DateTime d;
            DateTime.TryParse(s, out d);

            return d;
        }

        public static object GetCellValue(this NPOI.SS.UserModel.ICell cell,string replaceValue="")
        {
            if (cell == null)
            {
                return string.Empty;
            }

            if (cell.CellType == NPOI.SS.UserModel.CellType.Numeric)
            {
                return cell.NumericCellValue;
            }
            else if (cell.CellType == NPOI.SS.UserModel.CellType.Boolean)
            {
                return cell.BooleanCellValue.ToString();
            }
            else
            {
                if (string.IsNullOrEmpty(replaceValue))
                {
                    return cell.StringCellValue;
                }
                else
                {
                    return cell.StringCellValue.Replace(replaceValue, "");
                }
            }
        }

        public static string GetCellStringValue(this NPOI.SS.UserModel.ICell cell)
        {
            if (cell == null)
            {
                return string.Empty;
            }

            if (cell.CellType == NPOI.SS.UserModel.CellType.Numeric)
            {
                return cell.NumericCellValue.ToString();
            }
            else if (cell.CellType == NPOI.SS.UserModel.CellType.Boolean)
            {
                return cell.BooleanCellValue.ToString();
            }
            else
            {
                return cell.StringCellValue;
            }
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
