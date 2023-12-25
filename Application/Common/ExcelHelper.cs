using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    /// <summary>
    /// 需安裝 NPOI 的套件
    /// </summary>

    public static class ExcelHelper
    {
        public static XSSFWorkbook CreateWorkbook(string sheetName = "Sheet1")
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet(sheetName);
            return workbook;
        }

        public static void SetRow(this XSSFWorkbook workbook, int row, params object[] args)
        {
            var sheet = workbook.GetSheetAt(0);
            sheet.SetRow(row, args);
        }

        /// <summary>
        /// 設定標題欄位
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="row"></param>
        /// <param name="args">"會員編號", "客戶名稱" ...etc</param>
        public static void SetRow(this ISheet worksheet, int row, params object[] args)
        {
            int col = 0;
            var rowExcel = worksheet.CreateRow(row);
            Console.WriteLine(row);
            foreach (var arg in args)
            {
                var cell = rowExcel.CreateCell(col++);
                cell.SetCellValue(arg);
            }
        }

        public static void SetCellValue(this ICell cell, object o)
        {
            if (o == null)
            {
                cell.SetCellValue((string)null);
            }
            else if (o is string)
            {
                cell.SetCellValue((string)o);
            }
            else if (o is DateTime)
            {
                cell.SetCellValue((DateTime)o);
            }
            else if (o is bool)
            {
                cell.SetCellValue((bool)o);
            }
            else if (o is int || o is decimal || o is double || o is float)
            {
                cell.SetCellValue(System.Convert.ToDouble(o));
            }
            else
            {
                cell.SetCellValue(o.ToString());
            }
        }

        /// <summary>
        /// 設定欄位寬度
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="row"></param>
        /// <param name="args"></param>
        public static void SetColumnWidth(this XSSFWorkbook workbook, params int[] args)
        {
            var sheet = workbook.GetSheetAt(0);
            sheet.SetColumnWidth(args);
        }

        public static void SetColumnWidth(this ISheet worksheet, params int[] args)
        {
            int col = 0;
            foreach (int n in args)
            {
                worksheet.SetColumnWidth(col++, n * 256);
            }
        }

        public static void SetDefaultColumnStyle(this XSSFWorkbook workbook, params string[] formats)
        {
            var sheet = workbook.GetSheetAt(0);
            sheet.SetDefaultColumnStyle(formats);
        }

        public static void SetDefaultColumnStyle(this ISheet worksheet, params string[] formats)
        {
            int col = 0;
            var workbook = worksheet.Workbook;
            foreach (string format in formats)
            {
                if (string.IsNullOrEmpty(format))
                {
                    var cellStyle = workbook.CreateCellStyle();
                    var dataFormat = workbook.CreateDataFormat();
                    cellStyle.DataFormat = dataFormat.GetFormat(format);
                    worksheet.SetDefaultColumnStyle(col, cellStyle);
                }
                col++;
            }
        }
    }
}
