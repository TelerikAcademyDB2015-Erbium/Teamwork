namespace AutopartsSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutoParts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        BuiltOn = c.DateTime(),
                        SoldOn = c.DateTime(),
                        Compatibility_Id = c.Int(),
                        Manufacturer_Id = c.Int(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compatibilities", t => t.Compatibility_Id)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_Id)
                .ForeignKey("dbo.PartTypes", t => t.Type_Id)
                .Index(t => t.Compatibility_Id)
                .Index(t => t.Manufacturer_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.Compatibilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand_Id = c.Int(),
                        Model_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarBrands", t => t.Brand_Id)
                .ForeignKey("dbo.CarModels", t => t.Model_Id)
                .Index(t => t.Brand_Id)
                .Index(t => t.Model_Id);
            
            CreateTable(
                "dbo.CarBrands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Brand_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarBrands", t => t.Brand_Id)
                .Index(t => t.Brand_Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PartTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AutoParts", "Type_Id", "dbo.PartTypes");
            DropForeignKey("dbo.AutoParts", "Manufacturer_Id", "dbo.Manufacturers");
            DropForeignKey("dbo.AutoParts", "Compatibility_Id", "dbo.Compatibilities");
            DropForeignKey("dbo.Compatibilities", "Model_Id", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "Brand_Id", "dbo.CarBrands");
            DropForeignKey("dbo.Compatibilities", "Brand_Id", "dbo.CarBrands");
            DropIndex("dbo.CarModels", new[] { "Brand_Id" });
            DropIndex("dbo.Compatibilities", new[] { "Model_Id" });
            DropIndex("dbo.Compatibilities", new[] { "Brand_Id" });
            DropIndex("dbo.AutoParts", new[] { "Type_Id" });
            DropIndex("dbo.AutoParts", new[] { "Manufacturer_Id" });
            DropIndex("dbo.AutoParts", new[] { "Compatibility_Id" });
            DropTable("dbo.PartTypes");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.CarModels");
            DropTable("dbo.CarBrands");
            DropTable("dbo.Compatibilities");
            DropTable("dbo.AutoParts");
        }
    }
}
