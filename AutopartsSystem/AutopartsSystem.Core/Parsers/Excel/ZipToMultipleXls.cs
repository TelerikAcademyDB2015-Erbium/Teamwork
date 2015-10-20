namespace AutopartsSystem.Core.Parsers.Excel
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Common;
    using Ionic.Zip;

    public class ZipToMultipleXls
    {
        public IEnumerable<string> GetFiles(string pathToZip)
        {
            ZipFile zipFile = new ZipFile(pathToZip);
            var dirWithFiles = Constants.PathToFiles + "/Extracted/";
            zipFile.ExtractAll(dirWithFiles);
            string[] allFiles = Directory.GetFiles(Constants.PathToFiles + "/Extracted/", "*.xls")
                                     .Select(path => Path.GetFileName(path))
                                     .ToArray();
            this.ClearFolder(dirWithFiles);
            return allFiles;
        }

        private void ClearFolder(string folderName)
        {
            DirectoryInfo dir = new DirectoryInfo(folderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                this.ClearFolder(di.FullName);
                di.Delete();
            }
        }
    }
}
