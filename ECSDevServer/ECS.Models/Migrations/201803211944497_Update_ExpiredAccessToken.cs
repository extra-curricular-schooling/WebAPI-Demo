namespace ECS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_ExpiredAccessToken : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ExpiredAccessToken");
            AddColumn("dbo.ExpiredAccessToken", "ExpiredTokenId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ExpiredAccessToken", "ExpiredTokenValue", c => c.String(nullable: false));
            AddPrimaryKey("dbo.ExpiredAccessToken", "ExpiredTokenId");
            DropColumn("dbo.ExpiredAccessToken", "Token");
            AlterStoredProcedure(
                "dbo.ExpiredAccessToken_Insert",
                p => new
                    {
                        ExpiredTokenValue = p.String(),
                    },
                body:
                    @"DECLARE @generated_keys table([ExpiredTokenId] nvarchar(128))
                      INSERT [dbo].[ExpiredAccessToken]([ExpiredTokenValue])
                      OUTPUT inserted.[ExpiredTokenId] INTO @generated_keys
                      VALUES (@ExpiredTokenValue)
                      
                      DECLARE @ExpiredTokenId nvarchar(128)
                      SELECT @ExpiredTokenId = t.[ExpiredTokenId]
                      FROM @generated_keys AS g JOIN [dbo].[ExpiredAccessToken] AS t ON g.[ExpiredTokenId] = t.[ExpiredTokenId]
                      WHERE @@ROWCOUNT > 0
                      
                      SELECT t0.[ExpiredTokenId]
                      FROM [dbo].[ExpiredAccessToken] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ExpiredTokenId] = @ExpiredTokenId"
            );
            
            AlterStoredProcedure(
                "dbo.ExpiredAccessToken_Update",
                p => new
                    {
                        ExpiredTokenId = p.String(maxLength: 128),
                        ExpiredTokenValue = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[ExpiredAccessToken]
                      SET [ExpiredTokenValue] = @ExpiredTokenValue
                      WHERE ([ExpiredTokenId] = @ExpiredTokenId)"
            );
            
            AlterStoredProcedure(
                "dbo.ExpiredAccessToken_Delete",
                p => new
                    {
                        ExpiredTokenId = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[ExpiredAccessToken]
                      WHERE ([ExpiredTokenId] = @ExpiredTokenId)"
            );
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExpiredAccessToken", "Token", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.ExpiredAccessToken");
            DropColumn("dbo.ExpiredAccessToken", "ExpiredTokenValue");
            DropColumn("dbo.ExpiredAccessToken", "ExpiredTokenId");
            AddPrimaryKey("dbo.ExpiredAccessToken", "Token");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
