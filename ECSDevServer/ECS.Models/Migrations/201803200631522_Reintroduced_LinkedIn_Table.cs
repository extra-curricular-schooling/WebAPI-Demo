namespace ECS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reintroduced_LinkedIn_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LinkedInAccessToken",
                c => new
                    {
                        TokenId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Value = c.String(nullable: false, maxLength: 2000),
                        TokenCreation = c.DateTime(nullable: false),
                        Expired = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TokenId)
                .ForeignKey("dbo.Account", t => t.UserName, cascadeDelete: true)
                .Index(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LinkedInAccessToken", "UserName", "dbo.Account");
            DropIndex("dbo.LinkedInAccessToken", new[] { "UserName" });
            DropTable("dbo.LinkedInAccessToken");
        }
    }
}
