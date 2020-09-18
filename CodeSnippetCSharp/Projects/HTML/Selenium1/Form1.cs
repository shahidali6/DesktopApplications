using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Selenium
{
    public partial class Form1 : Form
    {
        string pathChromeDriver = Environment.CurrentDirectory;
        string pathFirfoxDriver = Environment.CurrentDirectory;

        //Chrome Driver initlization
        //IWebDriver driver = new ChromeDriver(pathChromeDriver);
        IWebDriver driver;
        public Form1()
        {
            InitializeComponent();
            lbStatus.Text = "Welcome to Automation World";

            //Chrome Driver initlization
            //IWebDriver driver = new ChromeDriver(pathChromeDriver);
            driver = new FirefoxDriver(pathFirfoxDriver);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string test = Environment.CurrentDirectory;
            //string pathChromeDriver = Environment.CurrentDirectory;
            //string pathFirfoxDriver = Environment.CurrentDirectory;
            ////Chrome Driver initlization
            ////IWebDriver driver = new ChromeDriver(pathChromeDriver);
            //IWebDriver driver = new FirefoxDriver(pathFirfoxDriver);

            //// This will open up the URL 
            //driver.Url = "https://www.google.org/";

            //lbStatus.Text = "URL: " + driver.Url;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // This will open up the URL 
            driver.Url = "https://www.google.org/";

            lbStatus.Text = "URL: " + driver.Url;
        }
    }
}
