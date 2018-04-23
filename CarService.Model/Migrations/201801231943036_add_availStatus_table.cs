namespace CarService.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_availStatus_table : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AvailStatus");
        }
    }
}
