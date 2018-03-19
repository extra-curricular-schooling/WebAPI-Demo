namespace ECS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Account_Changes_to_Store_Hashed_Password : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Account", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterStoredProcedure(
                "dbo.Account_Insert",
                p => new
                    {
                        UserName = p.String(maxLength: 20),
                        Email = p.String(maxLength: 128),
                        Password = p.String(maxLength: 50),
                        Points = p.Int(),
                        AccountStatus = p.Boolean(),
                        SuspensionTime = p.DateTime(),
                        FirstTimeUser = p.Boolean(),
                    },
                body:
                    @"INSERT [dbo].[Account]([UserName], [Email], [Password], [Points], [AccountStatus], [SuspensionTime], [FirstTimeUser])
                      VALUES (@UserName, @Email, @Password, @Points, @AccountStatus, @SuspensionTime, @FirstTimeUser)"
            );
            
            AlterStoredProcedure(
                "dbo.Account_Update",
                p => new
                    {
                        UserName = p.String(maxLength: 20),
                        Email = p.String(maxLength: 128),
                        Password = p.String(maxLength: 50),
                        Points = p.Int(),
                        AccountStatus = p.Boolean(),
                        SuspensionTime = p.DateTime(),
                        FirstTimeUser = p.Boolean(),
                    },
                body:
                    @"UPDATE [dbo].[Account]
                      SET [Email] = @Email, [Password] = @Password, [Points] = @Points, [AccountStatus] = @AccountStatus, [SuspensionTime] = @SuspensionTime, [FirstTimeUser] = @FirstTimeUser
                      WHERE ([UserName] = @UserName)"
            );
            
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Account", "Password", c => c.String(nullable: false, maxLength: 20));
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
