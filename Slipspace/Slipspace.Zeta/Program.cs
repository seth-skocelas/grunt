using Slipspace.Authentication;
using Slipspace.Util;
using System;
using System.Threading.Tasks;

namespace Slipspace.Zeta
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientConfigurationReader clientConfigReader = new();
            var config = clientConfigReader.ReadClientConfiguration();

            XboxAuthenticationManager manager = new();
            var url = manager.GenerateAuthUrl(config.ClientId, config.RedirectUrl);

            Console.WriteLine("Provide account authorization and grab the code from the URL:");
            Console.WriteLine(url);

            Console.WriteLine("Your code:");
            var code = Console.ReadLine();

            var accessToken = string.Empty;

            Task.Run(async () =>
            {
                var tokens = await manager.RequestOAuthToken(config.ClientId, code, config.RedirectUrl, config.ClientSecret);
                accessToken = tokens.AccessToken;
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                var ticket = await manager.RequestUserToken(accessToken);
                Console.WriteLine(ticket);
            }).GetAwaiter().GetResult();

            Console.WriteLine("This is it.");
            Console.ReadLine();
        }
    }
}
