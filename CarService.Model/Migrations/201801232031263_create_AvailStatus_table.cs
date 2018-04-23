namespace CarService.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_AvailStatus_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Avails", "AvailStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Avails", "AvailStatusId");
            AddForeignKey("dbo.Avails", "AvailStatusId", "dbo.AvailStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Avails", "AvailStatusId", "dbo.AvailStatus");
            DropIndex("dbo.Avails", new[] { "AvailStatusId" });
            DropColumn("dbo.Avails", "AvailStatusId");
            DropTable("dbo.AvailStatus");
        }
    }
}
