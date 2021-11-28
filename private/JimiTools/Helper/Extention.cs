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
            else if(value.GetType()==typeof(DateTime) || value.GetType() == typeof(DateTime?))
            {
                cell.SetCellValue((DateTime)value);
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

        public static object GetCellValue(this NPOI.SS.UserModel.ICell cell,string replaceValue= " [0-9]+:[0-9]+.+")
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
                    return System.Text.RegularExpressions.Regex.Replace(cell.StringCellValue, replaceValue, "");
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


        public static ICellStyle CreateDateTimeCellStyle(this NPOI.SS.UserModel.IWorkbook workBook,short? bgColor)
        {
            var dateTimeCellStyle = workBook.CreateCellStyle();

            var cellFont = workBook.CreateFont();
            cellFont.FontName = "SimSun";
            cellFont.FontHeightInPoints = 9;

            var dateTimeFormat = workBook.CreateDataFormat();
            dateTimeCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            dateTimeCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            dateTimeCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            dateTimeCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            dateTimeCellStyle.SetFont(cellFont);
            dateTimeCellStyle.DataFormat = dateTimeFormat.GetFormat("yyyy/M/d");

            if (bgColor.HasValue)
            {
                dateTimeCellStyle.FillForegroundColor = bgColor.Value;
                dateTimeCellStyle.FillPattern = FillPattern.SolidForeground;
            }



            return dateTimeCellStyle;
        }

        public static ICellStyle CreateCellStyle(this NPOI.SS.UserModel.IWorkbook workBook, short? bgColor)
        {
            var cellStyle = workBook.CreateCellStyle();

            var cellFont = workBook.CreateFont();
            cellFont.FontName = "SimSun";
            cellFont.FontHeightInPoints = 9;

            var dateTimeFormat = workBook.CreateDataFormat();
            cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            cellStyle.SetFont(cellFont);



            if (bgColor.HasValue)
            {
                cellStyle.FillForegroundColor = bgColor.Value;
                cellStyle.FillPattern = FillPattern.SolidForeground;
            }


            return cellStyle;
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
