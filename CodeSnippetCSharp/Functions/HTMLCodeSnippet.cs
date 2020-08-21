using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace CodeSnippetCSharp
{
    class HTMLCodeSnippet
    {
        public static string ReplaceSpecialCharacters(string input)
        {
            input = input.Replace("&amp;", "&");
            return input;
        }
        public static string RemoveHTMLTagsFromString(string input)
        {
            input = Regex.Replace(input, "<.*?>", String.Empty);
            input = ReplaceSpecialCharacters(input);
            return input;
        }
        public static string RemoveHTMLTagsFromStringNewLine(string input)
        {
            input = Regex.Replace(input, "<.*?>", Environment.NewLine);
            input = Regex.Replace(input, @"^\s*$[\r\n]*", string.Empty, RegexOptions.Multiline);
            input = ReplaceSpecialCharacters(input);
            if (input != string.Empty)
            {
                Clipboard.SetText(input);
            }
            return input;
        }
        public static List<string> ExtractYouTubeVideoURLs(string input)
        {
            string regexExpression = @"(www\.youtube\.com\/watch\?v=[a-zA-Z0-9-_]+)";
            List<string> strings = new List<string>();
            List<string> unique = new List<string>();
            //int matchCollectionCount = Regex.Matches(input, @"(.*?)(v=)([a-z0-9_-]{11})").Count;
            //int matchCollectionCount = Regex.Matches(input, @"/(www.youtube.com/watch?v=)([a-z0-9_-]{11})/gim").Count;
            //int matchCollectionCount = Regex.Matches(input, @"\b(?:https?://|www\.)\S+\b").Count;
            //int matchCollectionCount = Regex.Matches(input, @"\b([a-z0-9_-]{11})\b").Count;
            int matchCollectionCount = Regex.Matches(input, regexExpression).Count;
            //string[] test = Regex.Matches(input, @"\b([a-z0-9_-]{11})\b").ToString();
            var test = Regex.Matches(input, regexExpression)
                .Cast<Match>().Select(m => m.Value).ToArray();

            foreach (var item in test)
            {
                strings.Add(item);
            }

            unique = strings.Distinct().ToList();

            //var test = Regex.Matches(input, @"(.*?)(v=)([a-z0-9_-]{11})");
            //if (input != string.Empty)
            //{
            //    Clipboard.SetText(input);
            //}
            return unique;
        }
        //public static string ReadTextFile(string pathandfileNamewithExt)
        //{
        //    string redTextFile = pathandfileNamewithExt;
        //    string regexExpression = @"(www\.youtube\.com\/watch\?v=[a-zA-Z0-9-_]+)";
        //}

        public static string ReadTextFileUsingDialougeBox()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|html files (*.html)|*.html|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            //openFileDialog.ShowDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //string fileName;
                filePath = openFileDialog.FileName;
                //MessageBox.Show(filePath);

                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
            return fileContent;
        }
    }
}