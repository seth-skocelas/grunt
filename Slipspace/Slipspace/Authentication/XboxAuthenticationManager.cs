using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Slipspace.Authentication
{
    public class XboxAuthenticationManager
    {
        private readonly string[] DEFAULT_AUTH_SCOPES = new string[] { "Xboxlive.signin", "Xboxlive.offline_access" };

        public string GenerateAuthUrl(string clientId, string redirectUrl, string[] scopes = null, string state = "")
        {
            string baseUrl = "https://login.live.com/oauth20_authorize.srf";
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

            return baseUrl + "?" + queryString.ToString();
        }
    }
}
