using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeSnippetCSharp
{
    class DirectoryFileIOOperations
    {
        public static List<string> GetFileNamesinList(string folderPath, string fileExtenstion)
        {
            List<string> listAllFiles = new List<string>();
            listAllFiles = Directory.GetFiles(folderPath, fileExtenstion).ToList();

            return listAllFiles;
        }
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

        public static string ReadTextFileDirect(string fileNameandPath)
        {
            var fileContent = string.Empty;

            using (StreamReader reader = new StreamReader(fileNameandPath))
            {
                fileContent = reader.ReadToEnd();
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
        public static bool WriteTextFileOncefromString(string path, string fileandExtenstion, string dataToWrite)
        {
            bool fileSTatus = false;
            try
            {
                bool exists = System.IO.Directory.Exists(path);

                if (!exists)
                    System.IO.Directory.CreateDirectory(path);


                //If the target file already exists, it is overwritten.
                System.IO.File.WriteAllText(path+ fileandExtenstion, dataToWrite);
                fileSTatus = true;
            }
            catch (Exception ex)
            {
                fileSTatus = false;

                MessageBox.Show("Message: " + ex, "Exception Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return fileSTatus;
        }
        public static bool WriteTextFileOncefromArray(string pathandExtenstion, string[] dataToWrite)
        {
            bool fileSTatus = false;
            try
            {
                //If the target file already exists, it is overwritten.
                System.IO.File.WriteAllLines(pathandExtenstion, dataToWrite);
                fileSTatus = true;
            }
            catch (Exception ex)
            {
                fileSTatus = false;

                MessageBox.Show("Message: " + ex, "Exception Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return fileSTatus;
        }
    }
}
