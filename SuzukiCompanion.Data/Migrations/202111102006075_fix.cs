namespace SuzukiCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.IdentityRole", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IdentityRole", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
