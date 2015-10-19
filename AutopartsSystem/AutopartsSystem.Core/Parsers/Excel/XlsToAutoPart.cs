namespace AutopartsSystem.Core.Parsers.Excel
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Data;
    using Models;

    public class XlsToAutoPart
    {
        private AutopartsDbContext db;

        public XlsToAutoPart()
        {
            this.db = new AutopartsDbContext();
        }

        public XlsToAutoPart(AutopartsDbContext database) : this()
        {
            this.db = database;
        }

        public void InsertDataIntoDB(IEnumerable<string> content, IList<string> format)
        {
            int indexForName = format.IndexOf("Name");
            int indexForDescription = format.IndexOf("Description");
            int indexForPrice = format.IndexOf("Price");
            int indexForCompatibility = format.IndexOf("Compatibility");
            int indexForManufacturer = format.IndexOf("Manufacturer");
            int indexForType = format.IndexOf("Type");
            int iterations = 0;

            foreach (var singleRow in content)
            {
                var rowEntities = singleRow.Split(new[] { Constants.DividerForExcelRead }, StringSplitOptions.None);
                var autoPartObject = new AutoPart();
                autoPartObject.Name = rowEntities[indexForName];
                autoPartObject.Description = rowEntities[indexForDescription];
                autoPartObject.Price = decimal.Parse(rowEntities[indexForPrice]);
                autoPartObject.Compatibility = this.db.Compatibilities.Find(int.Parse(rowEntities[indexForCompatibility]));
                autoPartObject.Manufacturer = this.db.Manufacturers.Find(int.Parse(rowEntities[indexForManufacturer]));
                autoPartObject.Type = this.db.PartTypes.Find(int.Parse(rowEntities[indexForType]));
                autoPartObject.BuiltOn = DateTime.Now;

                if (iterations % 100 == 0)
                {
                    this.db.SaveChanges();
                    this.db.Dispose();
                    this.db = new AutopartsDbContext();
                }

                this.db.AutoParts.Add(autoPartObject);
                iterations++;
            }

            this.db.SaveChanges();
        }
    }
}
