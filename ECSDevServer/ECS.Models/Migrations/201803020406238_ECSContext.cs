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
                        Password = c.String(nullable: false, maxLength: 20),
                        Points = c.Int(nullable: false),
                        AccountStatus = c.Boolean(nullable: false),
                        SuspensionTime = c.DateTime(nullable: false),
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
                        InterestTag_TagName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ArticleLink)
                .ForeignKey("dbo.InterestTag", t => t.InterestTag_TagName)
                .Index(t => t.InterestTag_TagName);
            
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
                        SecurityQuestions = c.String(),
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
                "dbo.Cookie",
                c => new
                    {
                        SessionID = c.Int(nullable: false, identity: true),
                        Domain = c.String(nullable: false),
                        DateCreatedSessionCookie = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Path = c.String(),
                        Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SessionID)
                .ForeignKey("dbo.User", t => t.Email)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.ZipLocation",
                c => new
                    {
                        ZipCode = c.String(nullable: false, maxLength: 10),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Latitude = c.Int(nullable: false),
                        Longitude = c.Int(nullable: false),
                        Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ZipCode)
                .ForeignKey("dbo.User", t => t.Email)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.AccountType",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 20),
                        Permission = c.String(nullable: false, maxLength: 128),
                        RoleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.Username, t.Permission })
                .ForeignKey("dbo.Account", t => t.Username, cascadeDelete: true)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.LinkedIn",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 20),
                        AccessToken = c.String(nullable: false, maxLength: 2000),
                        TokenCreation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserName, t.AccessToken })
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
                "dbo.AccountTags",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 20),
                        TagName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Username, t.TagName })
                .ForeignKey("dbo.Account", t => t.Username, cascadeDelete: true)
                .ForeignKey("dbo.InterestTag", t => t.TagName, cascadeDelete: true)
                .Index(t => t.Username)
                .Index(t => t.TagName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SweepStakeEntry", "SweepstakesID", "dbo.SweepStake");
            DropForeignKey("dbo.SweepStakeEntry", "UserName", "dbo.Account");
            DropForeignKey("dbo.LinkedIn", "UserName", "dbo.Account");
            DropForeignKey("dbo.AccountType", "Username", "dbo.Account");
            DropForeignKey("dbo.Account", "Email", "dbo.User");
            DropForeignKey("dbo.ZipLocation", "Email", "dbo.User");
            DropForeignKey("dbo.Cookie", "Email", "dbo.User");
            DropForeignKey("dbo.SecurityQuestionAccount", "Username", "dbo.Account");
            DropForeignKey("dbo.SecurityQuestionAccount", "SecurityQuestionID", "dbo.SecurityQuestion");
            DropForeignKey("dbo.AccountTags", "TagName", "dbo.InterestTag");
            DropForeignKey("dbo.AccountTags", "Username", "dbo.Account");
            DropForeignKey("dbo.Article", "InterestTag_TagName", "dbo.InterestTag");
            DropIndex("dbo.AccountTags", new[] { "TagName" });
            DropIndex("dbo.AccountTags", new[] { "Username" });
            DropIndex("dbo.SweepStakeEntry", new[] { "UserName" });
            DropIndex("dbo.SweepStakeEntry", new[] { "SweepstakesID" });
            DropIndex("dbo.LinkedIn", new[] { "UserName" });
            DropIndex("dbo.AccountType", new[] { "Username" });
            DropIndex("dbo.ZipLocation", new[] { "Email" });
            DropIndex("dbo.Cookie", new[] { "Email" });
            DropIndex("dbo.SecurityQuestionAccount", new[] { "Username" });
            DropIndex("dbo.SecurityQuestionAccount", new[] { "SecurityQuestionID" });
            DropIndex("dbo.Article", new[] { "InterestTag_TagName" });
            DropIndex("dbo.Account", new[] { "Email" });
            DropTable("dbo.AccountTags");
            DropTable("dbo.SweepStake");
            DropTable("dbo.SweepStakeEntry");
            DropTable("dbo.LinkedIn");
            DropTable("dbo.AccountType");
            DropTable("dbo.ZipLocation");
            DropTable("dbo.Cookie");
            DropTable("dbo.User");
            DropTable("dbo.SecurityQuestion");
            DropTable("dbo.SecurityQuestionAccount");
            DropTable("dbo.Article");
            DropTable("dbo.InterestTag");
            DropTable("dbo.Account");
        }
    }
}
