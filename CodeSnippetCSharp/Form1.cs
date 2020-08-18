using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
