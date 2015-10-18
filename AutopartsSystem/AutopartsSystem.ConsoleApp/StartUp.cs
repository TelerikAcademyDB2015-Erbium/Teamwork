namespace AutopartsSystem.ConsoleApp
{
    using System;
    using System.Linq;
    using Data;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var db = new AutopartsDbContext();

            db.Manufacturers.Add(new Manufacturer() { Name = "Bosch" });
            db.SaveChanges();
            Console.WriteLine(db.Manufacturers.Count());
        }
    }
}