using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippetCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlStringAsync();

            Console.ReadLine();
        }

        private static void HtmlStringAsync()
        {
            var url = "http://unity3d-assetstore.blogspot.com/2018/05/unity3d-assets-collection.html";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url);
            //var html = httpClient.GetStringAsync(url);

            Console.WriteLine(html.Result);
        }
    }
}
