using System;
using System.Data.Entity;
using System.Linq;
using AutopartsSystem.Data;
using AutopartsSystem.Data.Migrations;
using AutopartsSystem.Models;

namespace AutopartsSystem.Core.Parsers.Excel
{
    using System.Collections.Generic;
    using Common;

    public class XlsToAutoPart
    {
        private AutopartsDbContext db;

        public XlsToAutoPart(AutopartsDbContext database)
        {
            this.db = database;
        }

        public void InsertDataIntoDB()
        {
            var theReader = new XlsReader();

            var pathToTheXLS = Constants.PathToFiles + "/1.xls";
            var columnNames = new List<string>()
            {
                "Name", "Description", "Price", "Compatibility", "Manufacturer", "Type"
            };
            var sheetName = "Parts";

            var contentToAdd = theReader.ProvideContent(pathToTheXLS, sheetName, columnNames);

            int indexForName = columnNames.IndexOf("Name");
            int indexForDescription = columnNames.IndexOf("Description");
            int indexForPrice = columnNames.IndexOf("Price");
            int indexForCompatibility = columnNames.IndexOf("Compatibility");
            int indexForManufacturer = columnNames.IndexOf("Manufacturer");
            int indexForType = columnNames.IndexOf("Type");


            foreach (var singleRow in contentToAdd)
            {
                var rowEntities = singleRow.Split(new[] { Constants.DividerForExcelRead }, StringSplitOptions.None);
                var autoPartObject = new AutoPart();

                //{
                //    Name = rowEntities[indexForName],
                //    Description = rowEntities[indexForDescription],
                //    Price = decimal.Parse(rowEntities[indexForPrice]),
                //    Compatibility = this.db.Compatibilities.Find(int.Parse(rowEntities[indexForCompatibility])),
                //    Manufacturer = this.db.Manufacturers.Find(int.Parse(rowEntities[indexForManufacturer])),
                //    Type = this.db.PartTypes.Find(int.Parse(rowEntities[indexForType])),
                //    BuiltOn = DateTime.Now,
                //    ManufacturerId = int.Parse(rowEntities[indexForManufacturer]),
                //    Quantity = 0
                //};
                autoPartObject.Name = rowEntities[indexForName];
                autoPartObject.Description = rowEntities[indexForDescription];
                autoPartObject.Price = decimal.Parse(rowEntities[indexForPrice]);
                autoPartObject.Compatibility = db.Compatibilities.Find(int.Parse(rowEntities[indexForCompatibility]));
                autoPartObject.Manufacturer = db.Manufacturers.Find(int.Parse(rowEntities[indexForManufacturer]));
                autoPartObject.Type = db.PartTypes.Find(int.Parse(rowEntities[indexForType]));
                autoPartObject.BuiltOn = DateTime.Now;

                db.AutoParts.Add(autoPartObject);
                db.SaveChanges();
            }
        }
    }
}
