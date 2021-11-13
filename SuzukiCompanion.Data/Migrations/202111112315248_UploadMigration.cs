namespace SuzukiCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UploadMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lesson", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lesson", "ImagePath");
        }
    }
}
