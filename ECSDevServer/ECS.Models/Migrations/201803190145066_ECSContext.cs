namespace ECS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ECSContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Article", "TagName", "dbo.InterestTag");
            DropIndex("dbo.Article", new[] { "TagName" });
            AlterColumn("dbo.Article", "TagName", c => c.String(maxLength: 128));
            CreateIndex("dbo.Article", "TagName");
            AddForeignKey("dbo.Article", "TagName", "dbo.InterestTag", "TagName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Article", "TagName", "dbo.InterestTag");
            DropIndex("dbo.Article", new[] { "TagName" });
            AlterColumn("dbo.Article", "TagName", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Article", "TagName");
            AddForeignKey("dbo.Article", "TagName", "dbo.InterestTag", "TagName", cascadeDelete: true);
        }
    }
}
