namespace CarService.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameCarNameToCarModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Model", c => c.String());
            DropColumn("dbo.Cars", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Name", c => c.String());
            DropColumn("dbo.Cars", "Model");
        }
    }
}
