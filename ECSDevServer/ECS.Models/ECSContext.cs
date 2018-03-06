using System;
using ECS.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Net;

namespace ECS.Models.ECSContext
{
    /// <summary>
    /// This class initializes the database to the connectionstring ECSContext which is found in web.config.
    /// It also initializes the models and provides a schema for a migration to scaffold.
    /// </summary>
    
    public class ECSContext : DbContext
    {
        public ECSContext() : base("ECSContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ECSContext, ECS.Models.Migrations.Configuration>("ECSContext"));
        }
        //Models to be implemented in the database
        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }

        public DbSet<InterestTag> InterestTags { get; set; }

        //public DbSet<Cookie> Cookies { get; set; }

        public DbSet<LinkedIn> LinkedIn { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<SecurityQuestionAccount> SecurityQuestionAccounts { get; set; }

        public DbSet<SecurityQuestion> SecurityQuestions { get; set; }

        public DbSet<SweepStakeEntry> SweepStakeEntries { get; set; }

        public DbSet<SweepStake> SweepStakes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ZipLocation> ZipLocations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Disables the automatic naming convention of pluralizing entity names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            //All relationships not defined here, are automatically handled by EF
            //Navigation Properties allow you to define relationships between entities 
            //in a way that makes sense in an object oriented language.


            //Many to Many Relationship with Account and Article model
            //Define the navigation properties of Account and Article
            //Map the foreign keys of each model
            //Create table with custom name AccountArticle
            /**
            modelBuilder.Entity<Account>()                
                .HasMany(c => c.Article).WithMany(i => i.Account)
                .Map(t => t.MapLeftKey("Username")
                .MapRightKey("ArticleLink")
                .ToTable("AccountArticle"));
            
            **/
            //Many to Many relationship with Account and Interest Tag model
            //Define the navigation properties of Account and Interest Tag
            //Map the foreign keys of each model
            //Create table with custom name AccountTags

            modelBuilder.Entity<Account>()
                .HasMany(c => c.AccountTags).WithMany(i => i.AccountUsername)
                .Map(t => t.MapLeftKey("Username")
                .MapRightKey("TagName")
                .ToTable("AccountTags"));


            //One to Many relationship with Account and SecurityQuestionAccounts model
            //Define navigation property of SecurityQuestionAccount in Account
            //Define navigation property of Account in SecurityQuestionAccount
            //Define ForeignKey of SecurityQuestionAccoun
            modelBuilder.Entity<Account>()
                .HasMany<SecurityQuestionAccount>(g => g.SecurityAnswers)
                .WithRequired(s => s.Accounts)
                .HasForeignKey<string>(s => s.Username);
            
            /**
            modelBuilder.Entity<InterestTag>()
                .HasMany<Article>(a => a.ArticleTags)
                .WithRequired(i => i.InterestTag)
                .HasForeignKey<string>(i => i.ArticleLink);
            
            **/
            //Setting primary key of SecurityQuestionAccount model to custom primary key
            modelBuilder.Entity<SecurityQuestionAccount>()
                .HasKey(s => new { s.Username, s.SecurityQuestionID });

            modelBuilder.Entity<Account>().MapToStoredProcedures();

            modelBuilder.Entity<Account>().HasMany(p => p.AccountTags)
                .WithMany(s => s.AccountUsername).MapToStoredProcedures();

            modelBuilder.Entity<User>().MapToStoredProcedures();

            modelBuilder.Entity<Article>().MapToStoredProcedures(s => s.Insert (
                i => i.Parameter(p => p.InterestTag.TagName, "tag_name")));

            modelBuilder.Entity<InterestTag>().MapToStoredProcedures();

            modelBuilder.Entity<SecurityQuestion>().MapToStoredProcedures();

            modelBuilder.Entity<SecurityQuestionAccount>().MapToStoredProcedures();

            modelBuilder.Entity<ZipLocation>().MapToStoredProcedures();

            modelBuilder.Entity<AccountType>().MapToStoredProcedures();

            modelBuilder.Entity<SweepStake>().MapToStoredProcedures();

            modelBuilder.Entity<SweepStakeEntry>().MapToStoredProcedures();

            modelBuilder.Entity<LinkedIn>().MapToStoredProcedures();

        }

    }
}
