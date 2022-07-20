using Grunt.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Grunt.Util;
using Grunt.Endpoints;
using System.Text.Json;

namespace Grunt.Authentication
{
    public class HaloAuthenticationClient
    {
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
            var data = JsonSerializer.Serialize(tokenRequest);

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(SettingsEndpoints.SpartanTokenV4),
                Method = HttpMethod.Post,
                Content = new StringContent(data, Encoding.UTF8, "application/json")
            };

            request.Headers.Add("User-Agent", GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<SpartanToken>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return null;
            }
        }
    }
}
