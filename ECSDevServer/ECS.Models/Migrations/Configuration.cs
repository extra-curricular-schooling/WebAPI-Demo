namespace ECS.Models.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ECS.Models.ECSContext.ECSContext>
    {
        public Configuration()
        {
            // Changes in models will not affect the database
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;

        }

        protected override void Seed(ECS.Models.ECSContext.ECSContext context)
        {
            
            // Add entries to the User table
            var users = new List<User>
            {
                    new User
                    {
                    Email = "test1@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test2@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test3@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test4@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test5@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test6@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test7@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test8@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test9@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test10@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test11@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test12@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test13@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test14@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test15@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test16@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test17@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test18@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test19@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test20@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test21@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test22@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test23@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test24@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test25@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test26@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test27@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test28@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test29@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test30@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test31@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test32@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test33@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test34@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test35@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test36@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test37@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test38@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test39@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test40@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test41@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test42@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test43@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test44@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test45@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test46@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test47@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test48@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test49@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
                    new User
                    {
                    Email = "test50@gmail.com",
                    FirstName = "test",
                    LastName = "tester",
                    },
            };
            // For each item in the list user addorupdate a User object with an email
            users.ForEach(s => context.Users.AddOrUpdate(p => p.Email, s));
            context.SaveChanges();

            var zipLocation = new List<ZipLocation>
            {
               new ZipLocation
               {
                   Address = "123 Atherton Ln",
                   City = "Long Beach",
                   State = "CA",
                   ZipCode = "123456",
                   Latitude = 123,
                   Longitude = 123,
                   //Email = users.Single(s => s.Email == "test1@gmail.com").Email
                   Users = new List<User>
                   {
                       users.Single(s => s.Email == "test1@gmail.com")
                   }
               },
               new ZipLocation
               {
                   Address = "125 Atherton Ln",
                   City = "Long Beach",
                   State = "CA",
                   ZipCode = "98765",
                   Latitude = 123,
                   Longitude = 123,
                   //Email = users.Single(s => s.Email == "test2@gmail.com").Email
                   Users = new List<User>
                   {
                       users.Single(s => s.Email == "test2@gmail.com")
                   }
               },
               new ZipLocation
               {
                   Address = "153 Atherton Ln",
                   City = "Long Beach",
                   State = "CA",
                   ZipCode = "84756",
                   Latitude = 123,
                   Longitude = 123,
                  // Email = users.Single(s => s.Email == "test3@gmail.com").Email,
                   Users = new List<User>
                   {
                       users.Single(s => s.Email == "test3@gmail.com")
                   }
                   
               },
               new ZipLocation
               {
                   Address = "167 Atherton Ln",
                   City = "Long Beach",
                   State = "CA",
                   ZipCode = "74652",
                   Latitude = 123,
                   Longitude = 123,
                   //Email = users.Single(s => s.Email == "test3@gmail.com").Email,
                   Users = new List<User>
                   {
                       users.Single(s => s.Email == "test3@gmail.com"),
                       users.Single(s => s.Email == "test4@gmail.com"),
                       users.Single(s => s.Email == "test5@gmail.com")
                   }                   
               }
            };
            // For each item in the list zipLocation addorupdate a ZipLocation object with a ZipcOd
            zipLocation.ForEach(s => context.ZipLocations.AddOrUpdate(p => p.ZipCode, s));
            context.SaveChanges();


            
            //AddOrUpdateZipCode(context, 1, "test3@gmail.com");
            //AddOrUpdateZipCode(context, 6, "test3@gmail.com");

            // Add entries to the Account table
            var accounts = new List<Account>
            {
                    new Account
                    {
                        UserName = "test1",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test1@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test2",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test2@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test3",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test3@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test4",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test4@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test5",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test5@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test6",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test6@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test7",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test7@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test8",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test8@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test9",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test9@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test10",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test10@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test11",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test11@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test12",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test12@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test13",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test13@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test14",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test14@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test15",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test15@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test16",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test16@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test17",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test17@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test18",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test18@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test19",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test19@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test20",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test20@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test21",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test21@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test22",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test22@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test23",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test23@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test24",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test24@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test25",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test25@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test26",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test26@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test27",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test27@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test28",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test28@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test29",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test29@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test30",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test30@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test31",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test31@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test32",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test32@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test33",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test33@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test34",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test34@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test35",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test35@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test36",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test36@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test37",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test37@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>(),
                    },
                    new Account
                    {
                        UserName = "test38",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test38@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>()
                    },
                    new Account
                    {
                        UserName = "test39",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test39@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>()
                    },
                    new Account
                    {
                        UserName = "test40",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test40@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>()
                    },
                    new Account
                    {
                        UserName = "test41",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test41@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>()
                    },
                    new Account
                    {
                        UserName = "test42",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test42@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>()
                    },
                    new Account
                    {
                        UserName = "test43",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test43@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>()
                    },
                    new Account
                    {
                        UserName = "test44",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test44@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>()
                    },
                    new Account
                    {
                        UserName = "test45",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test45@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>()
                    },
                    new Account
                    {
                        UserName = "test46",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test46@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>()
                    },
                    new Account
                    {
                        UserName = "test47",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test47@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>()
                    },
                    new Account
                    {
                        UserName = "test48",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test48@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>()
                    },
                    new Account
                    {
                        UserName = "test49",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test49@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>()
                    },
                    new Account
                    {
                        UserName = "test50",
                        Password = "aaaaaaaaa",
                        Email = users.Single(s => s.Email == "test50@gmail.com").Email,
                        AccountStatus = true,
                        Points = 0,
                        SuspensionTime = DateTime.Now,
                        AccountTags = new List<InterestTag>(),
                        FirstTimeUser = true,
                        SecurityAnswers = new List<SecurityQuestionAccount>()
                    },
            };
            // For each item in the list account addorupdate an Account object with an email
            accounts.ForEach(s => context.Accounts.AddOrUpdate(p => p.Email, s));
            context.SaveChanges();

            var accountTags = new List<InterestTag>
            {
                    new InterestTag
                    {
                        TagName = "CompSci",
                        ArticleTags = new List<Article>()
                    },
                    new InterestTag
                    {
                        TagName = "Chemistry",
                        ArticleTags = new List<Article>()
                    },
                    new InterestTag
                    {
                        TagName = "English",
                        ArticleTags = new List<Article>()
                    },
                    new InterestTag
                    {
                        TagName = "Art",
                        ArticleTags = new List<Article>()
                    },
                    new InterestTag
                    {
                        TagName = "Math",
                        ArticleTags = new List<Article>()
                    },
                    new InterestTag
                    {
                        TagName = "History",
                        ArticleTags = new List<Article>()
                    },
                    new InterestTag
                    {
                        TagName = "Engineering",
                        ArticleTags = new List<Article>()
                    },
                    new InterestTag
                    {
                        TagName = "Biology",
                        ArticleTags = new List<Article>()
                    },
                    new InterestTag
                    {
                        TagName = "Political Science",
                        ArticleTags = new List<Article>()
                    },
                    new InterestTag
                    {
                        TagName = "Sociology",
                        ArticleTags = new List<Article>()
                    },

            };
            // For each item in the list accountTags addorupdate an Interest Tag with a TagName
            accountTags.ForEach(s => context.InterestTags.AddOrUpdate(p => p.TagName, s));
            context.SaveChanges();

            // Add entries to the join table AccountTags
            AddOrUpdateInterestTag(context, "test1", "CompSci");
            AddOrUpdateInterestTag(context, "test1", "Math");
            AddOrUpdateInterestTag(context, "test2", "CompSci");
            AddOrUpdateInterestTag(context, "test2", "English");
            AddOrUpdateInterestTag(context, "test3", "Math");
            AddOrUpdateInterestTag(context, "test3", "Art");
            AddOrUpdateInterestTag(context, "test2", "Art");
            AddOrUpdateInterestTag(context, "test2", "Math");
            AddOrUpdateInterestTag(context, "test3", "English");
            AddOrUpdateInterestTag(context, "test4", "CompSci");
            AddOrUpdateInterestTag(context, "test5", "Biology");
            AddOrUpdateInterestTag(context, "test6", "Biology");
            AddOrUpdateInterestTag(context, "test6", "Engineering");
            AddOrUpdateInterestTag(context, "test7", "Engineering");
            AddOrUpdateInterestTag(context, "test7", "Art");
            AddOrUpdateInterestTag(context, "test8", "Art");
            AddOrUpdateInterestTag(context, "test8", "Math");
            AddOrUpdateInterestTag(context, "test9", "English");
            AddOrUpdateInterestTag(context, "test9", "CompSci");
            AddOrUpdateInterestTag(context, "test9", "Math");
            AddOrUpdateInterestTag(context, "test10", "Sociology");
            AddOrUpdateInterestTag(context, "test11", "English");
            AddOrUpdateInterestTag(context, "test12", "Math");
            AddOrUpdateInterestTag(context, "test12", "Art");
            AddOrUpdateInterestTag(context, "test12", "English");
            AddOrUpdateInterestTag(context, "test12", "Political Science");
            AddOrUpdateInterestTag(context, "test13", "English");
            AddOrUpdateInterestTag(context, "test13", "CompSci");
            AddOrUpdateInterestTag(context, "test14", "Math");
            AddOrUpdateInterestTag(context, "test15", "CompSci");
            AddOrUpdateInterestTag(context, "test16", "English");
            AddOrUpdateInterestTag(context, "test16", "Math");
            AddOrUpdateInterestTag(context, "test16", "Art");
            AddOrUpdateInterestTag(context, "test17", "Art");
            AddOrUpdateInterestTag(context, "test17", "Math");
            AddOrUpdateInterestTag(context, "test19", "English");
            AddOrUpdateInterestTag(context, "test20", "CompSci");
            AddOrUpdateInterestTag(context, "test21", "Math");
            AddOrUpdateInterestTag(context, "test22", "Biology");
            AddOrUpdateInterestTag(context, "test22", "Engineering");
            AddOrUpdateInterestTag(context, "test23", "Math");
            AddOrUpdateInterestTag(context, "test23", "Art");
            AddOrUpdateInterestTag(context, "test25", "Art");
            AddOrUpdateInterestTag(context, "test25", "Chemistry");
            AddOrUpdateInterestTag(context, "test26", "English");
            AddOrUpdateInterestTag(context, "test27", "CompSci");
            AddOrUpdateInterestTag(context, "test27", "Math");
            AddOrUpdateInterestTag(context, "test29", "CompSci");
            AddOrUpdateInterestTag(context, "test29", "English");
            AddOrUpdateInterestTag(context, "test30", "Math");
            AddOrUpdateInterestTag(context, "test30", "Art");
            AddOrUpdateInterestTag(context, "test32", "Art");
            AddOrUpdateInterestTag(context, "test32", "Math");
            AddOrUpdateInterestTag(context, "test33", "English");
            AddOrUpdateInterestTag(context, "test34", "CompSci");
            AddOrUpdateInterestTag(context, "test35", "Biology");
            AddOrUpdateInterestTag(context, "test36", "Biology");
            AddOrUpdateInterestTag(context, "test36", "Engineering");
            AddOrUpdateInterestTag(context, "test37", "Engineering");
            AddOrUpdateInterestTag(context, "test37", "Art");
            AddOrUpdateInterestTag(context, "test38", "Art");
            AddOrUpdateInterestTag(context, "test38", "Math");
            AddOrUpdateInterestTag(context, "test39", "English");
            AddOrUpdateInterestTag(context, "test39", "CompSci");
            AddOrUpdateInterestTag(context, "test39", "Math");
            AddOrUpdateInterestTag(context, "test40", "Sociology");
            AddOrUpdateInterestTag(context, "test41", "English");
            AddOrUpdateInterestTag(context, "test42", "Math");
            AddOrUpdateInterestTag(context, "test42", "Art");
            AddOrUpdateInterestTag(context, "test42", "English");
            AddOrUpdateInterestTag(context, "test42", "Political Science");
            AddOrUpdateInterestTag(context, "test43", "English");
            AddOrUpdateInterestTag(context, "test43", "CompSci");
            AddOrUpdateInterestTag(context, "test44", "Math");
            AddOrUpdateInterestTag(context, "test45", "CompSci");
            AddOrUpdateInterestTag(context, "test46", "English");
            AddOrUpdateInterestTag(context, "test46", "Math");
            AddOrUpdateInterestTag(context, "test46", "Art");
            AddOrUpdateInterestTag(context, "test47", "Art");
            AddOrUpdateInterestTag(context, "test47", "Math");
            AddOrUpdateInterestTag(context, "test49", "English");
            AddOrUpdateInterestTag(context, "test49", "Math");
            context.SaveChanges();


            // Add entries to the Article table
            var articles = new List<Article>
            {
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test1.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test2.com",
                 },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test3.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test4.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test5.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test6.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test7.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test8.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test9.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test10.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test11.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test12.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test13.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test14.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test15.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test16.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test17.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test18.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test19.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test20.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test21.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test22.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test23.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test24.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test25.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test26.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test27.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test28.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test29.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test30.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test31.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test32.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test33.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test34.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test35.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test36.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test37.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test38.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test39.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test40.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test41.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test42.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test43.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test44.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test45.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test46.com",
                },
                new Article
                {
                    // ArticleTag = "English",
                    ArticleTitle = "English For Dummies",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test47.com",
                },
                new Article
                {
                    // ArticleTag = "Art",
                    ArticleTitle = "History of Art",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test48.com",
                },
                new Article
                {
                    // ArticleTag = "CECS",
                    ArticleTitle = "Vong",
                    ArticleDescription = "This is a description",
                    ArticleLink = "www.test49.com",
                },
            };

            // For each item in the list article addoropdate an Article object with an ArticleTitle
            articles.ForEach(s => context.Articles.AddOrUpdate(p => p.ArticleTitle, s));
            context.SaveChanges();

            // Add entries to foreign key of Article which is the Interest Tag Name
            AddOrUpdateArticle(context, "Chemistry", "www.test1.com");
            AddOrUpdateArticle(context, "Chemistry", "www.test2.com");
            AddOrUpdateArticle(context, "Chemistry", "www.test3.com");
            AddOrUpdateArticle(context, "Art", "www.test4.com");
            AddOrUpdateArticle(context, "Art", "www.test5.com");
            AddOrUpdateArticle(context, "Art", "www.test6.com");
            AddOrUpdateArticle(context, "English", "www.test7.com");
            AddOrUpdateArticle(context, "English", "www.test8.com");
            AddOrUpdateArticle(context, "English", "www.test9.com");
            AddOrUpdateArticle(context, "Math", "www.test10.com");
            AddOrUpdateArticle(context, "Math", "www.test11.com");
            AddOrUpdateArticle(context, "Math", "www.test12.com");
            AddOrUpdateArticle(context, "Math", "www.test13.com");
            AddOrUpdateArticle(context, "Biology", "www.test14.com");
            AddOrUpdateArticle(context, "Biology", "www.test15.com");
            AddOrUpdateArticle(context, "Biology", "www.test16.com");
            AddOrUpdateArticle(context, "Sociology", "www.test17.com");
            AddOrUpdateArticle(context, "Sociology", "www.test18.com");
            AddOrUpdateArticle(context, "Sociology", "www.test19.com");
            AddOrUpdateArticle(context, "Engineering", "www.test20.com");
            AddOrUpdateArticle(context, "Engineering", "www.test21.com");
            AddOrUpdateArticle(context, "Engineering", "www.test22.com");
            AddOrUpdateArticle(context, "History", "www.test23.com");
            AddOrUpdateArticle(context, "History", "www.test24.com");
            AddOrUpdateArticle(context, "CompSci", "www.test25.com");
            AddOrUpdateArticle(context, "Math", "www.test26.com");
            AddOrUpdateArticle(context, "Math", "www.test27.com");
            AddOrUpdateArticle(context, "Math", "www.test28.com");
            AddOrUpdateArticle(context, "English", "www.test29.com");
            AddOrUpdateArticle(context, "English", "www.test30.com");
            AddOrUpdateArticle(context, "English", "www.test31.com");
            AddOrUpdateArticle(context, "Engineering", "www.test32.com");
            AddOrUpdateArticle(context, "Engineering", "www.test33.com");
            AddOrUpdateArticle(context, "Engineering", "www.test34.com");
            AddOrUpdateArticle(context, "Sociology", "www.test35.com");
            AddOrUpdateArticle(context, "CompSci", "www.test36.com");
            AddOrUpdateArticle(context, "Sociology", "www.test37.com");
            AddOrUpdateArticle(context, "Biology", "www.test38.com");
            AddOrUpdateArticle(context, "Biology", "www.test39.com");
            AddOrUpdateArticle(context, "Biology", "www.test40.com");
            AddOrUpdateArticle(context, "Chemistry", "www.test41.com");
            AddOrUpdateArticle(context, "Art", "www.test42.com");
            AddOrUpdateArticle(context, "Art", "www.test43.com");
            AddOrUpdateArticle(context, "CompSci", "www.test44.com");
            AddOrUpdateArticle(context, "Engineering", "www.test45.com");
            AddOrUpdateArticle(context, "History", "www.test46.com");
            AddOrUpdateArticle(context, "Math", "www.test47.com");
            AddOrUpdateArticle(context, "Math", "www.test48.com");
            AddOrUpdateArticle(context, "Math", "www.test49.com");
            context.SaveChanges();
            
            // Add entries to the SecurityQuestion table
            var securityQuestion = new List<SecurityQuestion>
            {
                new SecurityQuestion
                {
                    SecQuestion = "What is the name of your first pet?",
                    SecurityQuestionID = 1
                },
                new SecurityQuestion
                {
                    SecQuestion = "Who is your favorite historical person?",
                    SecurityQuestionID = 2
                },
                new SecurityQuestion
                {
                    SecQuestion = "What is your mother's maiden name?",
                    SecurityQuestionID = 3
                },
            };
            // For each item in the list securityQuestion, addorupdate a SecurityQuestion with an ID
            securityQuestion.ForEach(s => context.SecurityQuestions.AddOrUpdate(p => p.SecurityQuestionID, s));
            context.SaveChanges();

            // Add entries to SecurityQuestionAccount table
            var securityQuestionAccounts = new List<SecurityQuestionAccount>
            {
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test1").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test1").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test1").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test2").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test2").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test2").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test3").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test3").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test3").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test4").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test4").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test4").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test5").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test5").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test5").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test6").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test6").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test6").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test7").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test7").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test7").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test8").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test8").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test8").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test9").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test9").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test9").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test10").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test10").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test10").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test11").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test11").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test11").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test12").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test12").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test12").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test13").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test13").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test13").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test14").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test14").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test14").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test15").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test15").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test15").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test16").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test16").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test16").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test17").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test17").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test17").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test18").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test18").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test18").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test19").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test19").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test19").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test20").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test20").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test20").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test21").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test21").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test21").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test22").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test22").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test22").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test23").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test23").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test23").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test24").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test24").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test24").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test25").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test25").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test25").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test26").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test26").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test26").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test27").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test27").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test27").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test28").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test28").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test28").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test29").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test29").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test29").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test30").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test30").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test30").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test31").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test31").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test31").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test32").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test32").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test32").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test34").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test34").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test34").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test35").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test35").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test35").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test36").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test36").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test36").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test37").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test37").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test37").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test38").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test38").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test38").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test39").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test39").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test39").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test40").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test40").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test40").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test41").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test41").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test41").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test42").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test42").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test42").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test43").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test43").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test43").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test44").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test44").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test44").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test45").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test45").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test45").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test46").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "testing",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test46").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test46").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test47").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test47").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test47").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test48").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test48").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test48").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test49").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test49").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test49").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tested",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 1).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test50").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "test1",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 2).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test50").UserName
                },
                new SecurityQuestionAccount
                {
                    Answer = "tests",
                    SecurityQuestionID = securityQuestion.Single(s => s.SecurityQuestionID == 3).SecurityQuestionID,
                    Username = accounts.Single(i => i.UserName == "test50").UserName
                },
            };
            // For each item in the list securityQuestionAccount addorupdate a SecurityQuestionAccount object with an ID
            securityQuestionAccounts.ForEach(s => context.SecurityQuestionAccounts.AddOrUpdate(p => p.SecurityQuestionID, s));
            context.SaveChanges();

            var roles = new List<Role>
            {
                new Role
                {
                    RoleId = 1,
                    RoleName = "admin"
                },
                new Role
                {
                    RoleId = 2,
                    RoleName = "scholar"
                }
            };
            roles.ForEach(s => context.Roles.AddOrUpdate(p => p.RoleId, s));
            context.SaveChanges();

            var permissions = new List<Permission>
            {
                new Permission
                {
                    RoleId = roles.Single(i => i.RoleId == 1).RoleId,
                    PermissionName = "CanCreateUser"
                },
                new Permission
                {
                    RoleId = roles.Single(i => i.RoleId == 1).RoleId,
                    PermissionName = "CanDeleteUser"
                },
                new Permission
                {
                    RoleId = roles.Single(i => i.RoleId == 1).RoleId,
                    PermissionName = "CanModifyUser"
                },
                new Permission
                {
                    RoleId = roles.Single(i => i.RoleId == 1).RoleId,
                    PermissionName = "CanEditInformation"
                },
                new Permission
                {
                    RoleId = roles.Single(i => i.RoleId == 2).RoleId,
                    PermissionName = "CanEnterRaffle"
                },
                new Permission
                {
                    RoleId = roles.Single(i => i.RoleId == 2).RoleId,
                    PermissionName = "CanViewArticle"
                },
                new Permission
                {
                    RoleId = roles.Single(i => i.RoleId == 2).RoleId,
                    PermissionName = "CanCreateUser"
                },
                new Permission
                {
                    RoleId = roles.Single(i => i.RoleId == 2).RoleId,
                    PermissionName = "CanEditInformation"
                }

            };
            permissions.ForEach(s => context.Permissions.AddOrUpdate(p => p.PermissionName, s));
            context.SaveChanges();

            // Add entries into AccountTypes table
            var accountTypes = new List<AccountType>
            {
                     new AccountType
                     {
                        PermissionName = permissions.First(i => i.PermissionName == "CanCreateUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test1").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i => i.PermissionName == "CanDeleteUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test1").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i => i.PermissionName == "CanModifyUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test1").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i => i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test2").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i => i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test2").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i => i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test2").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i => i.PermissionName == "CanCreateUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test3").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i => i.PermissionName == "CanDeleteUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test3").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanModifyUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test3").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanCreateUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test4").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanDeleteUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test4").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanModifyUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test4").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanCreateUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test5").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanDeleteUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test5").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanModifyUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test5").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanCreateUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test6").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanDeleteUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test6").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanModifyUser").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 1).RoleId,
                        Username = accounts.Single(i => i.UserName == "test6").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test7").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test7").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test7").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test8").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test8").UserName
                     },
                     new AccountType
                     {
                        PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test8").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test9").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test9").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test9").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test10").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test10").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test10").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test11").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test11").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test11").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test12").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test12").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test12").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test13").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test13").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test13").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test14").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test14").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test14").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test15").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test15").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test15").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test16").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test16").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test16").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test17").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test17").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test17").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test18").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test18").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test18").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test19").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test19").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test19").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test20").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test20").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test20").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test21").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test21").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test21").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test22").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test22").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test22").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test23").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test23").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test23").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test24").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test24").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test24").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test25").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test25").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test25").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test26").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test26").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test26").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test27").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test27").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test27").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test28").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test28").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test28").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test29").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test29").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test29").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test30").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test30").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test30").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test31").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test31").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test31").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test32").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test32").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test33").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test34").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test34").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test34").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test35").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test35").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test35").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test36").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test36").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test36").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test37").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test37").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test37").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test38").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test38").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test38").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test39").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test39").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test39").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test40").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test40").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test40").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test41").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test41").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test41").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test42").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test42").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test42").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test43").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test43").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test43").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test44").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test44").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test44").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test45").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test45").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test45").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test46").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test46").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test46").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test47").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test47").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test47").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test48").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test48").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test48").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test49").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test49").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test49").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEditInformation").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test50").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanEnterRaffle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test50").UserName
                     },
                     new AccountType
                     {
                       PermissionName = permissions.First(i =>i.PermissionName == "CanViewArticle").PermissionName,
                        RoleId = permissions.First(i => i.RoleId == 2).RoleId,
                        Username = accounts.Single(i => i.UserName == "test50").UserName
                     },
            };
            // For each item in the list accountTypes addorupdate an AccountType object with a Username 
            accountTypes.ForEach(s => context.AccountTypes.AddOrUpdate(p => p.Username, s));
            context.SaveChanges();

            // Add entries to the LinkedIn table
            var linkedInTokens = new List<LinkedIn>
            {
                    new LinkedIn
                    {
                        AccessToken = "asfawgdsvbasbewgawnira",
                        UserName = accounts.Single(i => i.UserName == "test1").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvacasdsavaabwre",
                        UserName = accounts.Single(i => i.UserName == "test2").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofef09aniownvarwmoi",
                        UserName = accounts.Single(i => i.UserName == "test3").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawgdsvbasbewgapaowmr",
                        UserName = accounts.Single(i => i.UserName == "test4").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvaawroibmopcasdsavae",
                        UserName = accounts.Single(i => i.UserName == "test5").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofabwmoropef09aniownv",
                        UserName = accounts.Single(i => i.UserName == "test6").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawgsetndsvbasbewga",
                        UserName = accounts.Single(i => i.UserName == "test7").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvacasdsavawrensae",
                        UserName = accounts.Single(i => i.UserName == "test8").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofef09aniownvawrr",
                        UserName = accounts.Single(i => i.UserName == "test9").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawgdsvbasbewawbrbabga",
                        UserName = accounts.Single(i => i.UserName == "test10").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvacasdsavaawone",
                        UserName = accounts.Single(i => i.UserName == "test11").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofef09aniownawnbirv",
                        UserName = accounts.Single(i => i.UserName == "test12").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawgdsvbasbewgawoianb",
                        UserName = accounts.Single(i => i.UserName == "test13").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvacasdsavawvniae",
                        UserName = accounts.Single(i => i.UserName == "test14").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofef09aniownwbainv",
                        UserName = accounts.Single(i => i.UserName == "test15").UserName,
                        TokenCreation = DateTime.Now

                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawgdsvbasbewgfuybya",
                        UserName = accounts.Single(i => i.UserName == "test16").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvacasdsavklsrbae",
                        UserName = accounts.Single(i => i.UserName == "test17").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofef09aniownalkmrv",
                        UserName = accounts.Single(i => i.UserName == "test18").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawgdsvbasbewgestbea",
                        UserName = accounts.Single(i => i.UserName == "test19").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvacasdsajy5yrvae",
                        UserName = accounts.Single(i => i.UserName == "test20").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofef09aniowndfshv",
                        UserName = accounts.Single(i => i.UserName == "test21").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawgdsvbasbewgsnga",
                        UserName = accounts.Single(i => i.UserName == "test22").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvacasdsesrheavae",
                        UserName = accounts.Single(i => i.UserName == "test23").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofef09aniownsfhv",
                        UserName = accounts.Single(i => i.UserName == "test24").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawgdsvbasbewgaafh",
                        UserName = accounts.Single(i => i.UserName == "test25").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvafsdhasdvacasdsavae",
                        UserName = accounts.Single(i => i.UserName == "test26").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaoawegfef09aniownv",
                        UserName = accounts.Single(i => i.UserName == "test27").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawasdggdsvbasbewga",
                        UserName = accounts.Single(i => i.UserName == "test28").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvaasfcasdsavae",
                        UserName = accounts.Single(i => i.UserName == "test29").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofef09anigownv",
                        UserName = accounts.Single(i => i.UserName == "test30").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawgdsvbasbewgfa",
                        UserName = accounts.Single(i => i.UserName == "test31").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvacasdasavae",
                        UserName = accounts.Single(i => i.UserName == "test32").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofef09aniownvd",
                        UserName = accounts.Single(i => i.UserName == "test33").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaoawegfef09anasdgiownv",
                        UserName = accounts.Single(i => i.UserName == "test34").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawasdggdsasdgagvbasbewga",
                        UserName = accounts.Single(i => i.UserName == "test35").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvaasfcasdasdgsavae",
                        UserName = accounts.Single(i => i.UserName == "test36").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofef09anigownvagsdad",
                        UserName = accounts.Single(i => i.UserName == "test37").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawgdsvbasbewgallnksdvklfa",
                        UserName = accounts.Single(i => i.UserName == "test38").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvacdasgvasdasavae",
                        UserName = accounts.Single(i => i.UserName == "test39").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofef0dsnvadkl9aniownvd",
                        UserName = accounts.Single(i => i.UserName == "test40").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawgdsvbasvskanjbewgfa",
                        UserName = accounts.Single(i => i.UserName == "test41").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvacasdasavaasdgadse",
                        UserName = accounts.Single(i => i.UserName == "test42").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofef09aniown113fsafvd",
                        UserName = accounts.Single(i => i.UserName == "test43").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaoawegfef09anasdgiown29fniv",
                        UserName = accounts.Single(i => i.UserName == "test44").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawa1f3nisdggdsasdgagvbasbewga",
                        UserName = accounts.Single(i => i.UserName == "test45").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvaasfcasdasdgsav1342gfae",
                        UserName = accounts.Single(i => i.UserName == "test46").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofef09anigownvagd213sdad",
                        UserName = accounts.Single(i => i.UserName == "test47").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "asfawgdsvbasbewgallnksdvk23r4lfa",
                        UserName = accounts.Single(i => i.UserName == "test48").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "aoagnigarfsdvasdvacdasgvasdasav24ae",
                        UserName = accounts.Single(i => i.UserName == "test49").UserName,
                        TokenCreation = DateTime.Now
                    },
                    new LinkedIn
                    {
                        AccessToken = "109hfinaofef0dsnvadkl9aniadsg23ownvd",
                        UserName = accounts.Single(i => i.UserName == "test50").UserName,
                        TokenCreation = DateTime.Now
                    },

            };
            // For each item in the list linkedIn addorupdate a LinkedIn object with a username
            linkedInTokens.ForEach(s => context.LinkedIn.AddOrUpdate(p => p.UserName, s));
            context.SaveChanges();

            // Add entries to Sweepstakes table
            var sweepStakes = new List<SweepStake>
            {
                        new SweepStake
                        {
                            SweepStakesID = 1,
                            ClosedDateTime = DateTime.Today.AddMonths(1).AddDays(10),
                            OpenDateTime = DateTime.Today.AddMonths(1),
                            Prize = "prize",
                            // No Winner
                            // UsernameWinner = accounts.Single(s => s.Email == "test1@gmail.com").UserName,
                        },
                        new SweepStake
                        {
                            SweepStakesID = 2,
                            ClosedDateTime = DateTime.Now,
                            OpenDateTime = DateTime.Now,
                            Prize = "prize",
                            UsernameWinner = accounts.Single(s => s.Email == "test2@gmail.com").UserName,
                        },
                        new SweepStake
                        {
                            SweepStakesID = 3,
                            ClosedDateTime = DateTime.Now.AddMonths(1),
                            OpenDateTime = DateTime.Now.AddDays(2),
                            Prize = "prize",
                            // No winner
                            //UsernameWinner = accounts.Single(s => s.Email == "test1@gmail.com").UserName,
                        },
                        new SweepStake
                        {
                            SweepStakesID = 4,
                            ClosedDateTime = DateTime.Now.AddHours(2),
                            OpenDateTime = DateTime.Now,
                            Prize = "prize",
                            // No winner
                            // UsernameWinner = accounts.Single(s => s.Email == "test1@gmail.com").UserName,
                        },
            };
            // For each item in the list sweepStakes addorupdate a SweepStakes object with a usernamewinner.  If none usernamewinner = null
            sweepStakes.ForEach(s => context.SweepStakes.AddOrUpdate(p => p.UsernameWinner, s));
            context.SaveChanges();

            // Add entries to SweepStakeEntry table
            var sweepStakeEntries = new List<SweepStakeEntry>
            {
                    new SweepStakeEntry
                    {
                        UserName = accounts.Single(i => i.UserName == "test1").UserName,
                        Cost = 5,
                        PurchaseDateTime = DateTime.Now,
                        SweepstakesID = sweepStakes.Single(s => s.SweepStakesID == 1).SweepStakesID,
                        OpenDateTime = sweepStakes.Single(i => i.SweepStakesID == 1).OpenDateTime
                    },
                    new SweepStakeEntry
                    {
                        UserName = accounts.Single(i => i.UserName == "test2").UserName,
                        Cost = 5,
                        PurchaseDateTime = DateTime.Now,
                        SweepstakesID = sweepStakes.Single(s => s.SweepStakesID == 2).SweepStakesID,
                        OpenDateTime = sweepStakes.Single(i => i.SweepStakesID == 2).OpenDateTime
                    },
                    new SweepStakeEntry
                    {
                        UserName = accounts.Single(i => i.UserName == "test3").UserName,
                        Cost = 5,
                        PurchaseDateTime = DateTime.Now,
                        SweepstakesID = sweepStakes.Single(s => s.SweepStakesID == 3).SweepStakesID,
                        OpenDateTime = sweepStakes.Single(i => i.SweepStakesID == 3).OpenDateTime
                    },
                    new SweepStakeEntry
                    {
                        UserName = accounts.Single(i => i.UserName == "test1").UserName,
                        Cost = 5,
                        PurchaseDateTime = DateTime.Now,
                        SweepstakesID = sweepStakes.Single(s => s.SweepStakesID == 4).SweepStakesID,
                        OpenDateTime = sweepStakes.Single(i => i.SweepStakesID == 4).OpenDateTime
                    },
                    new SweepStakeEntry
                    {
                        UserName = accounts.Single(i => i.UserName == "test2").UserName,
                        Cost = 5,
                        PurchaseDateTime = DateTime.Now,
                        SweepstakesID = sweepStakes.Single(s => s.SweepStakesID == 1).SweepStakesID,
                        OpenDateTime = sweepStakes.Single(i => i.SweepStakesID == 1).OpenDateTime
                    },
            };
            // For each item in the list sweepStakeEntry addorupdate a SweepStakeEntry object with a username
            sweepStakeEntries.ForEach(s => context.SweepStakeEntries.AddOrUpdate(p => p.UserName, s));
            context.SaveChanges();
        }

        void AddOrUpdateInterestTag(ECS.Models.ECSContext.ECSContext context, string accountUsername, string tagName)
        {
            var tag = context.Accounts.SingleOrDefault(c => c.UserName == accountUsername);
            var inst = tag.AccountTags.SingleOrDefault(i => i.TagName == tagName);
            if (inst == null)
                tag.AccountTags.Add(context.InterestTags.Single(i => i.TagName == tagName));
        }

        void AddOrUpdateArticle(ECS.Models.ECSContext.ECSContext context, string tagName, string articleLink)
        {
            var article = context.InterestTags.SingleOrDefault(c => c.TagName == tagName);
            var inst = article.ArticleTags.SingleOrDefault(i => i.ArticleLink == articleLink);
            if (inst == null)
                article.ArticleTags.Add(context.Articles.Single(i => i.ArticleLink == articleLink));
        }
        void AddOrUpdateZipCode(ECS.Models.ECSContext.ECSContext context, int zipCodeId, string email)
        {
            var zip = context.Users.SingleOrDefault(c => c.Email == email);
            var inst = zip.ZipLocations.SingleOrDefault(i => i.ZipCodeId == zipCodeId);
            if (inst == null)
                zip.ZipLocations.Add(context.ZipLocations.Single(i => i.ZipCodeId == zipCodeId));
        }
        /**
        void AddOrUpdateZipCode(ECS.Models.ECSContext.ECSContext context, string email, string zipCode)
        {
            var user = context.ZipLocations.SingleOrDefault(c => c.ZipCode == zipCode);
            var inst = users.User.SingleOrDefault(i => i.Email == email);
            if (inst == null)
                user.User.Add(context.Users.Single(i => i.Email == email));
        }
        **/
        /**
            //Add entries to the //cookies table
            var //cookies = new List<//cookies>
                {
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 1,
                        Email = users.Single(s => s.Email == "test1@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 2,
                        Email = users.Single(s => s.Email == "test2@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(5000.00),
                        Path = "/",
                        SessionID = 3,
                        Email = users.Single(s => s.Email == "test3@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 4,
                        Email = users.Single(s => s.Email == "test4@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 5,
                        Email = users.Single(s => s.Email == "test5@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 6,
                        Email = users.Single(s => s.Email == "test6@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(5000.00),
                        Path = "/",
                        SessionID = 7,
                        Email = users.Single(s => s.Email == "test7@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 8,
                        Email = users.Single(s => s.Email == "test8@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 9,
                        Email = users.Single(s => s.Email == "test9@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 10,
                        Email = users.Single(s => s.Email == "test10@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(5000.00),
                        Path = "/",
                        SessionID = 11,
                        Email = users.Single(s => s.Email == "test11@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 12,
                        Email = users.Single(s => s.Email == "test12@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 13,
                        Email = users.Single(s => s.Email == "test13@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 14,
                        Email = users.Single(s => s.Email == "test14@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(5000.00),
                        Path = "/",
                        SessionID = 15,
                        Email = users.Single(s => s.Email == "test15@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 16,
                        Email = users.Single(s => s.Email == "test16@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 1,
                        Email = users.Single(s => s.Email == "test1@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 17,
                        Email = users.Single(s => s.Email == "test17@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(5000.00),
                        Path = "/",
                        SessionID = 18,
                        Email = users.Single(s => s.Email == "test18@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 19,
                        Email = users.Single(s => s.Email == "test19@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 20,
                        Email = users.Single(s => s.Email == "test20@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 21,
                        Email = users.Single(s => s.Email == "test21@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(5000.00),
                        Path = "/",
                        SessionID = 22,
                        Email = users.Single(s => s.Email == "test22@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 23,
                        Email = users.Single(s => s.Email == "test23@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 24,
                        Email = users.Single(s => s.Email == "test24@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 25,
                        Email = users.Single(s => s.Email == "test25@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(5000.00),
                        Path = "/",
                        SessionID = 26,
                        Email = users.Single(s => s.Email == "test26@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 27,
                        Email = users.Single(s => s.Email == "test27@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 28,
                        Email = users.Single(s => s.Email == "test28@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 2,
                        Email = users.Single(s => s.Email == "test2@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(5000.00),
                        Path = "/",
                        SessionID = 29,
                        Email = users.Single(s => s.Email == "test29@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 30,
                        Email = users.Single(s => s.Email == "test30@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 31,
                        Email = users.Single(s => s.Email == "test31@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 32,
                        Email = users.Single(s => s.Email == "test32@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(5000.00),
                        Path = "/",
                        SessionID = 33,
                        Email = users.Single(s => s.Email == "test33@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 34,
                        Email = users.Single(s => s.Email == "test34@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 35,
                        Email = users.Single(s => s.Email == "test35@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 36,
                        Email = users.Single(s => s.Email == "test36@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 37,
                        Email = users.Single(s => s.Email == "test37@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(5000.00),
                        Path = "/",
                        SessionID = 38,
                        Email = users.Single(s => s.Email == "test38@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 39,
                        Email = users.Single(s => s.Email == "test39@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 40,
                        Email = users.Single(s => s.Email == "test40@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 41,
                        Email = users.Single(s => s.Email == "test41@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 42,
                        Email = users.Single(s => s.Email == "test42@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(5000.00),
                        Path = "/",
                        SessionID = 43,
                        Email = users.Single(s => s.Email == "test43@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 44,
                        Email = users.Single(s => s.Email == "test44@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 45,
                        Email = users.Single(s => s.Email == "test45@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 46,
                        Email = users.Single(s => s.Email == "test46@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(4000.00),
                        Path = "/",
                        SessionID = 47,
                        Email = users.Single(s => s.Email == "test47@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(5000.00),
                        Path = "/",
                        SessionID = 48,
                        Email = users.Single(s => s.Email == "test48@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 49,
                        Email = users.Single(s => s.Email == "test49@gmail.com").Email
                    },
                    new //cookies
                    {
                        Domain = "ECS",
                        DateCreatedSessionCookie = DateTime.Now,
                        ExpirationDate = DateTime.Now.AddSeconds(6000.00),
                        Path = "/",
                        SessionID = 50,
                        Email = users.Single(s => s.Email == "test50@gmail.com").Email
                    },
            };
            //For each item in the list //cookies addorupdate a cookie with a sessionID
            //cookies.ForEach(s => context.//cookies.AddOrUpdate(p => p.SessionID, s));
            context.SaveChanges();
            **/
    }
}
