using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippetCSharp
{
    class MSWord
    {
        public static void ModifyMSWordDoc(string pathNfileName)
        {
            string companyName = string.Empty;
            string companyNameChange = "The Atlantic Foundation";
            string sentanceToReplaceStart = "With the support of";
            string sentanceToReplace = "With the support of The Atlantic Foundation and through the successful delivery of this project we can reduce the pressures on our environment and get Africa back on its feet, one leg at a time.";
            string firstSentence = "Our goal for 2020 is to raise £61,676 in order to collect 2,500 legs and deliver 2,000 of them to sub-Saharan Africa. ";
            string prefix = "A donation from ";
            string endSentence = " would go a long way to accomplish this.";
            string path = pathNfileName;
            Application word = new Application();
            //word.DisplayAlerts = false;
            Document doc = new Document();

            object fileName = path;
            // Define an object to pass to the API for missing parameters
            object missing = System.Type.Missing;
            doc = word.Documents.Open(ref fileName,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            String read = string.Empty;
            List<string> data = new List<string>();
            for (int i = 0; i < doc.Paragraphs.Count; i++)
            {
                string temp = doc.Paragraphs[i + 1].Range.Text.Trim();
                if (temp != string.Empty)
                {
                    if (temp.StartsWith(firstSentence))
                    {
                        List<string> tempList = new List<string>();
                        temp = temp.Replace(firstSentence, string.Empty).Trim();
                        temp = temp.Replace(prefix, string.Empty).Trim();
                        temp = temp.Replace(endSentence, string.Empty).Trim();
                        tempList = temp.Split(' ').ToList();
                        //tempList.RemoveAt(tempList.Count);
                        tempList.RemoveRange(tempList.Count - 2, 2);

                        companyName = string.Join(" ", tempList);
                        sentanceToReplace = sentanceToReplace.Replace(companyNameChange, companyName).Trim();
                    }

                    if (temp.StartsWith(sentanceToReplaceStart))
                    {
                        _ = doc.Paragraphs[i + 1].Range.Font.Size = 12.00f;
                        doc.Paragraphs[i + 1].Range.Text = sentanceToReplace + Environment.NewLine;
                    }
                    //string para = "Part A So close no matter how far. Couldn't be much more from the heart.Forever trusting who we are.And nothing else matters.Part B Never opened myself this way. Life is ours, we live it our way.All these words I don't just say.And nothing else matters";

                    //Regex regex = new Regex("Part [A-Z] ", RegexOptions.IgnoreCase);
                    //string[] lines = regex.Split(para).Where(s => s != String.Empty).ToArray();
                }
            }
            ((_Document)doc).Save();
            ((_Document)doc).Close();
            ((_Application)word).Quit();
        }
        public static string ModifyMSWordDocTables(string pathNfileName)
        {
            string mainString = string.Empty;
            Application wordApp = new Application();
            //word.DisplayAlerts = false;
            Document doc = new Document();

            object fileName = pathNfileName;
            // Define an object to pass to the API for missing parameters
            object missing = System.Type.Missing;
            doc = wordApp.Documents.Open(ref fileName,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            List<Range> allTablesList = new List<Range>();
            int loopCounter = 0;

            for (int i = 0; i < doc.Tables.Count; i++)
            {
                Range tableRange = doc.Tables[i].Range;
                allTablesList.Add(tableRange);
            }

            var listTables = doc.Tables;

            //allTablesList.Add(listTables);

            //allTablesList.Add(doc.Tables);

            foreach (var table in listTables)
            {
                //Range row = table. .Range;
                //Cells cells = row.Cells;
            }

            for (int i = 0; i < doc.Tables.Count; i++)
            {
                //allTablesList.Add(doc.Tables[i]);
            }

            foreach (var item in doc.Tables)
            {
                //allTablesList.Add(doc.Tables[loopCounter]);
                loopCounter++;
            }

            foreach (var item in allTablesList)
            {
                loopCounter = 0;
                //Range row = item.Range;
                //Cells cells = row.Cells;
                //foreach (var item1 in cells)
                //{
                //    Cell cell = cells[loopCounter];
                //    Range row2 = cell.Range;
                //    mainString += row2.Text + Environment.NewLine;
                   
                //    Marshal.ReleaseComObject(cell);
                //    Marshal.ReleaseComObject(row2);
                //    loopCounter++;
                //}
                //Marshal.ReleaseComObject(row);
                //Marshal.ReleaseComObject(cells);
            }

            //Table t = doc.Tables[1];
            //Range r = t.Range;
            //Cells cells = r.Cells;
            //for (int i = 1; i <= cells.Count; i++)
            //{
            //    Cell cell = cells[i];
            //    Range r2 = cell.Range;
            //    mainString =+ r2.Text + Environment.NewLine;
            //    Marshal.ReleaseComObject(cell);
            //    Marshal.ReleaseComObject(r2);
            //}

            //Rows rows = t.Rows;
            //Columns cols = t.Columns;
            // Cannot access individual rows in this collection because the table has vertically merged cells.
            //for (int i = 0; i < rows.Count; i++) {
            //  for (int j = 0; j < cols.Count; j++) {
            //      Cell cell = rows[i].Cells[j];
            //      Range r = cell.Range;
            //  }
            //}
            doc.Close(false);
            wordApp.Quit(false);
                //doc.Close(false);
                //app.Quit(false);
                //Marshal.ReleaseComObject(cols);
                //Marshal.ReleaseComObject(rows);
                Marshal.ReleaseComObject(doc);
                Marshal.ReleaseComObject(wordApp);

            //((_Document)doc).Save();
            //            ((_Document)doc).Close();
            //            ((_Application)word).Quit();
            return mainString;
        }
        public static void PrintWordDocument(string pathNFileName)
        {
            using (System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog())
            {
                //pd.ShowDialog();
                ProcessStartInfo info = new ProcessStartInfo(pathNFileName);
                info.Verb = "PrintTo";
                info.Arguments = pd.PrinterSettings.PrinterName;
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                info.ErrorDialog = false;
                Process.Start(info);
            }
        }
    }
}
