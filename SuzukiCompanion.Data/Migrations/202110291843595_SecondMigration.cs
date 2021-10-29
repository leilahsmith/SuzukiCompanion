namespace SuzukiCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.Student", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "BirthDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Student", "Age");
        }
    }
}
