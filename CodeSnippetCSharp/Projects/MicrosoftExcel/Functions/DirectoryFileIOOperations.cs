using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
