namespace CarService.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Avails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Duration = c.Int(nullable: false),
                        LaborPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Mark = c.String(),
                        VIN = c.String(),
                        RegistrationNumber = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameAndSurname = c.String(),
                        NIP = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderStatus = c.Boolean(nullable: false),
                        InitialPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.String(),
                        DeclaredFinishDate = c.String(),
                        RealFinishDate = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Manufacturer = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsReplacement = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderAvail",
                c => new
                    {
                        OrderRefId = c.Int(nullable: false),
                        AvailRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderRefId, t.AvailRefId })
                .ForeignKey("dbo.Orders", t => t.OrderRefId, cascadeDelete: true)
                .ForeignKey("dbo.Avails", t => t.AvailRefId, cascadeDelete: true)
                .Index(t => t.OrderRefId)
                .Index(t => t.AvailRefId);
            
            CreateTable(
                "dbo.CarOrder",
                c => new
                    {
                        CarRefId = c.Int(nullable: false),
                        OrderRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CarRefId, t.OrderRefId })
                .ForeignKey("dbo.Cars", t => t.CarRefId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderRefId, cascadeDelete: true)
                .Index(t => t.CarRefId)
                .Index(t => t.OrderRefId);
            
            CreateTable(
                "dbo.AvailPart",
                c => new
                    {
                        AvailRefId = c.Int(nullable: false),
                        PartRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AvailRefId, t.PartRefId })
                .ForeignKey("dbo.Avails", t => t.AvailRefId, cascadeDelete: true)
                .ForeignKey("dbo.Parts", t => t.PartRefId, cascadeDelete: true)
                .Index(t => t.AvailRefId)
                .Index(t => t.PartRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AvailPart", "PartRefId", "dbo.Parts");
            DropForeignKey("dbo.AvailPart", "AvailRefId", "dbo.Avails");
            DropForeignKey("dbo.Avails", "CarId", "dbo.Cars");
            DropForeignKey("dbo.CarOrder", "OrderRefId", "dbo.Orders");
            DropForeignKey("dbo.CarOrder", "CarRefId", "dbo.Cars");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.OrderAvail", "AvailRefId", "dbo.Avails");
            DropForeignKey("dbo.OrderAvail", "OrderRefId", "dbo.Orders");
            DropForeignKey("dbo.Cars", "CustomerId", "dbo.Customers");
            DropIndex("dbo.AvailPart", new[] { "PartRefId" });
            DropIndex("dbo.AvailPart", new[] { "AvailRefId" });
            DropIndex("dbo.CarOrder", new[] { "OrderRefId" });
            DropIndex("dbo.CarOrder", new[] { "CarRefId" });
            DropIndex("dbo.OrderAvail", new[] { "AvailRefId" });
            DropIndex("dbo.OrderAvail", new[] { "OrderRefId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Cars", new[] { "CustomerId" });
            DropIndex("dbo.Avails", new[] { "CarId" });
            DropTable("dbo.AvailPart");
            DropTable("dbo.CarOrder");
            DropTable("dbo.OrderAvail");
            DropTable("dbo.Parts");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.Cars");
            DropTable("dbo.Avails");
        }
    }
}
