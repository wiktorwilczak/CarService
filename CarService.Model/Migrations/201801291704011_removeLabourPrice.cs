namespace CarService.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeLabourPrice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Avails", "LaborPrice");
            DropColumn("dbo.Orders", "LabourPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "LabourPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Avails", "LaborPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
