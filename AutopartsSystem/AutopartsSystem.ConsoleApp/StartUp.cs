using AutopartsSystem.Core;
using AutopartsSystem.Core.Parsers.XML;
using AutopartsSystem.Core.Pdf;

namespace AutopartsSystem.ConsoleApp
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using AutopartsSystem.Core.Reporters.XML;
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

            // var autopart = new AutoPart { Id=1, Compatibility = new Compatibility(),Type = new PartType(), Description = "bla bla bla", Manufacturer = new Manufacturer { Name = "PeshoMotors" }, Quantity = 30, Price = 500, Name = "Driving wheel" };
            // db.AutoParts.Add(autopart);
            // db.SaveChanges();

            // var report = new PdfReport();
            // report.GenerateAutopartsReports(@"../../../Reports/PDF/", "joro", db);
            var columnNames = new List<string>()
            {
               "Name", "Description", "Price", "Compatibility", "Manufacturer", "Type"
            };

            // var jsonExporter = new JsonReporter();
            // jsonExporter.GenerateJsonFiles(@"../../../Reports/JSON/", db);
            var xmlReportTest = new XmlReport();
            xmlReportTest.GenerateAutoPartReport(Constants.PathToFiles + "/" + "AutoParts.xml");

            var xmlReader = new XMLToDB();
            xmlReader.ParseXmlToDb(Constants.PathToFiles + "/" + "AutoParts.xml", columnNames);
            // var zipReaderdbParser = new ZipToAutoPart();
            // zipReaderdbParser.ParseZipToDB(Constants.PathToFiles + "/Files.zip", columnNames);

            // dirReader.GetFiles(Constants.PathToFiles + "/Files.zip");
            // var parser = new XlsToAutoPart(db);
            // parser.InsertDataIntoDB();
            
        }
    }
}