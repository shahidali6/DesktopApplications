using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippetCSharp.Functions
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
    }
}
