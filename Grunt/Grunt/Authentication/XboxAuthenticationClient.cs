// <copyright file="XboxAuthenticationClient.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Grunt.Endpoints;
using Grunt.Models;
using Grunt.Util;

namespace Grunt.Authentication
{
    /// <summary>
    /// Xbox authentication client, used to provide the scaffolding to get the
    /// proper Xbox Live tokens.
    /// </summary>
    public class XboxAuthenticationClient
    {
        /// <summary>
        /// Generates the authentication URL that can be used to produce the temporary code
        /// for subsequent Xbox Live authentication flows.
        /// </summary>
        /// <param name="clientId">Client ID defined for the registered application in the Azure Portal.</param>
        /// <param name="redirectUrl">Redirect URL defined for the registered application in the Azure Portal.</param>
        /// <param name="scopes">A list of scopes used for authentication against the Xbox Live APIs.</param>
        /// <param name="state">Temporary state indicator.</param>
        /// <returns>Returns the full authentication URL that can be pasted in a web browser.</returns>
        public string GenerateAuthUrl(string clientId, string redirectUrl, string[]? scopes = null, string state = "")
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

        /// <summary>
        /// Requests the OAuth token for the Xbox Live authentication flow.
        /// </summary>
        /// <param name="clientId">Client ID defined for the registered application in the Azure Portal.</param>
        /// <param name="authorizationCode">Authorization code provided by visiting the URL from the <see cref="GenerateAuthUrl"/> function.</param>
        /// <param name="redirectUrl">Redirect URL defined for the registered application in the Azure Portal.</param>
        /// <param name="clientSecret">Client secret defined for the registered application in the Azure Portal.</param>
        /// <param name="scopes">A list of scopes used for authentication against the Xbox Live APIs.</param>
        /// <returns>If successful, returns an instance of <see cref="OAuthToken"/> representing the OAuth token used for authentication. Otherwise, returns null.</returns>
        public async Task<OAuthToken?> RequestOAuthToken(string clientId, string authorizationCode, string redirectUrl, string clientSecret = "", string[]? scopes = null)
        {
            Dictionary<string, string> tokenRequestContent = new()
            {
                { "grant_type", "authorization_code" },
                { "code", authorizationCode },
                { "approval_prompt", "auto" },
            };

            if (scopes != null && scopes.Length > 0)
            {
                tokenRequestContent.Add("scope", string.Join(" ", scopes));
            }
            else
            {
                tokenRequestContent.Add("scope", string.Join(" ", GlobalConstants.DEFAULT_AUTH_SCOPES));
            }

            tokenRequestContent.Add("redirect_uri", redirectUrl);
            tokenRequestContent.Add("client_id", clientId);
            if (!string.IsNullOrEmpty(clientSecret))
            {
                tokenRequestContent.Add("client_secret", clientSecret);
            }

            var client = new HttpClient();
            var response = await client.PostAsync(XboxEndpoints.XboxLiveToken, new FormUrlEncodedContent(tokenRequestContent));

            return response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<OAuthToken>(response.Content.ReadAsStringAsync().Result)
                : null;
        }

