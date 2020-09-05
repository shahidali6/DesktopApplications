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
        #region RawDataSample
        public string sampleYouTubeData { get; set; } = 
            @"https:\/\/www.youtube.com\/watch?v=CN1aS_MnVFg
            https:\/\/www.youtube.com\/watch?v=tiC7T0YIcnE
            https:\/\/www.youtube.com\/watch?v=vzw47eKqObg
            https:\/\/www.youtube.com\/watch?v=jqu5DYc0yvU

            <a id=""thumbnail"" class=""yt-simple-endpoint inline-block style-scope ytd-thumbnail"" aria-hidden=""true"" tabindex=""-1"" rel=""null"" href=""https:\/\/www.youtube.com\/watch?v=jqu5DYc0yvU"">
              <yt-img-shadow ftl-eligible="""" class=""style-scope ytd-thumbnail no-transition"" style=""background-color: transparent;"" loaded=""""><!--css-build:shady--><img id=""img"" class=""style-scope yt-img-shadow hoverZoomLink"" alt="""" width=""210"" src="".\/TRT Ertugrul by PTV - YouTube_files\/hqdefault(26).jpg""><\/yt-img-shadow>
      
              <div id=""overlays"" class=""style-scope ytd-thumbnail""><ytd-thumbnail-overlay-time-status-renderer class=""style-scope ytd-thumbnail"" overlay-style=""DEFAULT""><!--css-build:shady--><yt-icon class=""style-scope ytd-thumbnail-overlay-time-status-renderer"" disable-upgrade="""" hidden=""""><\/yt-icon><span class=""style-scope ytd-thumbnail-overlay-time-status-renderer"" aria-label=""48 minutes, 45 seconds"">
              48:45
                <\/span><\/ytd-thumbnail-overlay-time-status-renderer><ytd-thumbnail-overlay-now-playing-renderer class=""style-scope ytd-thumbnail""><!--css-build:shady-->
    
                <span class=""style-scope ytd-thumbnail-overlay-now-playing-renderer"">Now playing<\/span>
                    <\/ytd-thumbnail-overlay-now-playing-renderer><\/div>
                  <div id=""mouseover-overlay"" class=""style-scope ytd-thumbnail""><\/div>
                  <div id=""hover-overlays"" class=""style-scope ytd-thumbnail""><\/div>
                <\/a>
                <\/ytd-thumbnail><div id=""details"" class=""style-scope ytd-grid-video-renderer""><div id=""meta"" class=""style-scope ytd-grid-video-renderer""><h3 class=""style-scope ytd-grid-video-renderer""><ytd-badge-supported-renderer class=""style-scope ytd-grid-video-renderer"" disable-upgrade="""" hidden=""""><\/ytd-badge-supported-renderer><a id=""video-title"" class=""yt-simple-endpoint style-scope ytd-grid-video-renderer"" aria-label=""Ertugrul Ghazi Urdu | Episode 62 | Season 1 by TRT Ertugrul by PTV 4 weeks ago 48 minutes 6,496,392 views"" title="""" href=""https:\/\/www.youtube.com\/watch?v=jqu5DYc0yvU"">Ertugrul Ghazi Urdu | Episode 62 | Season 1<\/a><\/h3><div id=""metadata-container"" class=""grid style-scope ytd-grid-video-renderer"" meta-block=""""><div id=""metadata"" class=""style-scope ytd-grid-video-renderer""><div id=""byline-container"" class=""style-scope ytd-grid-video-renderer"" hidden=""""><ytd-channel-name id=""channel-name"" class=""style-scope ytd-grid-video-renderer""
                 asdasd";
        #endregion
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

        public static string GetFileNameandPathUsingDialougeBox()
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
            }
            else
            {
                MessageBox.Show("No File Selected", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            return filePath;
        }
        public static List<string> MergeTwoPlayLists(string firstFile, string secondFile)
        {
            //Read the contents of the file into a stream
            //var firstFileRaw = String.Empty;
            //string[] firstFileRawArray = String.Empty;
            //var secondFileRaw = String.Empty;
            //List<string> secondFileList = new List<string>();
            //List<string> tempList = new List<string>();
            //List<char> tempListChar = new List<string>();

            List<string> firstFileList = new List<string>();
            List<string> SecondFileList = new List<string>();

            firstFileList = File.ReadAllLines(firstFile).ToList();
            SecondFileList = File.ReadAllLines(secondFile).ToList();
            SecondFileList.Remove("#EXTM3U");

            //firstFileList.Add(SecondFileList);
            firstFileList.AddRange(SecondFileList);

            //using (StreamReader reader = new StreamReader(firstFile))
            //{
            //    tempListChar = reader.ReadToEnd().ToList();
            //    tempList = tempListChar.ToList();
            //}
            //using (StreamReader reader = new StreamReader(secondFile))
            //{
            //    secondFileRaw = reader.ReadToEnd();
            //}

            //secondFileList.Add(secondFileRaw);
            return firstFileList;
        }
    }
}