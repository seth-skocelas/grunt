using OpenSpartan.Grunt.Authentication;
using OpenSpartan.Grunt.Core;
using OpenSpartan.Grunt.Models;
using OpenSpartan.Grunt.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenSpartan.Grunt.Zeta
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationReader clientConfigReader = new();
            var clientConfig = clientConfigReader.ReadConfiguration<ClientConfiguration>("client.json");
            
            XboxAuthenticationClient manager = new();
            var url = manager.GenerateAuthUrl(clientConfig.ClientId, clientConfig.RedirectUrl);

            HaloAuthenticationClient haloAuthClient = new();

            OAuthToken currentOAuthToken = null;

            var ticket = new XboxTicket();
            var haloTicket = new XboxTicket();
            var extendedTicket = new XboxTicket();

            var xblToken = string.Empty;
            var haloToken = new SpartanToken();

            if (System.IO.File.Exists("tokens.json"))
            {
                Console.WriteLine("Trying to use local tokens...");

                // If a local token file exists, load the file.
                currentOAuthToken = clientConfigReader.ReadConfiguration<OAuthToken>("tokens.json");
            }
            else
            {
                currentOAuthToken = RequestNewToken(url, manager, clientConfig);
            }

            Task.Run(async () =>
            {
                ticket = await manager.RequestUserToken(currentOAuthToken.AccessToken);
                if (ticket == null)
                {
                    // There was a failure to obtain the user token, so likely we need to refresh.
                    currentOAuthToken = await manager.RefreshOAuthToken(
                        clientConfig.ClientId,
                        currentOAuthToken.RefreshToken,
                        clientConfig.RedirectUrl,
                        clientConfig.ClientSecret);

                    if (currentOAuthToken == null)
                    {
                        Console.WriteLine("Could not get the token even with the refresh token.");
                        currentOAuthToken = RequestNewToken(url, manager, clientConfig);
                    }
                    ticket = await manager.RequestUserToken(currentOAuthToken.AccessToken);
                }
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
            
            HaloInfiniteClient client = new(haloToken.Token, extendedTicket.DisplayClaims.Xui[0].Xid);

            // Test getting the clearance for local execution.
            string localClearance = string.Empty;
            Task.Run(async () =>
            {
                var clearance = (await client.SettingsGetClearance("RETAIL", "UNUSED", "222249.22.06.08.1730-0")).Result;
                if (clearance != null)
                {
                    localClearance = clearance.FlightConfigurationId;
                    client.ClearanceToken = localClearance;
                    Console.WriteLine($"Your clearance is {localClearance} and it's set in the client.");
                }
                else
                {
                    Console.WriteLine("Could not obtain the clearance.");
                }
            }).GetAwaiter().GetResult();

            // Try getting actual Halo Infinite data.
            Task.Run(async () =>
            {
                var example = await client.StatsGetMatchStats("21416434-4717-4966-9902-af7097469f74");
                Console.WriteLine("You have stats.");
            }).GetAwaiter().GetResult();

            Task.Run(async () =>
            {
                var academyData = await client.AcademyGetContent();
                Console.WriteLine("Got academy data.");
            }).GetAwaiter().GetResult();           

            // Test getting the season data.
            Task.Run(async () =>
            {
                var seasonData = await client.GameCmsGetSeasonRewardTrack(
                    "Seasons/Season7.json",
                    localClearance);
                Console.WriteLine("Got season data.");
            }).GetAwaiter().GetResult();

            // Try getting skill qualifications with SkillGetMatchPlayerResult.
            Task.Run(async () =>
            {
                List<string> sampleXuids = "xuid(2533274793272155),xuid(2533274814715980),xuid(2533274855333605),xuid(2535435749594170),xuid(2535448099228893),xuid(2535457135464780),xuid(2535466738529606),xuid(2535472868898775)".Split(',').ToList();
                var performanceData = (await client.SkillGetMatchPlayerResult("ad6a3d46-9320-44ee-94cd-c5cb39c7aedd", sampleXuids)).Result;
                Console.WriteLine("Got player performance data.");
            }).GetAwaiter().GetResult();

            // Get an example image and store it locally.
            Task.Run(async () =>
            {
                var imageData = (await client.GameCmsGetImage("progression/inventory/armor/gloves/003-001-olympus-8e7c9dff-sm.png")).Result;
                Console.WriteLine("Got image data.");
                if (imageData != null)
                {
                    System.IO.File.WriteAllBytes("image.png", imageData);
                    Console.WriteLine("Wrote sample image to file.");
                }
                else
                {
                    Console.WriteLine("Image could not be written. There was an error.");
                }
            }).GetAwaiter().GetResult();

            // Get bot customization data
            Task.Run(async () =>
            {
                var seasonData = (await client.AcademyGetBotCustomization(localClearance)).Result;
                if (seasonData != null)
                {
                    Console.WriteLine("Got but customization data.");
                }
                else
                {
                    Console.WriteLine("Could not get bot customization data.");
                }
            }).GetAwaiter().GetResult();

            // Get currency data
            Task.Run(async () =>
            {
                var currencyData = (await client.GameCmsGetCurrency("currency/currencies/cr.json", localClearance)).Result;
                if (currencyData != null)
                {
                    Console.WriteLine("Got currency data.");
                }
                else
                {
                    Console.WriteLine("Could not get currency data.");
                }
            }).GetAwaiter().GetResult();

            // Get reward data.
            Task.Run(async () =>
            {
                var rewardData = (await client.EconomyGetAwardedRewards("xuid(2533274855333605)", "Challenges-35a86ae3-017c-4b5a-b633-b2802a770e0a")).Result;
                if (rewardData != null)
                {
                    Console.WriteLine("Got reward data.");
                }
                else
                {
                    Console.WriteLine("Could not get reward data.");
                }
            }).GetAwaiter().GetResult();

            Console.ReadLine();
        }

        private static OAuthToken RequestNewToken(string url, XboxAuthenticationClient manager, ClientConfiguration clientConfig)
        {
            Console.WriteLine("Provide account authorization and grab the code from the URL:");
            Console.WriteLine(url);

            Console.WriteLine("Your code:");
            var code = Console.ReadLine();
            var currentOAuthToken = new OAuthToken();

            // If no local token file exists, request a new set of tokens.
            Task.Run(async () =>
            {
                currentOAuthToken = await manager.RequestOAuthToken(clientConfig.ClientId, code, clientConfig.RedirectUrl, clientConfig.ClientSecret);
                if (currentOAuthToken != null)
                {
                    var storeTokenResult = StoreTokens(currentOAuthToken, "tokens.json");
                    if (storeTokenResult)
                    {
                        Console.WriteLine("Stored the tokens locally.");
                    }
                    else
                    {
                        Console.WriteLine("There was an issue storing tokens locally. A new token will be requested on the next run.");
                    }
                }
                else
                {
                    Console.WriteLine("No token was obtained. There is no valid token to be used right now.");
                }
            }).GetAwaiter().GetResult();

            return currentOAuthToken;
        }

        private static bool StoreTokens(OAuthToken token, string path)
        {
            string json = JsonSerializer.Serialize(token);
            try
            {
                System.IO.File.WriteAllText(path, json);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
