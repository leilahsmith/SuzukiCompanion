namespace SuzukiCompanion.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleAdjust : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IdentityRole", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.IdentityRole", "Discriminator");
        }
    }
}
