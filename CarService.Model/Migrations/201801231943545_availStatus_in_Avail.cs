namespace CarService.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class availStatus_in_Avail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Avails", "AvailStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Avails", "AvailStatusId");
            AddForeignKey("dbo.Avails", "AvailStatusId", "dbo.AvailStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Avails", "AvailStatusId", "dbo.AvailStatus");
            DropIndex("dbo.Avails", new[] { "AvailStatusId" });
            DropColumn("dbo.Avails", "AvailStatusId");
        }
    }
}
