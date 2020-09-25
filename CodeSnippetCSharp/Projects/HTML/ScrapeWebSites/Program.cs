using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CodeSnippetCSharp;
using System.IO;
using System.Linq;

namespace CodeSnippetCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFileName = @"C:\Users\msaddique\Downloads\unityPackageNameAndLink.txt";
            string newFileName = @"d:\Link.txt";
            List<string> mainDataList = new List<string>();
            List<string> getReponseList = new List<string>();
            List<CSVData> CSVStructDataList = new List<CSVData>();

            //var test1 = ReadTextFileDirect(@"C:\Users\Shahid\Downloads\temp.html");
            //listofCSV = ReadTextFileDirect(@"C:\Users\Shahid\Downloads\temp.html").Split('@').ToList();
            mainDataList = ReadTextFileDirect(sourceFileName).Split('@').ToList();
            char delimiter = ',';
            int i = 0;
            string temp = string.Empty;
            foreach (var item in mainDataList)
            {
                var tempData = new CSVData();

                if (i % 2 == 0)
                {
                    temp = item;
                }
                if (i % 2 == 1)
                {
                    string temp1 = item;
                    tempData.packageName = temp;
                    tempData.packageDownloadLink = item;
                    tempData.packageResponseData = HtmlStringAsync(item).Replace("<META HTTP-EQUIV=REFRESH CONTENT=", string.Empty).Replace("\"1;", string.Empty).Replace("\">", string.Empty).Trim();

                    CSVStructDataList.Add(tempData);
                }
                i++;

            }

            var result = WriteTextFile(newFileName, CSVStructDataList);



            //HtmlStringAsync();

            //ExtractTablefromHTML();


            Console.ReadLine();
        }

        public struct CSVData
        {
            public string packageName { get; set; }
            public string packageDownloadLink { get; set; }
            public string packageResponseData { get; set; }
        }

        private static void ExtractTablefromHTML()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(@"C:\Users\Shahid\Downloads\Unity3d Assets collection _ Unity3d Assetstore.html");

            //using link to parse HTML table 
            var htmlTableToList =
                from table in doc.DocumentNode.SelectNodes("//*[@id=\"items\"]/li/div/div[2]/table").Cast<HtmlNode>()
                from tbody in table.SelectNodes("tbody").Cast<HtmlNode>()
                from row in tbody.SelectNodes("tr").Cast<HtmlNode>()
                from cell in row.SelectNodes("td").Cast<HtmlNode>()
                from link in cell.SelectNodes("a").Cast<HtmlNode>()
                select new { Cell_Text = cell.InnerText, Cell_Link = link.Attributes};

            var htmlTableToLinkList =
    from table in doc.DocumentNode.SelectNodes("//*[@id=\"items\"]/li/div/div[2]/table").Cast<HtmlNode>()
    from tbody in table.SelectNodes("tbody").Cast<HtmlNode>()
    from row in tbody.SelectNodes("tr").Cast<HtmlNode>()
    from cell in row.SelectNodes("td").Cast<HtmlNode>()
    select new { CellName = cell.HasAttributes};

            foreach (var item in htmlTableToList)
            {
                Console.WriteLine("{0}: {1}", item.Cell_Text, item.Cell_Link);
            }
            //doc.LoadHtml(@"<html><body><p><table id=""foo""><tr><th>hello</th></tr><tr><td>world</td></tr></table></body></html>");
            //doc.LoadHtml(@"C:\Users\Shahid\Downloads\Unity3d Assets collection _ Unity3d Assetstore.html");
            //foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
            //foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//*[@id=\"items\"]/li/div/div[2]/table"))
            //{
            //    Console.WriteLine("Found: " + table.Id);
            //    Console.WriteLine("Found: " + table.Name);
            //    Console.WriteLine("Found: " + table.ChildNodes.ToString());
            //    //foreach (HtmlNode row in table.SelectNodes("tr"))
            //    // foreach (HtmlNode row in table.SelectNodes("//*[@id=\"items\"]/li/div/div[2]/table/tbody/tr[1]"))
            //    foreach (var item in doc.DocumentNode.se)
            //    {

            //    }
            //    foreach (HtmlNode row in table.ChildNodes)
            //    {
            //        if (row.Name == "tbody")
            //            continue;
            //        foreach (HtmlNode item in table.ChildNodes)
            //        {

            //        }
            //        Console.WriteLine("row");
            //        foreach (HtmlNode cell in row.SelectNodes("th|td"))
            //        {
            //            Console.WriteLine("cell: " + cell.InnerText);
            //        }
            //    }
            //}
        }

        private static string HtmlStringAsync(string url)
        {
            //var url = "http://unitylover.com/download/38896424";
            //var url = "http://unity3d-assetstore.blogspot.com/2018/05/unity3d-assets-collection.html";
            var httpClient = new HttpClient();
            httpClient.CancelPendingRequests();
            var html = httpClient.GetStringAsync(url);
            //var html = httpClient.GetStringAsync(url);
            //httpClient.CancelPendingRequests();
            //httpClient.Timeout = 1000.0f;
            Console.WriteLine(html.Result);
            return html.Result;
        }
        public static string ReadTextFileDirect(string fileNameandPath)
        {
            var fileContent = string.Empty;

            using (StreamReader reader = new StreamReader(fileNameandPath))
            {
                fileContent = reader.ReadToEnd();
            }
            return fileContent;
        }
        public static string ReadTextFileDirectList(string fileNameandPath)
        {
            List<string> tempList = new List<string>();
            var fileContent = string.Empty;

            using (StreamReader reader = new StreamReader(fileNameandPath))
            {
                fileContent = reader.ReadToEnd();
            }
            tempList = fileContent.Split('@').ToList();
            return fileContent;
        }
        public static bool WriteTextFile(string pathAndName, List<CSVData> CSVDataList)
        {
            char delimiter = ',';
            //string path = @"D:\Text_Files\my_file.txt";

            // The line below will create a text file, my_file.txt, in 
            // the Text_Files folder in D:\ drive.
            // The CreateText method that returns a StreamWriter object
            using (StreamWriter sw = File.CreateText(pathAndName))
            {
                foreach (var item in CSVDataList)
                    {
                    sw.WriteLine(item.packageName + delimiter + item.packageDownloadLink+delimiter+item.packageResponseData);                
                    }
                sw.Close();
                sw.Dispose();
            }           

            if (File.Exists(pathAndName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
