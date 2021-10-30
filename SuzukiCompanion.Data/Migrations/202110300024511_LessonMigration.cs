namespace SuzukiCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LessonMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lesson", "LessonName", c => c.String(nullable: false));
            AddColumn("dbo.Lesson", "Contents", c => c.String());
            DropColumn("dbo.Lesson", "LessonTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lesson", "LessonTitle", c => c.String(nullable: false));
            DropColumn("dbo.Lesson", "Contents");
            DropColumn("dbo.Lesson", "LessonName");
        }
    }
}
