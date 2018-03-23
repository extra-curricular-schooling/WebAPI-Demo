namespace ECS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_ExpiredAccessToken : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ExpiredAccessToken");
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
            
            AddColumn("dbo.ExpiredAccessToken", "ExpiredTokenId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ExpiredAccessToken", "ExpiredTokenValue", c => c.String(nullable: false));
            AddColumn("dbo.ExpiredAccessToken", "CanReuse", c => c.Boolean(nullable: false));
            AddPrimaryKey("dbo.ExpiredAccessToken", "ExpiredTokenId");
            DropColumn("dbo.ExpiredAccessToken", "Token");
            AlterStoredProcedure(
                "dbo.ExpiredAccessToken_Insert",
                p => new
                    {
                        ExpiredTokenValue = p.String(),
                        CanReuse = p.Boolean(),
                    },
                body:
                    @"INSERT [dbo].[ExpiredAccessToken]([ExpiredTokenValue], [CanReuse])
                      VALUES (@ExpiredTokenValue, @CanReuse)
                      
                      DECLARE @ExpiredTokenId int
                      SELECT @ExpiredTokenId = [ExpiredTokenId]
                      FROM [dbo].[ExpiredAccessToken]
                      WHERE @@ROWCOUNT > 0 AND [ExpiredTokenId] = scope_identity()
                      
                      SELECT t0.[ExpiredTokenId]
                      FROM [dbo].[ExpiredAccessToken] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ExpiredTokenId] = @ExpiredTokenId"
            );
            
            AlterStoredProcedure(
                "dbo.ExpiredAccessToken_Update",
                p => new
                    {
                        ExpiredTokenId = p.Int(),
                        ExpiredTokenValue = p.String(),
                        CanReuse = p.Boolean(),
                    },
                body:
                    @"UPDATE [dbo].[ExpiredAccessToken]
                      SET [ExpiredTokenValue] = @ExpiredTokenValue, [CanReuse] = @CanReuse
                      WHERE ([ExpiredTokenId] = @ExpiredTokenId)"
            );
            
            AlterStoredProcedure(
                "dbo.ExpiredAccessToken_Delete",
                p => new
                    {
                        ExpiredTokenId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[ExpiredAccessToken]
                      WHERE ([ExpiredTokenId] = @ExpiredTokenId)"
            );
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExpiredAccessToken", "Token", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.LinkedInAccessToken", "UserName", "dbo.Account");
            DropIndex("dbo.LinkedInAccessToken", new[] { "UserName" });
            DropPrimaryKey("dbo.ExpiredAccessToken");
            DropColumn("dbo.ExpiredAccessToken", "CanReuse");
            DropColumn("dbo.ExpiredAccessToken", "ExpiredTokenValue");
            DropColumn("dbo.ExpiredAccessToken", "ExpiredTokenId");
            DropTable("dbo.LinkedInAccessToken");
            AddPrimaryKey("dbo.ExpiredAccessToken", "Token");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
