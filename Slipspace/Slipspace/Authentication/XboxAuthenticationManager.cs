using Newtonsoft.Json;
using Slipspace.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Slipspace.Authentication
{
    public class XboxAuthenticationManager
    {
        private readonly string[] DEFAULT_AUTH_SCOPES = new string[] { "Xboxlive.signin", "Xboxlive.offline_access" };
        private readonly string XBOX_LIVE_AUTH_URL = "https://login.live.com/oauth20_authorize.srf";
        private readonly string XBOX_LIVE_TOKEN_URL = "https://login.live.com/oauth20_token.srf";
        private readonly string XBOX_LIVE_NATIVE_RELYING_PARTY_URL = "http://auth.xboxlive.com";
        private readonly string XBOX_LIVE_NATIVE_AUTH_URL = "https://user.auth.xboxlive.com/user/authenticate";

        public string GenerateAuthUrl(string clientId, string redirectUrl, string[] scopes = null, string state = "")
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            queryString.Add("client_id", clientId);
            queryString.Add("response_type", "code");
            queryString.Add("approval_prompt", "auto");

            if (scopes != null && scopes.Length > 0)
            { 
                queryString.Add("scope", String.Join(" ", scopes));
            }
            else
            {
                queryString.Add("scope", String.Join(" ", DEFAULT_AUTH_SCOPES));
            }

            queryString.Add("redirect_uri", redirectUrl);

            if (!string.IsNullOrEmpty(state))
            {
                queryString.Add("state", state);
            }

            return XBOX_LIVE_AUTH_URL + "?" + queryString.ToString();
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
                tokenRequestContent.Add("scope", String.Join(" ", DEFAULT_AUTH_SCOPES));
            }

            tokenRequestContent.Add("redirect_uri", redirectUrl);
            tokenRequestContent.Add("client_id", clientId);
            if (!string.IsNullOrEmpty(clientSecret))
            {
                tokenRequestContent.Add("client_secret", clientSecret);
            }

            var client = new HttpClient();
            var response = await client.PostAsync(XBOX_LIVE_TOKEN_URL, new FormUrlEncodedContent(tokenRequestContent));

            if (response.StatusCode == HttpStatusCode.OK)
            { 
                return JsonConvert.DeserializeObject<OAuthToken>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return null;
            }
        }

        public async Task<string> RequestUserToken(string accessToken)
        {
            XboxTicketRequest ticketData = new();
            ticketData.RelyingParty = XBOX_LIVE_NATIVE_RELYING_PARTY_URL;
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
                RequestUri = new Uri(XBOX_LIVE_NATIVE_AUTH_URL),
                Method = HttpMethod.Post,
                Content = new StringContent(JsonConvert.SerializeObject(ticketData), Encoding.UTF8, "application/json")
            };

            request.Headers.Add("x-xbl-contract-version", "1");

            var response = await client.SendAsync(request);
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
