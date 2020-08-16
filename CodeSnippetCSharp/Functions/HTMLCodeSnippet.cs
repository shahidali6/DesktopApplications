using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            input =  Regex.Replace(input, "<.*?>",Environment.NewLine);
            input = Regex.Replace(input, @"^\s*$[\r\n]*", string.Empty, RegexOptions.Multiline);
            input = ReplaceSpecialCharacters(input);
            if (input != string.Empty)
            {
                Clipboard.SetText(input); 
            }
            return input;
        }
    }
}