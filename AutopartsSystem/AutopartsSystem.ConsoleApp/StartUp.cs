namespace AutopartsSystem.ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.OleDb;
    using System.Text;

    using AutopartsSystem.Core.Pdf;
    using AutopartsSystem.Data;
    using AutopartsSystem.Data.Migrations;
    using AutopartsSystem.Models;
    using Core.Common;
    using Ionic.Zip;

    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AutopartsDbContext, Configuration>());
            var db = new AutopartsDbContext();
            var autopart = new AutoPart { Description = "bla bla bla", Manufacturer = new Manufacturer { Name = "PeshoMotors" }, Quantity = 30, Price = 500,Name = "Driving wheel"};
            db.AutoParts.Add(autopart);           
            db.SaveChanges();
            var report =new PdfReport();
            report.GenerateAutopartsReports(@"../../../Reports/PDF/","joro",db);
            
            //// ZipFile zipFile = new ZipFile(Constants.PathToFiles + "/Files.zip");
            //// zipFile.ExtractAll(Constants.PathToFiles + "/Extracted/");
            //// Console.WriteLine(Constants.PathToFiles);

            //    Dictionary<string, string> props = new Dictionary<string, string>();
            //    props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            //    props["Data Source"] = Constants.PathToFiles + "/1.xls";
            //    props["Extended Properties"] = "Excel 8.0";
            //    var columnNames = new List<string>()
            //    {
            //        "Name", "Description", "Price", "Compatibility", "Manufacturer", "Type"
            //    };

            //    StringBuilder sb = new StringBuilder();
            //    foreach (KeyValuePair<string, string> prop in props)
            //    {
            //        sb.Append(prop.Key);
            //        sb.Append('=');
            //        sb.Append(prop.Value);
            //        sb.Append(';');
            //    }

            //    string properties = sb.ToString();

            //    using (OleDbConnection conn = new OleDbConnection(properties))
            //    {
            //        conn.Open();
            //        DataSet ds = new DataSet();
            //        string columns = string.Join(",", columnNames.ToArray());
            //        using (OleDbDataAdapter da = new OleDbDataAdapter(
            //            "SELECT " + columns + " FROM [" + "People" + "$]", conn))
            //        {
            //            DataTable dt = new DataTable("temp");
            //            da.Fill(dt);
            //            var mhm = dt.Rows[0];
            //            ds.Tables.Add(dt);
            //        }
            //    }
        }
    }
}