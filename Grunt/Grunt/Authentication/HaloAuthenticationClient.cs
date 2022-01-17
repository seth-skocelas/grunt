using Newtonsoft.Json;
using Grunt.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Grunt.Authentication
{
    public class HaloAuthenticationClient
    {
        public readonly string HALO_SPARTAN_TOKEN_URL = "https://settings.svc.halowaypoint.com/spartan-token";
        public readonly string HALO_WAYPOINT_USER_AGENT = "HaloWaypoint/2021112313511900 CFNetwork/1327.0.4 Darwin/21.2.0";

        public async Task<SpartanToken> GetSpartanToken(string xstsToken)
        {
            SpartanTokenRequest tokenRequest = new();
            tokenRequest.Audience = "urn:343:s3:services";
            tokenRequest.MinVersion = "4";
            tokenRequest.Proof = new SpartanTokenProof[]
            {
                new SpartanTokenProof()
                {
                    Token = xstsToken,
                    TokenType = "Xbox_XSTSv3"
                }
            };

            var client = new HttpClient();
            var data = JsonConvert.SerializeObject(tokenRequest);

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(HALO_SPARTAN_TOKEN_URL),
                Method = HttpMethod.Post,
                Content = new StringContent(data, Encoding.UTF8, "application/json")
            };

            request.Headers.Add("User-Agent", HALO_WAYPOINT_USER_AGENT);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<SpartanToken>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return null;
            }
        }
    }
}
