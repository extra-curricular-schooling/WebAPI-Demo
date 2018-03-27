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
using ECS.DTO.Sso;
using ECS.WebAPI.Services.HttpClients;

namespace HttpClientConsole
{
    class Program
    {
        static void Showaccount(SsoRegistrationDTO account)
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
                    SsoRegistrationDTO account = new SsoRegistrationDTO
                    {
                        Username = "dkdkd",
                        Password = "aaaaaa"
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
