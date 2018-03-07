namespace ECS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ECSContext1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AccountTags", newName: "AccountInterestTag");
            RenameColumn(table: "dbo.AccountInterestTag", name: "Username", newName: "Account_UserName");
            RenameColumn(table: "dbo.AccountInterestTag", name: "TagName", newName: "InterestTag_TagName");
            RenameIndex(table: "dbo.AccountInterestTag", name: "IX_Username", newName: "IX_Account_UserName");
            RenameIndex(table: "dbo.AccountInterestTag", name: "IX_TagName", newName: "IX_InterestTag_TagName");
            CreateTable(
                "dbo.JWT",
                c => new
                    {
                        JWTID = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.JWTID)
                .ForeignKey("dbo.User", t => t.Email)
                .Index(t => t.Email);
            
            CreateStoredProcedure(
                "dbo.Account_Insert",
                p => new
                    {
                        UserName = p.String(maxLength: 20),
                        Email = p.String(maxLength: 128),
                        Password = p.String(maxLength: 20),
                        Points = p.Int(),
                        AccountStatus = p.Boolean(),
                        SuspensionTime = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Account]([UserName], [Email], [Password], [Points], [AccountStatus], [SuspensionTime])
                      VALUES (@UserName, @Email, @Password, @Points, @AccountStatus, @SuspensionTime)"
            );
            
            CreateStoredProcedure(
                "dbo.Account_Update",
                p => new
                    {
                        UserName = p.String(maxLength: 20),
                        Email = p.String(maxLength: 128),
                        Password = p.String(maxLength: 20),
                        Points = p.Int(),
                        AccountStatus = p.Boolean(),
                        SuspensionTime = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Account]
                      SET [Email] = @Email, [Password] = @Password, [Points] = @Points, [AccountStatus] = @AccountStatus, [SuspensionTime] = @SuspensionTime
                      WHERE ([UserName] = @UserName)"
            );
            
            CreateStoredProcedure(
                "dbo.Account_Delete",
                p => new
                    {
                        UserName = p.String(maxLength: 20),
                    },
                body:
                    @"DELETE [dbo].[Account]
                      WHERE ([UserName] = @UserName)"
            );
            
            CreateStoredProcedure(
                "dbo.InterestTag_Insert",
                p => new
                    {
                        TagName = p.String(maxLength: 128),
                    },
                body:
                    @"INSERT [dbo].[InterestTag]([TagName])
                      VALUES (@TagName)"
            );
            
            CreateStoredProcedure(
                "dbo.InterestTag_Update",
                p => new
                    {
                        TagName = p.String(maxLength: 128),
                    },
                body:
                    @"RETURN"
            );
            
            CreateStoredProcedure(
                "dbo.InterestTag_Delete",
                p => new
                    {
                        TagName = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[InterestTag]
                      WHERE ([TagName] = @TagName)"
            );
            
            CreateStoredProcedure(
                "dbo.Article_Insert",
                p => new
                    {
                        ArticleLink = p.String(maxLength: 128),
                        ArticleTitle = p.String(),
                        ArticleDescription = p.String(),
                        tag_name = p.String(maxLength: 128),
                    },
                body:
                    @"INSERT [dbo].[Article]([ArticleLink], [ArticleTitle], [ArticleDescription], [InterestTag_TagName])
                      VALUES (@ArticleLink, @ArticleTitle, @ArticleDescription, @tag_name)"
            );
            
            CreateStoredProcedure(
                "dbo.Article_Update",
                p => new
                    {
                        ArticleLink = p.String(maxLength: 128),
                        ArticleTitle = p.String(),
                        ArticleDescription = p.String(),
                        InterestTag_TagName = p.String(maxLength: 128),
                    },
                body:
                    @"UPDATE [dbo].[Article]
                      SET [ArticleTitle] = @ArticleTitle, [ArticleDescription] = @ArticleDescription, [InterestTag_TagName] = @InterestTag_TagName
                      WHERE ([ArticleLink] = @ArticleLink)"
            );
            
            CreateStoredProcedure(
                "dbo.Article_Delete",
                p => new
                    {
                        ArticleLink = p.String(maxLength: 128),
                        InterestTag_TagName = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[Article]
                      WHERE (([ArticleLink] = @ArticleLink) AND (([InterestTag_TagName] = @InterestTag_TagName) OR ([InterestTag_TagName] IS NULL AND @InterestTag_TagName IS NULL)))"
            );
            
            CreateStoredProcedure(
                "dbo.SecurityQuestionAccount_Insert",
                p => new
                    {
                        Username = p.String(maxLength: 20),
                        SecurityQuestionID = p.Int(),
                        Answer = p.String(maxLength: 100),
                    },
                body:
                    @"INSERT [dbo].[SecurityQuestionAccount]([SecurityQuestionID], [Username], [Answer])
                      VALUES (@SecurityQuestionID, @Username, @Answer)"
            );
            
            CreateStoredProcedure(
                "dbo.SecurityQuestionAccount_Update",
                p => new
                    {
                        Username = p.String(maxLength: 20),
                        SecurityQuestionID = p.Int(),
                        Answer = p.String(maxLength: 100),
                    },
                body:
                    @"UPDATE [dbo].[SecurityQuestionAccount]
                      SET [Answer] = @Answer
                      WHERE (([SecurityQuestionID] = @SecurityQuestionID) AND ([Username] = @Username))"
            );
            
            CreateStoredProcedure(
                "dbo.SecurityQuestionAccount_Delete",
                p => new
                    {
                        Username = p.String(maxLength: 20),
                        SecurityQuestionID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[SecurityQuestionAccount]
                      WHERE (([SecurityQuestionID] = @SecurityQuestionID) AND ([Username] = @Username))"
            );
            
            CreateStoredProcedure(
                "dbo.SecurityQuestion_Insert",
                p => new
                    {
                        SecurityQuestions = p.String(),
                    },
                body:
                    @"INSERT [dbo].[SecurityQuestion]([SecurityQuestions])
                      VALUES (@SecurityQuestions)
                      
                      DECLARE @SecurityQuestionID int
                      SELECT @SecurityQuestionID = [SecurityQuestionID]
                      FROM [dbo].[SecurityQuestion]
                      WHERE @@ROWCOUNT > 0 AND [SecurityQuestionID] = scope_identity()
                      
                      SELECT t0.[SecurityQuestionID]
                      FROM [dbo].[SecurityQuestion] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[SecurityQuestionID] = @SecurityQuestionID"
            );
            
            CreateStoredProcedure(
                "dbo.SecurityQuestion_Update",
                p => new
                    {
                        SecurityQuestionID = p.Int(),
                        SecurityQuestions = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[SecurityQuestion]
                      SET [SecurityQuestions] = @SecurityQuestions
                      WHERE ([SecurityQuestionID] = @SecurityQuestionID)"
            );
            
            CreateStoredProcedure(
                "dbo.SecurityQuestion_Delete",
                p => new
                    {
                        SecurityQuestionID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[SecurityQuestion]
                      WHERE ([SecurityQuestionID] = @SecurityQuestionID)"
            );
            
            CreateStoredProcedure(
                "dbo.User_Insert",
                p => new
                    {
                        Email = p.String(maxLength: 128),
                        FirstName = p.String(maxLength: 50),
                        LastName = p.String(maxLength: 50),
                    },
                body:
                    @"INSERT [dbo].[User]([Email], [FirstName], [LastName])
                      VALUES (@Email, @FirstName, @LastName)"
            );
            
            CreateStoredProcedure(
                "dbo.User_Update",
                p => new
                    {
                        Email = p.String(maxLength: 128),
                        FirstName = p.String(maxLength: 50),
                        LastName = p.String(maxLength: 50),
                    },
                body:
                    @"UPDATE [dbo].[User]
                      SET [FirstName] = @FirstName, [LastName] = @LastName
                      WHERE ([Email] = @Email)"
            );
            
            CreateStoredProcedure(
                "dbo.User_Delete",
                p => new
                    {
                        Email = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[User]
                      WHERE ([Email] = @Email)"
            );
            
            CreateStoredProcedure(
                "dbo.ZipLocation_Insert",
                p => new
                    {
                        Email = p.String(maxLength: 128),
                        ZipCode = p.String(maxLength: 10),
                        Address = p.String(),
                        City = p.String(),
                        State = p.String(),
                        Latitude = p.Int(),
                        Longitude = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[ZipLocation]([Email], [ZipCode], [Address], [City], [State], [Latitude], [Longitude])
                      VALUES (@Email, @ZipCode, @Address, @City, @State, @Latitude, @Longitude)"
            );
            
            CreateStoredProcedure(
                "dbo.ZipLocation_Update",
                p => new
                    {
                        Email = p.String(maxLength: 128),
                        ZipCode = p.String(maxLength: 10),
                        Address = p.String(),
                        City = p.String(),
                        State = p.String(),
                        Latitude = p.Int(),
                        Longitude = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[ZipLocation]
                      SET [Address] = @Address, [City] = @City, [State] = @State, [Latitude] = @Latitude, [Longitude] = @Longitude
                      WHERE (([Email] = @Email) AND ([ZipCode] = @ZipCode))"
            );
            
            CreateStoredProcedure(
                "dbo.ZipLocation_Delete",
                p => new
                    {
                        Email = p.String(maxLength: 128),
                        ZipCode = p.String(maxLength: 10),
                    },
                body:
                    @"DELETE [dbo].[ZipLocation]
                      WHERE (([Email] = @Email) AND ([ZipCode] = @ZipCode))"
            );
            
            CreateStoredProcedure(
                "dbo.AccountType_Insert",
                p => new
                    {
                        Username = p.String(maxLength: 20),
                        Permission = p.String(maxLength: 128),
                        RoleName = p.String(),
                    },
                body:
                    @"INSERT [dbo].[AccountType]([Username], [Permission], [RoleName])
                      VALUES (@Username, @Permission, @RoleName)"
            );
            
            CreateStoredProcedure(
                "dbo.AccountType_Update",
                p => new
                    {
                        Username = p.String(maxLength: 20),
                        Permission = p.String(maxLength: 128),
                        RoleName = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[AccountType]
                      SET [RoleName] = @RoleName
                      WHERE (([Username] = @Username) AND ([Permission] = @Permission))"
            );
            
            CreateStoredProcedure(
                "dbo.AccountType_Delete",
                p => new
                    {
                        Username = p.String(maxLength: 20),
                        Permission = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[AccountType]
                      WHERE (([Username] = @Username) AND ([Permission] = @Permission))"
            );
            
            CreateStoredProcedure(
                "dbo.JWT_Insert",
                p => new
                    {
                        Token = p.String(),
                        Email = p.String(maxLength: 128),
                    },
                body:
                    @"INSERT [dbo].[JWT]([Token], [Email])
                      VALUES (@Token, @Email)
                      
                      DECLARE @JWTID int
                      SELECT @JWTID = [JWTID]
                      FROM [dbo].[JWT]
                      WHERE @@ROWCOUNT > 0 AND [JWTID] = scope_identity()
                      
                      SELECT t0.[JWTID]
                      FROM [dbo].[JWT] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[JWTID] = @JWTID"
            );
            
            CreateStoredProcedure(
                "dbo.JWT_Update",
                p => new
                    {
                        JWTID = p.Int(),
                        Token = p.String(),
                        Email = p.String(maxLength: 128),
                    },
                body:
                    @"UPDATE [dbo].[JWT]
                      SET [Token] = @Token, [Email] = @Email
                      WHERE ([JWTID] = @JWTID)"
            );
            
            CreateStoredProcedure(
                "dbo.JWT_Delete",
                p => new
                    {
                        JWTID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[JWT]
                      WHERE ([JWTID] = @JWTID)"
            );
            
            CreateStoredProcedure(
                "dbo.LinkedIn_Insert",
                p => new
                    {
                        UserName = p.String(maxLength: 20),
                        AccessToken = p.String(maxLength: 2000),
                        TokenCreation = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[LinkedIn]([UserName], [AccessToken], [TokenCreation])
                      VALUES (@UserName, @AccessToken, @TokenCreation)"
            );
            
            CreateStoredProcedure(
                "dbo.LinkedIn_Update",
                p => new
                    {
                        UserName = p.String(maxLength: 20),
                        AccessToken = p.String(maxLength: 2000),
                        TokenCreation = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[LinkedIn]
                      SET [TokenCreation] = @TokenCreation
                      WHERE (([UserName] = @UserName) AND ([AccessToken] = @AccessToken))"
            );
            
            CreateStoredProcedure(
                "dbo.LinkedIn_Delete",
                p => new
                    {
                        UserName = p.String(maxLength: 20),
                        AccessToken = p.String(maxLength: 2000),
                    },
                body:
                    @"DELETE [dbo].[LinkedIn]
                      WHERE (([UserName] = @UserName) AND ([AccessToken] = @AccessToken))"
            );
            
            CreateStoredProcedure(
                "dbo.SweepStakeEntry_Insert",
                p => new
                    {
                        SweepstakesID = p.Int(),
                        UserName = p.String(maxLength: 20),
                        PurchaseDateTime = p.DateTime(),
                        Cost = p.Int(),
                        OpenDateTime = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[SweepStakeEntry]([SweepstakesID], [UserName], [PurchaseDateTime], [Cost], [OpenDateTime])
                      VALUES (@SweepstakesID, @UserName, @PurchaseDateTime, @Cost, @OpenDateTime)"
            );
            
            CreateStoredProcedure(
                "dbo.SweepStakeEntry_Update",
                p => new
                    {
                        SweepstakesID = p.Int(),
                        UserName = p.String(maxLength: 20),
                        PurchaseDateTime = p.DateTime(),
                        Cost = p.Int(),
                        OpenDateTime = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[SweepStakeEntry]
                      SET [PurchaseDateTime] = @PurchaseDateTime, [Cost] = @Cost, [OpenDateTime] = @OpenDateTime
                      WHERE (([SweepstakesID] = @SweepstakesID) AND ([UserName] = @UserName))"
            );
            
            CreateStoredProcedure(
                "dbo.SweepStakeEntry_Delete",
                p => new
                    {
                        SweepstakesID = p.Int(),
                        UserName = p.String(maxLength: 20),
                    },
                body:
                    @"DELETE [dbo].[SweepStakeEntry]
                      WHERE (([SweepstakesID] = @SweepstakesID) AND ([UserName] = @UserName))"
            );
            
            CreateStoredProcedure(
                "dbo.SweepStake_Insert",
                p => new
                    {
                        OpenDateTime = p.DateTime(),
                        ClosedDateTime = p.DateTime(),
                        Prize = p.String(),
                        UsernameWinner = p.String(maxLength: 20),
                    },
                body:
                    @"INSERT [dbo].[SweepStake]([OpenDateTime], [ClosedDateTime], [Prize], [UsernameWinner])
                      VALUES (@OpenDateTime, @ClosedDateTime, @Prize, @UsernameWinner)
                      
                      DECLARE @SweepStakesID int
                      SELECT @SweepStakesID = [SweepStakesID]
                      FROM [dbo].[SweepStake]
                      WHERE @@ROWCOUNT > 0 AND [SweepStakesID] = scope_identity()
                      
                      SELECT t0.[SweepStakesID]
                      FROM [dbo].[SweepStake] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[SweepStakesID] = @SweepStakesID"
            );
            
            CreateStoredProcedure(
                "dbo.SweepStake_Update",
                p => new
                    {
                        SweepStakesID = p.Int(),
                        OpenDateTime = p.DateTime(),
                        ClosedDateTime = p.DateTime(),
                        Prize = p.String(),
                        UsernameWinner = p.String(maxLength: 20),
                    },
                body:
                    @"UPDATE [dbo].[SweepStake]
                      SET [OpenDateTime] = @OpenDateTime, [ClosedDateTime] = @ClosedDateTime, [Prize] = @Prize, [UsernameWinner] = @UsernameWinner
                      WHERE ([SweepStakesID] = @SweepStakesID)"
            );
            
            CreateStoredProcedure(
                "dbo.SweepStake_Delete",
                p => new
                    {
                        SweepStakesID = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[SweepStake]
                      WHERE ([SweepStakesID] = @SweepStakesID)"
            );
            
            CreateStoredProcedure(
                "dbo.AccountInterestTag_Insert",
                p => new
                    {
                        Account_UserName = p.String(maxLength: 20),
                        InterestTag_TagName = p.String(maxLength: 128),
                    },
                body:
                    @"INSERT [dbo].[AccountInterestTag]([Account_UserName], [InterestTag_TagName])
                      VALUES (@Account_UserName, @InterestTag_TagName)"
            );
            
            CreateStoredProcedure(
                "dbo.AccountInterestTag_Delete",
                p => new
                    {
                        Account_UserName = p.String(maxLength: 20),
                        InterestTag_TagName = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[AccountInterestTag]
                      WHERE (([Account_UserName] = @Account_UserName) AND ([InterestTag_TagName] = @InterestTag_TagName))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.AccountInterestTag_Delete");
            DropStoredProcedure("dbo.AccountInterestTag_Insert");
            DropStoredProcedure("dbo.SweepStake_Delete");
            DropStoredProcedure("dbo.SweepStake_Update");
            DropStoredProcedure("dbo.SweepStake_Insert");
            DropStoredProcedure("dbo.SweepStakeEntry_Delete");
            DropStoredProcedure("dbo.SweepStakeEntry_Update");
            DropStoredProcedure("dbo.SweepStakeEntry_Insert");
            DropStoredProcedure("dbo.LinkedIn_Delete");
            DropStoredProcedure("dbo.LinkedIn_Update");
            DropStoredProcedure("dbo.LinkedIn_Insert");
            DropStoredProcedure("dbo.JWT_Delete");
            DropStoredProcedure("dbo.JWT_Update");
            DropStoredProcedure("dbo.JWT_Insert");
            DropStoredProcedure("dbo.AccountType_Delete");
            DropStoredProcedure("dbo.AccountType_Update");
            DropStoredProcedure("dbo.AccountType_Insert");
            DropStoredProcedure("dbo.ZipLocation_Delete");
            DropStoredProcedure("dbo.ZipLocation_Update");
            DropStoredProcedure("dbo.ZipLocation_Insert");
            DropStoredProcedure("dbo.User_Delete");
            DropStoredProcedure("dbo.User_Update");
            DropStoredProcedure("dbo.User_Insert");
            DropStoredProcedure("dbo.SecurityQuestion_Delete");
            DropStoredProcedure("dbo.SecurityQuestion_Update");
            DropStoredProcedure("dbo.SecurityQuestion_Insert");
            DropStoredProcedure("dbo.SecurityQuestionAccount_Delete");
            DropStoredProcedure("dbo.SecurityQuestionAccount_Update");
            DropStoredProcedure("dbo.SecurityQuestionAccount_Insert");
            DropStoredProcedure("dbo.Article_Delete");
            DropStoredProcedure("dbo.Article_Update");
            DropStoredProcedure("dbo.Article_Insert");
            DropStoredProcedure("dbo.InterestTag_Delete");
            DropStoredProcedure("dbo.InterestTag_Update");
            DropStoredProcedure("dbo.InterestTag_Insert");
            DropStoredProcedure("dbo.Account_Delete");
            DropStoredProcedure("dbo.Account_Update");
            DropStoredProcedure("dbo.Account_Insert");
            DropForeignKey("dbo.JWT", "Email", "dbo.User");
            DropIndex("dbo.JWT", new[] { "Email" });
            DropTable("dbo.JWT");
            RenameIndex(table: "dbo.AccountInterestTag", name: "IX_InterestTag_TagName", newName: "IX_TagName");
            RenameIndex(table: "dbo.AccountInterestTag", name: "IX_Account_UserName", newName: "IX_Username");
            RenameColumn(table: "dbo.AccountInterestTag", name: "InterestTag_TagName", newName: "TagName");
            RenameColumn(table: "dbo.AccountInterestTag", name: "Account_UserName", newName: "Username");
            RenameTable(name: "dbo.AccountInterestTag", newName: "AccountTags");
        }
    }
}
