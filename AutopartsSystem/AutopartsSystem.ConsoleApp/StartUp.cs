namespace AutopartsSystem.ConsoleApp
{
    using System.Data.Entity;

    using AutopartsSystem.Core.Pdf;
    using AutopartsSystem.Models;

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

            //var autopart = new AutoPart { Description = "bla bla bla", Manufacturer = new Manufacturer { Name = "PeshoMotors" }, Quantity = 30, Price = 500, Name = "Driving wheel" };
            //db.AutoParts.Add(autopart);
            //db.SaveChanges();
            //var report = new PdfReport();
            //report.GenerateAutopartsReports(@"../../../Reports/PDF/", "joro", db);

            var parser = new XlsToAutoPart(db);
            parser.InsertDataIntoDB();
        }
    }
}