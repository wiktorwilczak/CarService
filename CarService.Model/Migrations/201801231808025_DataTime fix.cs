namespace CarService.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataTimefix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orders", "DeclaredFinishDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orders", "RealFinishDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "RealFinishDate", c => c.String());
            AlterColumn("dbo.Orders", "DeclaredFinishDate", c => c.String());
            AlterColumn("dbo.Orders", "OrderDate", c => c.String());
        }
    }
}
