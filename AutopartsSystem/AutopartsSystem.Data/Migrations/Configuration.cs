namespace AutopartsSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<AutopartsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "AutopartsSystem.Data.AutopartsDbContext";
        }

        protected override void Seed(AutopartsDbContext context)
        {
            //// This method will be called after migrating to the latest version.

            //// You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //// to avoid creating duplicate seed data. E.g.
            ////
            ////      context.People.AddOrUpdate(
            ////      p => p.FullName,
            ////      new Person { FullName = "Andrew Peters" },
            ////      new Person { FullName = "Brice Lambson" },
            ////      new Person { FullName = "Rowan Miller" }
            ////    );
            ////
        }
    }
}
