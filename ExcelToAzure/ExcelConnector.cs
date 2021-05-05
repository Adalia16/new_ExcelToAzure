using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Windows.Forms;

namespace ExcelToAzure
{
    public static class Xls
    {
        public static void GetArrayFromFile(string filename, Action<List<string[]>> result)
        {
            Sheets objSheets;
            _Worksheet objSheet;
            Range range;

            var xlApp = new Excel.Application();
            var objBook = xlApp.Workbooks.Open(filename, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            try
            {
                //Get a reference to the first sheet of the workbook.
                objSheets = objBook.Worksheets;
                var worksheets = objSheets.Cast<_Worksheet>().ToList();
                SelectFromList.Open(worksheets.Select(x => x.Name).ToList(), "Select Sheet to import", (sheetname) =>
                {
                    objSheet = worksheets.Find(x => x.Name == sheetname);
                    range = objSheet.UsedRange;

                    //Retrieve the data from the range.
                    Object[,] saRet;
                    saRet = (System.Object[,])range.get_Value(Missing.Value);

                    //Determine the dimensions of the array.
                    long iRows;
                    long iCols;
                    iRows = saRet.GetUpperBound(0);
                    iCols = saRet.GetUpperBound(1);

                    //Build a string that contains the data of the array.
                    List<string[]> data = new List<string[]>();

                    for (int rowCounter = 1; rowCounter <= iRows; rowCounter++)
                    {
                        var row = new string[iCols];
                        for (int colCounter = 1; colCounter <= iCols; colCounter++)
                        {
                            //Write the next value into the string.
                            row[colCounter - 1] = (saRet[rowCounter, colCounter] ?? "").ToString();
                        }

                        //Write in a new line.
                        data.Add(row);
                    }
                    //MessageBox.Show("Returning data for Sheet--> " + objSheet.Name);
                    result?.SafeInvoke(data);
                });
            }
            catch (Exception theException)
            {
                MessageBox.Show(theException.Message, "Missing Workbook?");
            }
        }

        public static void ShowDataInNewApp(List<Dictionary<string, object>> records)
        {
            Workbooks objBooks;
            Sheets objSheets;
            _Worksheet objSheet;
            Range range;

            try
            {
                // Instantiate Excel and start a new workbook.
                var objApp = new Microsoft.Office.Interop.Excel.Application();
                objBooks = objApp.Workbooks;
                var objBook = objBooks.Add(Missing.Value);
                objSheets = objBook.Worksheets;
                objSheet = (_Worksheet)objSheets.get_Item(1);

                //Get the range where the starting cell has the address
                //m_sStartingCell and its dimensions are m_iNumRows x m_iNumCols.
                range = objSheet.get_Range("A1", Missing.Value);
                range = range.get_Resize(records.Count() + 1, records[0].Count());

                if (true)
                {
                    //Create an array.
                    object [,] saRet = new object [records.Count() + 1, records[0].Count()];
                    //Header
                    var keys = records[0].Keys.ToList();
                    for (int i = 0; i < records[0].Count(); i++)
                    {
                        saRet[0, i] = keys[i];
                    }
                    //saRet[0, 0] = "project.name";
                    //saRet[0, 1] = "phase";
                    //saRet[0, 2] = "location.code";
                    //saRet[0, 3] = "location.name";
                    //saRet[0, 4] = "location.bsf";
                    //saRet[0, 5] = "level1";
                    //saRet[0, 6] = "name1";
                    //saRet[0, 7] = "level2";
                    //saRet[0, 8] = "name2";
                    //saRet[0, 9] = "level3";
                    //saRet[0, 10] = "name3";
                    //saRet[0, 11] = "level4";
                    //saRet[0, 12] = "name4";
                    //saRet[0, 13] = "template.code";
                    //saRet[0, 14] = "description";
                    //saRet[0, 15] = "qty";
                    //saRet[0, 16] = "ut";
                    //saRet[0, 17] = "price";
                    //saRet[0, 18] = "total";
                    //saRet[0, 19] = "comments";
                    //saRet[0, 20] = "csi_code";
                    //saRet[0, 21] = "trade_code";
                    //saRet[0, 22] = "estimate_category";

                    //Fill the array.
                    for (int iRow = 0; iRow < records.Count(); iRow++)
                    {
                        for(int iCol = 0; iCol < keys.Count(); iCol++)
                        {
                            saRet[iRow + 1, iCol] = records[iRow][keys[iCol]];
                        }
                        //saRet[iRow + 1, 0] = records[iRow].location.project.name;
                        //saRet[iRow + 1, 1] = records[iRow].phase.phase;
                        //saRet[iRow + 1, 2] = records[iRow].location.code;
                        //saRet[iRow + 1, 3] = records[iRow].location.name;
                        //saRet[iRow + 1, 4] = records[iRow].location.bsf;
                        //saRet[iRow + 1, 5] = records[iRow].template.level.level1;
                        //saRet[iRow + 1, 6] = records[iRow].template.level.name1;
                        //saRet[iRow + 1, 7] = records[iRow].template.level.level2;
                        //saRet[iRow + 1, 8] = records[iRow].template.level.name2;
                        //saRet[iRow + 1, 9] = records[iRow].template.level.level3;
                        //saRet[iRow + 1, 10] = records[iRow].template.level.name3;
                        //saRet[iRow + 1, 11] = records[iRow].template.level.level4;
                        //saRet[iRow + 1, 12] = records[iRow].template.level.name4;
                        //saRet[iRow + 1, 13] = records[iRow].template.code;
                        //saRet[iRow + 1, 14] = records[iRow].template.description;
                        //saRet[iRow + 1, 15] = records[iRow].qty;
                        //saRet[iRow + 1, 16] = records[iRow].template.ut;
                        //saRet[iRow + 1, 17] = records[iRow].price;
                        //saRet[iRow + 1, 18] = records[iRow].total;
                        //saRet[iRow + 1, 19] = records[iRow].comments;
                        //saRet[iRow + 1, 20] = records[iRow].csi_code;
                        //saRet[iRow + 1, 21] = records[iRow].trade_code;
                        //saRet[iRow + 1, 22] = records[iRow].estimate_category;
                    }

                    //Set the range value to the array.
                    range.set_Value(Missing.Value, saRet);
                    try
                    {
                        objSheet.ListObjects.AddEx(XlListObjectSourceType.xlSrcRange, range, range, Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes, range).Name = "MyTableStyle";
                        objSheet.ListObjects.get_Item("MyTableStyle").TableStyle = "TableStyleLight9";
                    }
                    catch
                    {

                    }
                }

                //Return control of Excel to the user.
                objApp.Visible = true;
                objApp.UserControl = true;
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                MessageBox.Show(errorMessage, "Error");
            }
        }
    }
}
