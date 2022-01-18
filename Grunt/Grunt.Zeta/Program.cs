using Grunt.Authentication;
using Grunt.Core;
using Grunt.Models;
using Grunt.Util;
using System;
using System.Threading.Tasks;

namespace Grunt.Zeta
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationReader clientConfigReader = new();
            var clientConfig = clientConfigReader.ReadConfiguration<ClientConfiguration>("client.json");
            var gruntConfig = clientConfigReader.ReadConfiguration<GruntConfiguration>("grunt.json");

            XboxAuthenticationManager manager = new();
            var url = manager.GenerateAuthUrl(clientConfig.ClientId, clientConfig.RedirectUrl);

            HaloAuthenticationClient haloAuthClient = new();

            Console.WriteLine("Provide account authorization and grab the code from the URL:");
            Console.WriteLine(url);

            Console.WriteLine("Your code:");
            var code = Console.ReadLine();

            var accessToken = string.Empty;

            var ticket = new XboxTicket();
            var haloTicket = new XboxTicket();
            var extendedTicket = new XboxTicket();

            var xblToken = string.Empty;
            var haloToken = new SpartanToken();

            Task.Run(async () =>
            {
                var tokens = await manager.RequestOAuthToken(clientConfig.ClientId, code, clientConfig.RedirectUrl, clientConfig.ClientSecret);
                accessToken = tokens.AccessToken;
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                ticket = await manager.RequestUserToken(accessToken);
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                haloTicket = await manager.RequestXstsToken(ticket.Token);
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                extendedTicket = await manager.RequestXstsToken(ticket.Token, false);
            }).GetAwaiter().GetResult();

            if (ticket != null)
            {
                xblToken = manager.GetXboxLiveV3Token(haloTicket.DisplayClaims.Xui[0].Uhs, haloTicket.Token);
            }

            Task.Run(async () =>
            {
                haloToken = await haloAuthClient.GetSpartanToken(haloTicket.Token);
                Console.WriteLine("Your Halo token:");
                Console.WriteLine(haloToken.Token);
            }).GetAwaiter().GetResult();

            HaloInfiniteClient client = new HaloInfiniteClient(haloToken.Token, gruntConfig.ClearanceToken, extendedTicket.DisplayClaims.Xui[0].Xid);
            // Try getting the giveaways
            Task.Run(async () =>
            {
                var giveaways = await client.GetGiveaways();
                Console.WriteLine(giveaways.GiveawayResults.Length);
            }).GetAwaiter().GetResult();


            Console.WriteLine("This is it.");
            Console.ReadLine();
        }
    }
}
