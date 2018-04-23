namespace CarService.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Car_nullable_Customer : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cars", new[] { "CustomerId" });
            AlterColumn("dbo.Cars", "CustomerId", c => c.Int());
            CreateIndex("dbo.Cars", "CustomerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cars", new[] { "CustomerId" });
            AlterColumn("dbo.Cars", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "CustomerId");
        }
    }
}
