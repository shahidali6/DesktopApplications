using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;

namespace SetupExeToZip
{
    class Program
    {
        const string setupInitial = "Setup";
        const string exeType = "*.exe";
        const string nameModbusTerminal = "Modbus Terminal";
        const string nameLicensingTool = "Licensing Tool";
        string statusMessage = string.Empty;
        static void Main(string[] args)
        {
            List<string> allSetupFiles = new List<string>();
            string currentDirectory = Directory.GetCurrentDirectory();

            string[] allFileArray = Directory.GetFiles(currentDirectory, exeType, SearchOption.AllDirectories);
            foreach (var item in allFileArray)
            {
                string fileName = Path.GetFileName(item);
                if (!fileName.StartsWith(setupInitial))
                {
                    continue;
                }
                allSetupFiles.Add(item);
            }
            foreach (var item in allSetupFiles)
            {
                string message = string.Empty;
                bool statusMessage = CreateZipFile(item, out message);
                Console.WriteLine(message + "- Status " +statusMessage);
            }
        }

        private static bool CreateZipFile(string itemName, out string returnMessage)
        {
            bool status = false;
            returnMessage = "Message:- ";
            string returnStatusMessage = returnMessage;
            try
            {
                string zipExtName = ".zip";
                //string space = " ";
                string fileNamewithExt = Path.GetFileName(itemName);
                string lastFolderName = Path.GetFileName(Path.GetDirectoryName(itemName));
                //string fileExt = Path.GetExtension(itemName);
                string fileNamewithOutExt = Path.GetFileNameWithoutExtension(itemName);
                fileNamewithOutExt = fileNamewithOutExt.Replace(setupInitial, lastFolderName);

                string zipPath = fileNamewithOutExt + zipExtName;

                string newZipPath = itemName.Replace(fileNamewithExt, zipPath);

                if (fileNamewithOutExt.StartsWith(nameModbusTerminal) || fileNamewithOutExt.StartsWith(nameLicensingTool))
                {
                    if (File.Exists(newZipPath))
                    {
                        returnMessage += returnMessage + "Zip file already exist.";
                        return status;
                    }
                    using (var zipArchive = ZipFile.Open(newZipPath, ZipArchiveMode.Update))
                    {
                        //zipArchive.CreateEntryFromFile(itemName, fileNamewithExt);
                        zipArchive.CreateEntryFromFile(itemName, fileNamewithExt);
                        returnMessage += returnMessage + "File Created succefully.";
                        return true;
                    }
                }
                returnMessage += returnMessage + "Zip file not created.";
                return status;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message:- " + ex);
                returnMessage += returnMessage + "Application generate Exception.";
                Console.ReadLine();
                return status;
            }            
        }
    }
}