        /// <summary>
        /// Refreshes an existing OAuth token.
        /// </summary>
        /// <param name="clientId">Client ID defined for the registered application in the Azure Portal.</param>
        /// <param name="refreshToken">Refresh token obtained from a previous authorization flow.</param>
        /// <param name="redirectUrl">Redirect URL defined for the registered application in the Azure Portal.</param>
        /// <param name="clientSecret">Client secret defined for the registered application in the Azure Portal.</param>
        /// <param name="scopes">A list of scopes used for authentication against the Xbox Live APIs.</param>
        /// <returns>If successful, returns an instance of <see cref="OAuthToken"/> representing the OAuth token used for authentication. Otherwise, returns null.</returns>
        public async Task<OAuthToken?> RefreshOAuthToken(string clientId, string refreshToken, string redirectUrl, string clientSecret = "", string[]? scopes = null)
        {
            Dictionary<string, string> tokenRequestContent = new();

            tokenRequestContent.Add("grant_type", "refresh_token");
            tokenRequestContent.Add("refresh_token", refreshToken);

            if (scopes != null && scopes.Length > 0)
            {
                tokenRequestContent.Add("scope", string.Join(" ", scopes));
            }
            else
            {
                tokenRequestContent.Add("scope", string.Join(" ", GlobalConstants.DEFAULT_AUTH_SCOPES));
            }

            tokenRequestContent.Add("redirect_uri", redirectUrl);
            tokenRequestContent.Add("client_id", clientId);
            if (!string.IsNullOrEmpty(clientSecret))
            {
                tokenRequestContent.Add("client_secret", clientSecret);
            }

            var client = new HttpClient();
            var response = await client.PostAsync(XboxEndpoints.XboxLiveToken, new FormUrlEncodedContent(tokenRequestContent));

            return response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<OAuthToken>(response.Content.ReadAsStringAsync().Result)
                : null;
        }

        /// <summary>
        /// Requests a user token for Xbox Live API authentication.
        /// </summary>
        /// <param name="accessToken">Previously generated Xbox Live OAuth access token.</param>
        /// <returns>If successful, returns an instance of <see cref="XboxTicket"/> representing the authentication ticket. Otherwise, returns null.</returns>
        public async Task<XboxTicket?> RequestUserToken(string accessToken)
        {
            XboxTicketRequest ticketData = new()
            {
                RelyingParty = XboxEndpoints.XboxLiveAuthRelyingParty,
                TokenType = "JWT",
                Properties = new XboxTicketProperties()
                {
                    AuthMethod = "RPS",
                    SiteName = "user.auth.xboxlive.com",
                    RpsTicket = string.Concat("d=", accessToken),
                },
            };

            var client = new HttpClient();

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(XboxEndpoints.XboxLiveUserAuthenticate),
                Method = HttpMethod.Post,
                Content = new StringContent(JsonSerializer.Serialize(ticketData), Encoding.UTF8, "application/json"),
            };

            request.Headers.Add("x-xbl-contract-version", "1");

            var response = await client.SendAsync(request);
            var responseData = response.Content.ReadAsStringAsync().Result;

            return response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<XboxTicket>(responseData)
                : null;
        }

        /// <summary>
        /// Requests the Xbox Live Security Token (XSTS) token for use with Halo API authentication flow.
        /// </summary>
        /// <param name="userToken">Previously generated Xbox Live user token.</param>
        /// <param name="useHaloRelyingParty">Determines whether the Halo relying party is used or a more generic Xbox Live one. Using the Xbox Live relying party will not enable you to access Halo APIs.</param>
        /// <returns>If successful, returns an instance of <see cref="XboxTicket"/> representing the authentication ticket. Otherwise, returns null.</returns>
        public async Task<XboxTicket?> RequestXstsToken(string userToken, bool useHaloRelyingParty = true)
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
                SandboxId = "RETAIL",
            };

            var client = new HttpClient();
            var data = JsonSerializer.Serialize(ticketData);

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(XboxEndpoints.XboxLiveXstsAuthorize),
                Method = HttpMethod.Post,
                Content = new StringContent(data, Encoding.UTF8, "application/json"),
            };

            request.Headers.Add("x-xbl-contract-version", "1");

            var response = await client.SendAsync(request);
            var responseData = response.Content.ReadAsStringAsync().Result;

            return response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<XboxTicket>(responseData)
                : null;
        }

        /// <summary>
        /// Assemble existing token pieces into a valid Xbox Live 3.0 token.
        /// </summary>
        /// <param name="userHash">User has for the authenticating Xbox Live user.</param>
        /// <param name="userToken">Previously generated Xbox Live user token.</param>
        /// <returns>The assembled Xbox Live 3.0 token string.</returns>
        public string GetXboxLiveV3Token(string userHash, string userToken)
        {
            return $"XBL3.0 x={userHash};{userToken}";
        }
    }
}
