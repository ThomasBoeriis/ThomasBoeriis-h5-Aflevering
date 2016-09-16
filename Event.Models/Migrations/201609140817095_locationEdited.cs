namespace Event.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationEdited : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "FK_Location", "dbo.Location");
            DropIndex("dbo.Events", new[] { "FK_Location" });
            AddColumn("dbo.Events", "Location_Id", c => c.Int());
            CreateIndex("dbo.Events", "Location_Id");
            AddForeignKey("dbo.Events", "Location_Id", "dbo.Location", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Location_Id", "dbo.Location");
            DropIndex("dbo.Events", new[] { "Location_Id" });
            DropColumn("dbo.Events", "Location_Id");
            CreateIndex("dbo.Events", "FK_Location");
            AddForeignKey("dbo.Events", "FK_Location", "dbo.Location", "Id");
        }
    }
}
