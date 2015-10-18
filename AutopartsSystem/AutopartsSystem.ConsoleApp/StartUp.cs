namespace AutopartsSystem.ConsoleApp
{
    using Data;
    using Models;

    class Startup
    {
        static void Main()
        {
            var db = new AutopartsDbContext();

            db.Manufacturers.Add(new Manufacturer() { Name = "Bosch"});
        }
    }
}