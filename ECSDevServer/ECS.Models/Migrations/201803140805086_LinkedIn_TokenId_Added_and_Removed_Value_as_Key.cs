namespace ECS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkedIn_TokenId_Added_and_Removed_Value_as_Key : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LinkedIn");
            AddColumn("dbo.LinkedIn", "TokenId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.LinkedIn", "TokenId");
            AlterStoredProcedure(
                "dbo.LinkedIn_Insert",
                p => new
                    {
                        UserName = p.String(maxLength: 20),
                        AccessToken = p.String(maxLength: 2000),
                        TokenCreation = p.DateTime(),
                        Expired = p.Boolean(),
                    },
                body:
                    @"INSERT [dbo].[LinkedIn]([UserName], [AccessToken], [TokenCreation], [Expired])
                      VALUES (@UserName, @AccessToken, @TokenCreation, @Expired)
                      
                      DECLARE @TokenId int
                      SELECT @TokenId = [TokenId]
                      FROM [dbo].[LinkedIn]
                      WHERE @@ROWCOUNT > 0 AND [TokenId] = scope_identity()
                      
                      SELECT t0.[TokenId]
                      FROM [dbo].[LinkedIn] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[TokenId] = @TokenId"
            );
            
            AlterStoredProcedure(
                "dbo.LinkedIn_Update",
                p => new
                    {
                        TokenId = p.Int(),
                        UserName = p.String(maxLength: 20),
                        AccessToken = p.String(maxLength: 2000),
                        TokenCreation = p.DateTime(),
                        Expired = p.Boolean(),
                    },
                body:
                    @"UPDATE [dbo].[LinkedIn]
                      SET [UserName] = @UserName, [AccessToken] = @AccessToken, [TokenCreation] = @TokenCreation, [Expired] = @Expired
                      WHERE ([TokenId] = @TokenId)"
            );
            
            AlterStoredProcedure(
                "dbo.LinkedIn_Delete",
                p => new
                    {
                        TokenId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[LinkedIn]
                      WHERE ([TokenId] = @TokenId)"
            );
            
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.LinkedIn");
            DropColumn("dbo.LinkedIn", "TokenId");
            AddPrimaryKey("dbo.LinkedIn", new[] { "UserName", "AccessToken" });
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
