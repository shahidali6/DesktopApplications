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
    }
}
