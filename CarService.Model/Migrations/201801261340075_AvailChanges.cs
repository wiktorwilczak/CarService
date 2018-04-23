namespace CarService.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvailChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderAvail", "OrderRefId", "dbo.Orders");
            DropForeignKey("dbo.OrderAvail", "AvailRefId", "dbo.Avails");
            DropIndex("dbo.OrderAvail", new[] { "OrderRefId" });
            DropIndex("dbo.OrderAvail", new[] { "AvailRefId" });
            AddColumn("dbo.Avails", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Avails", "OrderId");
            AddForeignKey("dbo.Avails", "OrderId", "dbo.Orders", "Id");
            DropTable("dbo.OrderAvail");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderAvail",
                c => new
                    {
                        OrderRefId = c.Int(nullable: false),
                        AvailRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderRefId, t.AvailRefId });
            
            DropForeignKey("dbo.Avails", "OrderId", "dbo.Orders");
            DropIndex("dbo.Avails", new[] { "OrderId" });
            DropColumn("dbo.Avails", "OrderId");
            CreateIndex("dbo.OrderAvail", "AvailRefId");
            CreateIndex("dbo.OrderAvail", "OrderRefId");
            AddForeignKey("dbo.OrderAvail", "AvailRefId", "dbo.Avails", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderAvail", "OrderRefId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
