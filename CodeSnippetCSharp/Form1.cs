using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeSnippetCSharp;
using CodeSnippetCSharp.Functions;

namespace CodeSnippetCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbResultData.Text = HTMLCodeSnippet.RemoveHTMLTagsFromString(tbRawData.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbRawData.Text =  string.Empty;
            tbResultData.Text =  string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tbResultData.Text = HTMLCodeSnippet.RemoveHTMLTagsFromStringNewLine(tbRawData.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            tbResultData.Text = string.Join(Environment.NewLine, HTMLCodeSnippet.ExtractYouTubeVideoURLs(tbRawData.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fileContent = string.Empty;
            fileContent = HTMLCodeSnippet.ReadTextFileUsingDialougeBox();
            tbResultData.Text = string.Join(Environment.NewLine, HTMLCodeSnippet.ExtractYouTubeVideoURLs(fileContent));
            tbRawData.Text = "Extract URL using file";
        }

        private void cbRawDataOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRawDataOptions.SelectedIndex > -1)
            {
                if (cbRawDataOptions.SelectedIndex == 0)
                {
                    //cbRawDataOptions.SelectedIndex = HTMLCodeSnippet.
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbRawData.Text =  HTMLCodeSnippet.ReadTextFileUsingDialougeBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tbResultData.Text = HTMLCodeSnippet.ReadTextFileUsingDialougeBox();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //var returnList = HTMLCodeSnippet.MergeTwoPlayLists(HTMLCodeSnippet.GetFileNameandPathUsingDialougeBox(), HTMLCodeSnippet.GetFileNameandPathUsingDialougeBox());
            var returnList = HTMLCodeSnippet.MergeTwoPlayLists(@"C: \Users\Shahid\source\repos\shahidali6\CodeSnippetCSharp\CodeSnippetCSharp\bin\Debug\60S - Selected - Soft.m3u8", @"C: \Users\Shahid\source\repos\shahidali6\CodeSnippetCSharp\CodeSnippetCSharp\bin\Debug\60S - Selected - Soft 2.m3u8");

            

            foreach (var item in returnList)
            {
                tbResultData.Text += item.ToString();
                tbResultData.Text += Environment.NewLine;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //tbResultData.Text = MSWord.ModifyMSWordDoc(@"F:\Dropbox\Project\DOCX", "*.docx");
            var returnList = DirectoryFileIOOperations.GetFileNamesinList(@"F:\Dropbox\Project\DOCX - Copy", "*.docx");

            foreach (var item in returnList)
            {
                tbResultData.Text += item.ToString();
                tbResultData.Text += Environment.NewLine;
                MSWord.ModifyMSWordDoc(item);
            }
        }
    }
}
