namespace SuzukiCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorizationMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photo", "PhotoTitle", c => c.String(nullable: false));
            DropColumn("dbo.Photo", "VideoTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photo", "VideoTitle", c => c.String(nullable: false));
            DropColumn("dbo.Photo", "PhotoTitle");
        }
    }
}
