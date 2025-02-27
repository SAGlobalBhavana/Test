using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridFramework.SeleniumUtility
{
    public class ExcelHelper
    {
        private readonly FileInfo fileInfo;
        private readonly string sheetName;
        private readonly int? sheetIndex;

        /// <summary>
        /// This function is used to create the Workbook instance for the given excel file 
        ///  using given excel filepath and sheet name
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        public ExcelHelper(string filePath, string sheetName)
        {
            fileInfo = new FileInfo(filePath);
            this.sheetName = sheetName;
        }

        /// <summary>
        /// This function is used to create the Workbook instance for the given excel file 
        ///  using given excel filepath and sheet Index
        ///  sheet Index starts from 0, 1, 2, ...
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="sheetIndex"></param>
        public ExcelHelper(string filePath, int sheetIndex)
        {
            fileInfo = new FileInfo(filePath);
            this.sheetIndex = sheetIndex;
        }

        /// <summary>
        /// This function is used create worksheet based on Sheat name or Sheat index
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        private ExcelWorksheet GetWorksheet(ExcelPackage package)
        {
            if (sheetIndex.HasValue)
            {
                return package.Workbook.Worksheets[sheetIndex.Value];
            }
            else
            {
                return package.Workbook.Worksheets[sheetName];
            }
        }

        /// <summary>
        /// This function is used to read the data and return the cell value in String format
	    ///  using rowIndex and columnindex.
        ///  The rowIndex and columnindex start from 1, 2 ....
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public string ReadData(int row, int col)
        {
            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = GetWorksheet(package);
                return worksheet.Cells[row, col].Value?.ToString();
            }
        }

        /// <summary>
        /// This function is used to write the given value/data in to 
	    ///  cell using row index and column index
        ///  The rowIndex and columnindex start from 1, 2 ....
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        public void WriteData(int row, int col, string value)
        {
            using (var package = new ExcelPackage(fileInfo))
            {
                var worksheet = GetWorksheet(package);
                worksheet.Cells[row, col].Value = value;
                package.Save();
            }
        }

        /* [TestMethod]
         public void excelTesting()
         {
             string excelFilePath = "D:\\Test_Practies\\Evergreen-16thJune\\Microsoft.Dynamics365.UIAutomation.Sample\\File\\01CreateNewCustomer.xlsx";
             string sheetName = "Customer Creation";
             int sheetIndex = 3;
             ExcelHelper excelUtil = new ExcelHelper(excelFilePath, sheetIndex);

             // Example of writing data
             excelUtil.WriteData(3, 2, "Test"); // Write to sheet 3, Row 3, Column 2
             excelUtil.WriteData(3, 3, "Automation"); // Write to sheet 3, Row 3, Column 3
             Console.WriteLine("Data written successfully.");

             // Example of reading data
             string dataRead1 = excelUtil.ReadData(2, 1); // Read from sheet index 3, Row 2, Column 1
             Console.WriteLine($"Read Data: {dataRead1}");
             string dataRead2 = excelUtil.ReadData(2, 2); // Read from sheet index 3, Row 2, Column 2
             Console.WriteLine($"Read Data: {dataRead2}");

             // Example of writing data
             excelUtil.WriteData(3, 2, "Test"); // Write to sheet 3, Row 3, Column 2
             excelUtil.WriteData(3, 3, "Automation"); // Write to sheet 3, Row 3, Column 3
             Console.WriteLine("Data written successfully.");
         }*/
    }
}
