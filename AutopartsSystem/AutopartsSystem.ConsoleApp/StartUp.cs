
namespace AutopartsSystem.ConsoleApp
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using Core.Parsers.XML;
    using Core.Common;
    using Data;
    using Data.Migrations;
    using Core.Parsers.Excel;

    public class Startup
    {
        public static void Main()
        {
            // TODO: Test all of parsers and reports again

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AutopartsDbContext, Configuration>());
            var db = new AutopartsDbContext();

            // db.Manufacturers.Add(new Manufacturer() { Name = "Bosch" });
            // db.SaveChanges();
            // Console.WriteLine(db.Manufacturers.Count());

            //ZipFile zipFile = new ZipFile(Constants.PathToFiles + "/Files.zip");
            //zipFile.ExtractAll(Constants.PathToFiles + "/Extracted/");
            //Console.WriteLine(Constants.PathToFiles);

            // var autopart = new AutoPart { Id=1, Compatibility = new Compatibility(),Type = new PartType(), Description = "bla bla bla", Manufacturer = new Manufacturer { Name = "PeshoMotors" }, Quantity = 30, Price = 500, Name = "Driving wheel" };
            // db.AutoParts.Add(autopart);
            // db.SaveChanges();

            //var report = new PdfReport();
            //report.GenerateAutopartsReports(Constants.PathForCreatedPDFReports, "joro", db);

            var columnNames = new List<string>()
            {
               "Name", "Description", "Price", "Compatibility", "Manufacturer", "Type"
            };

            //var jsonExporter = new JsonReporter();
            //jsonExporter.GenerateJsonFiles(Constants.PathForCreatedJsonReports, db);

            //var xmlReportTest = new XmlReport();
            //xmlReportTest.GenerateAutoPartReport(Constants.PathForCreatedXMLReports + "/" + "AutoParts.xml");

            //var xmlReader = new XMLToDB();
            //xmlReader.ParseXmlToDb(Constants.PathToFiles + "/" + "AutoParts.xml", columnNames);

            //var zipReaderdbParser = new ZipToAutoPart();
            // zipReaderdbParser.ParseZipToDB(Constants.PathToFiles + "/Files.zip", columnNames);

            // dirReader.GetFiles(Constants.PathToFiles + "/Files.zip");

            // var parser = new XlsToAutoPart(db);
            // parser.InsertDataIntoDB();

        }
    }
}