using Newtonsoft.Json;
using Grunt.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Grunt.Util;
using Grunt.Endpoints;

namespace Grunt.Authentication
{
    public class XboxAuthenticationManager
    {


        public string GenerateAuthUrl(string clientId, string redirectUrl, string[] scopes = null, string state = "")
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            queryString.Add("client_id", clientId);
            queryString.Add("response_type", "code");
            queryString.Add("approval_prompt", "auto");

            if (scopes != null && scopes.Length > 0)
            { 
                queryString.Add("scope", string.Join(" ", scopes));
            }
            else
            {
                queryString.Add("scope", string.Join(" ", GlobalConstants.DEFAULT_AUTH_SCOPES));
            }

            queryString.Add("redirect_uri", redirectUrl);

            if (!string.IsNullOrEmpty(state))
            {
                queryString.Add("state", state);
            }

            return XboxEndpoints.XboxLiveAuthorize + "?" + queryString.ToString();
        }

        public async Task<OAuthToken> RequestOAuthToken(string clientId, string authorizationCode, string redirectUrl, string clientSecret = "", string[] scopes = null)
        {
            Dictionary<string,string> tokenRequestContent = new();

            tokenRequestContent.Add("grant_type", "authorization_code");
            tokenRequestContent.Add("code", authorizationCode);
            tokenRequestContent.Add("approval_prompt", "auto");

            if (scopes != null && scopes.Length > 0)
            {
                tokenRequestContent.Add("scope", String.Join(" ", scopes));
            }
            else
            {
                tokenRequestContent.Add("scope", String.Join(" ", GlobalConstants.DEFAULT_AUTH_SCOPES));
            }

            tokenRequestContent.Add("redirect_uri", redirectUrl);
            tokenRequestContent.Add("client_id", clientId);
            if (!string.IsNullOrEmpty(clientSecret))
            {
                tokenRequestContent.Add("client_secret", clientSecret);
            }

            var client = new HttpClient();
            var response = await client.PostAsync(XboxEndpoints.XboxLiveToken, new FormUrlEncodedContent(tokenRequestContent));

            if (response.IsSuccessStatusCode)
            { 
                return JsonConvert.DeserializeObject<OAuthToken>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return null;
            }
        }

        public async Task<OAuthToken> RefreshOAuthToken(string clientId, string refreshToken, string redirectUrl, string clientSecret = "", string[] scopes = null)
        {
            Dictionary<string, string> tokenRequestContent = new();

            tokenRequestContent.Add("grant_type", "refresh_token");
            tokenRequestContent.Add("refresh_token", refreshToken);

            if (scopes != null && scopes.Length > 0)
            {
                tokenRequestContent.Add("scope", String.Join(" ", scopes));
            }
            else
            {
                tokenRequestContent.Add("scope", String.Join(" ", GlobalConstants.DEFAULT_AUTH_SCOPES));
            }

            tokenRequestContent.Add("redirect_uri", redirectUrl);
            tokenRequestContent.Add("client_id", clientId);
            if (!string.IsNullOrEmpty(clientSecret))
            {
                tokenRequestContent.Add("client_secret", clientSecret);
            }

            var client = new HttpClient();
            var response = await client.PostAsync(XboxEndpoints.XboxLiveToken, new FormUrlEncodedContent(tokenRequestContent));

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<OAuthToken>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return null;
            }
        }

        public async Task<XboxTicket> RequestUserToken(string accessToken)
        {
            XboxTicketRequest ticketData = new();
            ticketData.RelyingParty = XboxEndpoints.XboxLiveAuthRelyingParty;
            ticketData.TokenType = "JWT";
            ticketData.Properties = new XboxTicketProperties()
            {
                AuthMethod = "RPS",
                SiteName = "user.auth.xboxlive.com",
                RpsTicket = string.Concat("d=", accessToken)
            };

            var client = new HttpClient();

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(XboxEndpoints.XboxLiveUserAuthenticate),
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(ticketData), Encoding.UTF8, "application/json")
            };

            request.Headers.Add("x-xbl-contract-version", "1");

            var response = await client.SendAsync(request);
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<XboxTicket>(responseData);
            }
            else
            {
                return null;
            }
        }

        public async Task<XboxTicket> RequestXstsToken(string userToken, bool useHaloRelyingParty = true)
        {
            XboxTicketRequest ticketData = new();

            if (useHaloRelyingParty)
            {
                ticketData.RelyingParty = HaloCoreEndpoints.HaloWaypointXstsRelyingParty;
            }
            else
            {
                ticketData.RelyingParty = XboxEndpoints.XboxLiveRelyingParty;
            }

            ticketData.TokenType = "JWT";
            ticketData.Properties = new XboxTicketProperties()
            {
                UserTokens = new string[] { userToken },
                SandboxId = "RETAIL"
            };

            var client = new HttpClient();
            var data = JsonConvert.SerializeObject(ticketData);

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(XboxEndpoints.XboxLiveXstsAuthorize),
                Method = HttpMethod.Post,
                Content = new StringContent(data, Encoding.UTF8, "application/json")
            };

            request.Headers.Add("x-xbl-contract-version", "1");

            var response = await client.SendAsync(request);
            var responseData = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<XboxTicket>(responseData);
            }
            else
            {
                return null;
            }
        }

        public string GetXboxLiveV3Token(string userHash, string userToken)
        {
            return $"XBL3.0 x={userHash};{userToken}";
        }
    }
}
