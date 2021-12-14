using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;


namespace SpellingTrainer.ExcelClasses
{
    class excelLoaderClass
    {
        public DataTable importDataFromFile(string filePath) {
            Console.WriteLine(filePath);
            DataTable dt = new DataTable();
            dt = this.createFinalDataTable();
            object misValue = System.Reflection.Missing.Value;
            Excel._Application xlApp = new Excel.Application(); 
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            try
            {

                DataRow workRow;

                xlWorkBook = xlApp.Workbooks.Open(filePath);
                xlWorkSheet = xlWorkBook.Worksheets.Item["Sheet1"];
                //int i = xlWorkSheet.Rows.Count;
                int i = 100;
                Console.WriteLine(i);
                while (i > 0)
                {
                    workRow = dt.NewRow();
                    //var item = xlWorkSheet.Cells[i];
                    workRow["cardID"] = (string)(xlWorkSheet.Cells[i, 1]).Value;
                    workRow["cardLabel"] = (string)(xlWorkSheet.Cells[i, 2]).Value;
                    workRow["cardSolutionBre"] = (string)(xlWorkSheet.Cells[i, 3]).Value;
                    //workRow["cardSolutionAme"] = (string)(xlWorkSheet.Cells[i, 4]).Value;
                    //workRow["cardImagePath"] = (string)(xlWorkSheet.Cells[i, 5]).Value;
                    dt.Rows.Add(workRow);
                    i = i-1;
                
                }

                    //Release the rest of the resources
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEL plugin error" + ex);
                xlApp.Quit();
                return null;
            }

            return dt;
        }

    
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private Excel.Worksheet FillExcel(Excel.Worksheet wk, System.Data.DataTable dt)
        {
            int i = 1;
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                wk.Cells[i, 1] = dr.ItemArray.GetValue(0).ToString();
                wk.Cells[i, 2] = dr.ItemArray.GetValue(1).ToString();
                wk.Cells[i, 3] = dr.ItemArray.GetValue(2).ToString();
                wk.Cells[i, 4] = dr.ItemArray.GetValue(3).ToString();
                i = i + 1;
            }
            //wk.Cells[5, 6] = container["Customer_Number"];

            return wk;
        }

        private System.Data.DataTable createFinalDataTable()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            System.Data.DataColumn dc;

            dc = new System.Data.DataColumn("cardID", typeof(String));
            dt.Columns.Add(dc);
            dc = new System.Data.DataColumn("cardLabel", typeof(String));
            dt.Columns.Add(dc);
            dc = new System.Data.DataColumn("cardSolutionBre", typeof(String));
            dt.Columns.Add(dc);
            dc = new System.Data.DataColumn("cardSolutionAme", typeof(String));
            dt.Columns.Add(dc);
            dc = new System.Data.DataColumn("cardImagePath", typeof(String));
            dt.Columns.Add(dc);
            return dt;
        }

    }
}
