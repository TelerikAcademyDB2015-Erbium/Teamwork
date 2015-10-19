namespace AutopartsSystem.ConsoleApp
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using Core.Common;
    using Core.Parsers.Excel;
    using Data;
    using Data.Migrations;

    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AutopartsDbContext, Configuration>());
            var db = new AutopartsDbContext();

            // db.Manufacturers.Add(new Manufacturer() { Name = "Bosch" });
            // db.SaveChanges();
            // Console.WriteLine(db.Manufacturers.Count());

            // ZipFile zipFile = new ZipFile(Constants.PathToFiles + "/Files.zip");
            // zipFile.ExtractAll(Constants.PathToFiles + "/Extracted/");
            // Console.WriteLine(Constants.PathToFiles);
            var theReader = new XlsReader();

            var pathToTheXLS = Constants.PathToFiles + "/1.xls";
            var columnNames = new List<string>()
            {
                "Name", "Description", "Price", "Compatibility", "Manufacturer", "Type"
            };
            var sheetName = "Parts";

            var contentToAdd = theReader.ProvideContent(pathToTheXLS, sheetName, columnNames);
        }
    }
}