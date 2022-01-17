using Slipspace.Authentication;
using Slipspace.Models;
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

            HaloAuthenticationClient haloAuthClient = new();

            Console.WriteLine("Provide account authorization and grab the code from the URL:");
            Console.WriteLine(url);

            Console.WriteLine("Your code:");
            var code = Console.ReadLine();

            var accessToken = string.Empty;
            var ticket = new XboxTicket();
            var xblToken = string.Empty;
            var haloToken = new SpartanToken();

            Task.Run(async () =>
            {
                var tokens = await manager.RequestOAuthToken(config.ClientId, code, config.RedirectUrl, config.ClientSecret);
                accessToken = tokens.AccessToken;
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                ticket = await manager.RequestUserToken(accessToken);
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                ticket = await manager.RequestXstsToken(ticket.Token);
            }).GetAwaiter().GetResult();

            if (ticket != null)
            {
                xblToken = manager.GetXboxLiveV3Token(ticket.DisplayClaims.Xui[0].Uhs, ticket.Token);
            }

            Task.Run(async () =>
            {
                haloToken = await haloAuthClient.GetSpartanToken(ticket.Token);
                Console.WriteLine("Your Halo token:");
                Console.WriteLine(haloToken.Token);
            }).GetAwaiter().GetResult();

            Console.WriteLine("This is it.");
            Console.ReadLine();
        }
    }
}
