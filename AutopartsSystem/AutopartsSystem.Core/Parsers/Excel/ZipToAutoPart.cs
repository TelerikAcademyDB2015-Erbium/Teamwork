namespace AutopartsSystem.Core.Parsers.Excel
{
    using System.Collections.Generic;
    using Common;

    public class ZipToAutoPart
    {
        public void ParseZipToDB(string inputZip, IList<string> format)
        {
            var reader = new XlsReader();
            var allRows = new List<string>();
            var zipArchiver = new ZipToMultipleXls();
            var allFiles = zipArchiver.GetFiles(inputZip);
            foreach (var file in allFiles)
            {
                allRows.AddRange(reader.ProvideContent(Constants.PathToFiles + "/" + file, "Parts", format));
            }

            var parser = new StringSetToAutoPart();
            parser.InsertDataIntoDB(allRows, format);
        }
    }
}
