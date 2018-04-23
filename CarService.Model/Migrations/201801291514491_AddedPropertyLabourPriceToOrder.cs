namespace CarService.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropertyLabourPriceToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "LabourPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "LabourPrice");
        }
    }
}
