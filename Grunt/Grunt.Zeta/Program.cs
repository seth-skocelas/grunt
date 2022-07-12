using Grunt.Authentication;
using Grunt.Core;
using Grunt.Models;
using Grunt.Models.HaloInfinite;
using Grunt.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace Grunt.Zeta
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationReader clientConfigReader = new();
            var clientConfig = clientConfigReader.ReadConfiguration<ClientConfiguration>("client.json");
            //var gruntConfig = clientConfigReader.ReadConfiguration<GruntConfiguration>("grunt.json");

            XboxAuthenticationManager manager = new();
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
                    currentOAuthToken = await manager.RefreshOAuthToken(clientConfig.ClientId, currentOAuthToken.RefreshToken, clientConfig.RedirectUrl, clientConfig.ClientSecret);
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
            
            HaloInfiniteClient client = new(haloToken.Token, extendedTicket.DisplayClaims.Xui[0].Xid, "");

            var xuidDict = new Dictionary<string, string>();

            using (var reader = new StreamReader(@"C:\ReportCard\xuids.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    xuidDict[values[0]] = values[1];
                }

            }

            var resultsDict = new Dictionary<string, List<PlayerSkillResultValue>>();
            var matchesDict = new Dictionary<string, List<string>>();

            // Try getting actual Halo Infinite data.
            Task.Run(async () =>
            {
                var matchIds = new List<string>();
                foreach (KeyValuePair<string, string> entry in xuidDict)
                {
                    var xuid = entry.Value;

                    var test = await client.StatsGetMatchHistory("xuid(" + xuid + ")");

                    matchIds = new List<string>();

                    foreach (var r in test.Results)
                    {
                        matchIds.Add(r.MatchId);
                    }

                    var playerSkillResultList = new List<PlayerSkillResultValue>();

                    foreach (var id in matchIds)
                    {
                        var xuidList = new List<string>();
                        xuidList.Add("xuid(" + xuid + ")");
                        playerSkillResultList.Add(await client.SkillGetMatchPlayerResult(id, xuidList));
                    }
                    resultsDict[entry.Key] = playerSkillResultList;
                    matchesDict[entry.Key] = matchIds;
                    Console.WriteLine(entry.Key + " is done");
                }
                ExcelCreator.WriteAllPlayersSkillResultValue(resultsDict, matchesDict);
            }).GetAwaiter().GetResult();

            Console.WriteLine("This is it.");
            Console.ReadLine();
        }

        private static OAuthToken RequestNewToken(string url, XboxAuthenticationManager manager, ClientConfiguration clientConfig)
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
            string json = JsonConvert.SerializeObject(token);
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
