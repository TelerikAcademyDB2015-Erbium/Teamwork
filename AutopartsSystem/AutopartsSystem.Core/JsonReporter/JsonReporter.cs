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
            var autoParts = db.AutoParts.ToList();
            var mysqlParser = new MySqlConnectionProvider();


            foreach (var item in autoParts)
            {
                mysqlParser.AddContent(item);
                var jsonObj = JsonConvert.SerializeObject(item, Formatting.Indented);
                var adress = path + item.Id + ".json";
                File.WriteAllText(adress, jsonObj.ToString());
            }

            Console.WriteLine("JSON file in Reports/JSON/ created.");
        }
    }
}
