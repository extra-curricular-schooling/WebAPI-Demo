namespace ECS.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ECSContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 50),
                        Points = c.Int(nullable: false),
                        AccountStatus = c.Boolean(nullable: false),
                        SuspensionTime = c.DateTime(nullable: false),
                        FirstTimeUser = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserName)
                .ForeignKey("dbo.User", t => t.Email, cascadeDelete: true)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.InterestTag",
                c => new
                    {
                        TagName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TagName);
            
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ArticleLink = c.String(nullable: false, maxLength: 128),
                        ArticleTitle = c.String(nullable: false),
                        ArticleDescription = c.String(),
                        TagName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ArticleLink)
                .ForeignKey("dbo.InterestTag", t => t.TagName)
                .Index(t => t.TagName);
            
            CreateTable(
                "dbo.SecurityQuestionAccount",
                c => new
                    {
                        SecurityQuestionID = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 20),
                        Answer = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => new { t.SecurityQuestionID, t.Username })
                .ForeignKey("dbo.SecurityQuestion", t => t.SecurityQuestionID, cascadeDelete: true)
                .ForeignKey("dbo.Account", t => t.Username, cascadeDelete: true)
                .Index(t => t.SecurityQuestionID)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.SecurityQuestion",
                c => new
                    {
                        SecurityQuestionID = c.Int(nullable: false, identity: true),
                        SecQuestion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SecurityQuestionID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.ZipLocation",
                c => new
                    {
                        ZipCodeId = c.Int(nullable: false, identity: true),
                        ZipCode = c.String(nullable: false, maxLength: 10),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Latitude = c.Int(nullable: false),
                        Longitude = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZipCodeId);
            
            CreateTable(
                "dbo.AccountType",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 20),
                        PermissionName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Username, t.PermissionName })
                .ForeignKey("dbo.Account", t => t.Username, cascadeDelete: true)
                .ForeignKey("dbo.Permission", t => t.PermissionName, cascadeDelete: true)
                .Index(t => t.Username)
                .Index(t => t.PermissionName);
            
            CreateTable(
                "dbo.Permission",
                c => new
                    {
                        PermissionName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PermissionName);
            
            CreateTable(
                "dbo.JAccessToken",
                c => new
                    {
                        UserName = c.String(maxLength: 20),
                        TokenId = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TokenId)
                .ForeignKey("dbo.Account", t => t.UserName)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.Salt",
                c => new
                    {
                        SaltId = c.Int(nullable: false, identity: true),
                        PasswordSalt = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.SaltId)
                .ForeignKey("dbo.Account", t => t.UserName, cascadeDelete: true)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.SweepStakeEntry",
                c => new
                    {
                        SweepstakesID = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 20),
                        PurchaseDateTime = c.DateTime(nullable: false),
                        Cost = c.Int(nullable: false),
                        OpenDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.SweepstakesID, t.UserName })
                .ForeignKey("dbo.Account", t => t.UserName, cascadeDelete: true)
                .ForeignKey("dbo.SweepStake", t => t.SweepstakesID, cascadeDelete: true)
                .Index(t => t.SweepstakesID)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.SweepStake",
                c => new
                    {
                        SweepStakesID = c.Int(nullable: false, identity: true),
                        OpenDateTime = c.DateTime(nullable: false),
                        ClosedDateTime = c.DateTime(nullable: false),
                        Prize = c.String(nullable: false),
                        UsernameWinner = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.SweepStakesID);
            
            CreateTable(
                "dbo.AccountInterestTag",
                c => new
                    {
                        Account_UserName = c.String(nullable: false, maxLength: 20),
                        InterestTag_TagName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Account_UserName, t.InterestTag_TagName })
                .ForeignKey("dbo.Account", t => t.Account_UserName, cascadeDelete: true)
                .ForeignKey("dbo.InterestTag", t => t.InterestTag_TagName, cascadeDelete: true)
                .Index(t => t.Account_UserName)
                .Index(t => t.InterestTag_TagName);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        ZipCodeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Email, t.ZipCodeId })
                .ForeignKey("dbo.User", t => t.Email, cascadeDelete: true)
                .ForeignKey("dbo.ZipLocation", t => t.ZipCodeId, cascadeDelete: true)
                .Index(t => t.Email)
                .Index(t => t.ZipCodeId);
            
            CreateStoredProcedure(
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
            
            CreateStoredProcedure(
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
                        TagName = p.String(maxLength: 128),
                    },
                body:
                    @"INSERT [dbo].[Article]([ArticleLink], [ArticleTitle], [ArticleDescription], [TagName])
                      VALUES (@ArticleLink, @ArticleTitle, @ArticleDescription, @TagName)"
            );
            
            CreateStoredProcedure(
                "dbo.Article_Update",
                p => new
                    {
                        ArticleLink = p.String(maxLength: 128),
                        ArticleTitle = p.String(),
                        ArticleDescription = p.String(),
                        TagName = p.String(maxLength: 128),
                    },
                body:
                    @"UPDATE [dbo].[Article]
                      SET [ArticleTitle] = @ArticleTitle, [ArticleDescription] = @ArticleDescription, [TagName] = @TagName
                      WHERE ([ArticleLink] = @ArticleLink)"
            );
            
            CreateStoredProcedure(
                "dbo.Article_Delete",
                p => new
                    {
                        ArticleLink = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[Article]
                      WHERE ([ArticleLink] = @ArticleLink)"
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
                        SecQuestion = p.String(),
                    },
                body:
                    @"INSERT [dbo].[SecurityQuestion]([SecQuestion])
                      VALUES (@SecQuestion)
                      
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
                        SecQuestion = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[SecurityQuestion]
                      SET [SecQuestion] = @SecQuestion
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
                        ZipCode = p.String(maxLength: 10),
                        Address = p.String(),
                        City = p.String(),
                        State = p.String(),
                        Latitude = p.Int(),
                        Longitude = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[ZipLocation]([ZipCode], [Address], [City], [State], [Latitude], [Longitude])
                      VALUES (@ZipCode, @Address, @City, @State, @Latitude, @Longitude)
                      
                      DECLARE @ZipCodeId int
                      SELECT @ZipCodeId = [ZipCodeId]
                      FROM [dbo].[ZipLocation]
                      WHERE @@ROWCOUNT > 0 AND [ZipCodeId] = scope_identity()
                      
                      SELECT t0.[ZipCodeId]
                      FROM [dbo].[ZipLocation] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[ZipCodeId] = @ZipCodeId"
            );
            
            CreateStoredProcedure(
                "dbo.ZipLocation_Update",
                p => new
                    {
                        ZipCodeId = p.Int(),
                        ZipCode = p.String(maxLength: 10),
                        Address = p.String(),
                        City = p.String(),
                        State = p.String(),
                        Latitude = p.Int(),
                        Longitude = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[ZipLocation]
                      SET [ZipCode] = @ZipCode, [Address] = @Address, [City] = @City, [State] = @State, [Latitude] = @Latitude, [Longitude] = @Longitude
                      WHERE ([ZipCodeId] = @ZipCodeId)"
            );
            
            CreateStoredProcedure(
                "dbo.ZipLocation_Delete",
                p => new
                    {
                        ZipCodeId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[ZipLocation]
                      WHERE ([ZipCodeId] = @ZipCodeId)"
            );
            
            CreateStoredProcedure(
                "dbo.AccountType_Insert",
                p => new
                    {
                        Username = p.String(maxLength: 20),
                        PermissionName = p.String(maxLength: 128),
                    },
                body:
                    @"INSERT [dbo].[AccountType]([Username], [PermissionName])
                      VALUES (@Username, @PermissionName)"
            );
            
            CreateStoredProcedure(
                "dbo.AccountType_Update",
                p => new
                    {
                        Username = p.String(maxLength: 20),
                        PermissionName = p.String(maxLength: 128),
                    },
                body:
                    @"RETURN"
            );
            
            CreateStoredProcedure(
                "dbo.AccountType_Delete",
                p => new
                    {
                        Username = p.String(maxLength: 20),
                        PermissionName = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[AccountType]
                      WHERE (([Username] = @Username) AND ([PermissionName] = @PermissionName))"
            );
            
            CreateStoredProcedure(
                "dbo.Permission_Insert",
                p => new
                    {
                        PermissionName = p.String(maxLength: 128),
                    },
                body:
                    @"INSERT [dbo].[Permission]([PermissionName])
                      VALUES (@PermissionName)"
            );
            
            CreateStoredProcedure(
                "dbo.Permission_Update",
                p => new
                    {
                        PermissionName = p.String(maxLength: 128),
                    },
                body:
                    @"RETURN"
            );
            
            CreateStoredProcedure(
                "dbo.Permission_Delete",
                p => new
                    {
                        PermissionName = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[Permission]
                      WHERE ([PermissionName] = @PermissionName)"
            );
            
            CreateStoredProcedure(
                "dbo.JAccessToken_Insert",
                p => new
                    {
                        Value = p.String(),
                        UserName = p.String(maxLength: 20),
                    },
                body:
                    @"INSERT [dbo].[JAccessToken]([UserName], [Value])
                      VALUES (@UserName, @Value)
                      
                      DECLARE @TokenId int
                      SELECT @TokenId = [TokenId]
                      FROM [dbo].[JAccessToken]
                      WHERE @@ROWCOUNT > 0 AND [TokenId] = scope_identity()
                      
                      SELECT t0.[TokenId]
                      FROM [dbo].[JAccessToken] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[TokenId] = @TokenId"
            );
            
            CreateStoredProcedure(
                "dbo.JAccessToken_Update",
                p => new
                    {
                        TokenId = p.Int(),
                        Value = p.String(),
                        UserName = p.String(maxLength: 20),
                    },
                body:
                    @"UPDATE [dbo].[JAccessToken]
                      SET [UserName] = @UserName, [Value] = @Value
                      WHERE ([TokenId] = @TokenId)"
            );
            
            CreateStoredProcedure(
                "dbo.JAccessToken_Delete",
                p => new
                    {
                        TokenId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[JAccessToken]
                      WHERE ([TokenId] = @TokenId)"
            );
            
            CreateStoredProcedure(
                "dbo.Salt_Insert",
                p => new
                    {
                        PasswordSalt = p.String(),
                        UserName = p.String(maxLength: 20),
                    },
                body:
                    @"INSERT [dbo].[Salt]([PasswordSalt], [UserName])
                      VALUES (@PasswordSalt, @UserName)
                      
                      DECLARE @SaltId int
                      SELECT @SaltId = [SaltId]
                      FROM [dbo].[Salt]
                      WHERE @@ROWCOUNT > 0 AND [SaltId] = scope_identity()
                      
                      SELECT t0.[SaltId]
                      FROM [dbo].[Salt] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[SaltId] = @SaltId"
            );
            
            CreateStoredProcedure(
                "dbo.Salt_Update",
                p => new
                    {
                        SaltId = p.Int(),
                        PasswordSalt = p.String(),
                        UserName = p.String(maxLength: 20),
                    },
                body:
                    @"UPDATE [dbo].[Salt]
                      SET [PasswordSalt] = @PasswordSalt, [UserName] = @UserName
                      WHERE ([SaltId] = @SaltId)"
            );
            
            CreateStoredProcedure(
                "dbo.Salt_Delete",
                p => new
                    {
                        SaltId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Salt]
                      WHERE ([SaltId] = @SaltId)"
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
            DropStoredProcedure("dbo.Salt_Delete");
            DropStoredProcedure("dbo.Salt_Update");
            DropStoredProcedure("dbo.Salt_Insert");
            DropStoredProcedure("dbo.JAccessToken_Delete");
            DropStoredProcedure("dbo.JAccessToken_Update");
            DropStoredProcedure("dbo.JAccessToken_Insert");
            DropStoredProcedure("dbo.Permission_Delete");
            DropStoredProcedure("dbo.Permission_Update");
            DropStoredProcedure("dbo.Permission_Insert");
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
            DropForeignKey("dbo.SweepStakeEntry", "SweepstakesID", "dbo.SweepStake");
            DropForeignKey("dbo.SweepStakeEntry", "UserName", "dbo.Account");
            DropForeignKey("dbo.Salt", "UserName", "dbo.Account");
            DropForeignKey("dbo.JAccessToken", "UserName", "dbo.Account");
            DropForeignKey("dbo.AccountType", "PermissionName", "dbo.Permission");
            DropForeignKey("dbo.AccountType", "Username", "dbo.Account");
            DropForeignKey("dbo.Account", "Email", "dbo.User");
            DropForeignKey("dbo.Address", "ZipCodeId", "dbo.ZipLocation");
            DropForeignKey("dbo.Address", "Email", "dbo.User");
            DropForeignKey("dbo.SecurityQuestionAccount", "Username", "dbo.Account");
            DropForeignKey("dbo.SecurityQuestionAccount", "SecurityQuestionID", "dbo.SecurityQuestion");
            DropForeignKey("dbo.AccountInterestTag", "InterestTag_TagName", "dbo.InterestTag");
            DropForeignKey("dbo.AccountInterestTag", "Account_UserName", "dbo.Account");
            DropForeignKey("dbo.Article", "TagName", "dbo.InterestTag");
            DropIndex("dbo.Address", new[] { "ZipCodeId" });
            DropIndex("dbo.Address", new[] { "Email" });
            DropIndex("dbo.AccountInterestTag", new[] { "InterestTag_TagName" });
            DropIndex("dbo.AccountInterestTag", new[] { "Account_UserName" });
            DropIndex("dbo.SweepStakeEntry", new[] { "UserName" });
            DropIndex("dbo.SweepStakeEntry", new[] { "SweepstakesID" });
            DropIndex("dbo.Salt", new[] { "UserName" });
            DropIndex("dbo.JAccessToken", new[] { "UserName" });
            DropIndex("dbo.AccountType", new[] { "PermissionName" });
            DropIndex("dbo.AccountType", new[] { "Username" });
            DropIndex("dbo.SecurityQuestionAccount", new[] { "Username" });
            DropIndex("dbo.SecurityQuestionAccount", new[] { "SecurityQuestionID" });
            DropIndex("dbo.Article", new[] { "TagName" });
            DropIndex("dbo.Account", new[] { "Email" });
            DropTable("dbo.Address");
            DropTable("dbo.AccountInterestTag");
            DropTable("dbo.SweepStake");
            DropTable("dbo.SweepStakeEntry");
            DropTable("dbo.Salt");
            DropTable("dbo.JAccessToken");
            DropTable("dbo.Permission");
            DropTable("dbo.AccountType");
            DropTable("dbo.ZipLocation");
            DropTable("dbo.User");
            DropTable("dbo.SecurityQuestion");
            DropTable("dbo.SecurityQuestionAccount");
            DropTable("dbo.Article");
            DropTable("dbo.InterestTag");
            DropTable("dbo.Account");
        }
    }
}
