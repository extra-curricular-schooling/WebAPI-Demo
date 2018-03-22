namespace ECS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime_Added_To_JAccessToken : DbMigration
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
            
            AddColumn("dbo.JAccessToken", "DateTimeIssued", c => c.DateTime(nullable: false));
            AlterStoredProcedure(
                "dbo.JAccessToken_Insert",
                p => new
                    {
                        Value = p.String(),
                        UserName = p.String(maxLength: 20),
                        DateTimeIssued = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[JAccessToken]([UserName], [Value], [DateTimeIssued])
                      VALUES (@UserName, @Value, @DateTimeIssued)
                      
                      DECLARE @TokenId int
                      SELECT @TokenId = [TokenId]
                      FROM [dbo].[JAccessToken]
                      WHERE @@ROWCOUNT > 0 AND [TokenId] = scope_identity()
                      
                      SELECT t0.[TokenId]
                      FROM [dbo].[JAccessToken] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[TokenId] = @TokenId"
            );
            
            AlterStoredProcedure(
                "dbo.JAccessToken_Update",
                p => new
                    {
                        TokenId = p.Int(),
                        Value = p.String(),
                        UserName = p.String(maxLength: 20),
                        DateTimeIssued = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[JAccessToken]
                      SET [UserName] = @UserName, [Value] = @Value, [DateTimeIssued] = @DateTimeIssued
                      WHERE ([TokenId] = @TokenId)"
            );
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LinkedInAccessToken", "UserName", "dbo.Account");
            DropIndex("dbo.LinkedInAccessToken", new[] { "UserName" });
            DropColumn("dbo.JAccessToken", "DateTimeIssued");
            DropTable("dbo.LinkedInAccessToken");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
