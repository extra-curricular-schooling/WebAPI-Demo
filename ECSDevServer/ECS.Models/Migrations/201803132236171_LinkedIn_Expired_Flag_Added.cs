namespace ECS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkedIn_Expired_Flag_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LinkedIn", "Expired", c => c.Boolean(nullable: false));
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
                      VALUES (@UserName, @AccessToken, @TokenCreation, @Expired)"
            );
            
            AlterStoredProcedure(
                "dbo.LinkedIn_Update",
                p => new
                    {
                        UserName = p.String(maxLength: 20),
                        AccessToken = p.String(maxLength: 2000),
                        TokenCreation = p.DateTime(),
                        Expired = p.Boolean(),
                    },
                body:
                    @"UPDATE [dbo].[LinkedIn]
                      SET [TokenCreation] = @TokenCreation, [Expired] = @Expired
                      WHERE (([UserName] = @UserName) AND ([AccessToken] = @AccessToken))"
            );
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.LinkedIn", "Expired");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
