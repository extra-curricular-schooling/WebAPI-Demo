using ECS.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ECS.DTO;
using System.Net.Http.Headers;
using System.Net;

namespace HttpClientConsole
{
    class Program
    {
        static void Showaccount(SSOAccountRegistrationDTO account)
        {
            Console.WriteLine($"Name: {account.Username}\tPassword: " +
                $"{account.Password}");
        }
        
        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            using (HttpClientService client = HttpClientService.SsoInstance)
            {
                // Update port # in the following line.

                try
                {
                    // Create a new account
                    SSOAccountRegistrationDTO account = new SSOAccountRegistrationDTO
                    {
                        Username = "dkdkd",
                        Password = "aaaaaa",
                        SecurityQuestions = new List<AccountQuestionDTO>
                        {
                            new AccountQuestionDTO
                            {
                                Question = 4,
                                Answer = "My mother"
                            }
                        }
                    };

                    var message = await client.PostAsJsonAsync("https://localhost:44311/SSO/ResetPassword", account);
                    Console.WriteLine(message);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
