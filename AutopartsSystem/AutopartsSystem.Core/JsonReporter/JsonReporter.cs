namespace AutopartsSystem.Core
{
    using System;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;

    using Data;
    using Newtonsoft.Json;

    public class JsonReporter
    {
        public void GenerateJsonFiles(string path, AutopartsDbContext db)
        {
            // var db = new AutopartsDbContext();
            var autoParts = db.AutoParts
                .Select(x => new
                {
                    ID = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Compatibility = x.Compatibility,
                    Manufacturer = x.Manufacturer,
                    Price = x.Price,
                    Quantity = x.Quantity
                }).ToList();

            foreach (var item in autoParts)
            {
                var jsonObj = JsonConvert.SerializeObject(item, Formatting.Indented);
                var adress = path + item.ID + ".json";
                File.WriteAllText(adress, jsonObj.ToString());
            }

            Console.WriteLine("JSON file in Reports/JSON/ created.");
        }
    }
}
