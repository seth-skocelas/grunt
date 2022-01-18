using Grunt.Models.HaloInfinite;
using Grunt.Util;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Grunt.Core
{
    public class HaloInfiniteClient
    {
        private string _spartanToken = string.Empty;
        private string _clearanceToken = string.Empty;
        private string _xuid = string.Empty;

        public HaloInfiniteClient(string spartanToken, string clearanceToken, string xuid)
        {
            this._spartanToken = spartanToken;
            this._clearanceToken = clearanceToken;
            this._xuid = xuid;
        }

        /// <summary>
        /// Get giveaways available for a given user. Keep in mind that if you have a specific giveaway,
        /// this call will return once, after which you will no longer be able to obtain the giveaways
        /// associated with your account (they will be registered).
        /// </summary>
        /// <returns>A structured object of type HaloInfiniteGiveaway that contains the list of giveaways for the account.</returns>
        public async Task<Giveaway> GetGiveaways()
        {
            var response = await ExecuteAPIRequest(string.Format(GlobalConstants.HALO_INFINITE_GIVEAWAYS_ENDPOINT, this._xuid), 
                                           HttpMethod.Get,
                                           this._spartanToken,
                                           this._clearanceToken,
                                           GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<Giveaway>(response);
            }
            else
            {
                return null;
            }
        }

        public async Task<Customization> GetCustomization()
        {
            var response = await ExecuteAPIRequest(string.Format(GlobalConstants.HALO_INFINITE_CUSTOMIZATION_ENDPOINT, this._xuid),
                                           HttpMethod.Get,
                                           this._spartanToken,
                                           this._clearanceToken,
                                           GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<Customization>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Executes an API request in a standard way against a given API endpoint. This is a helper method that's put
        /// in place to simplify how the API calls are made because most requests against the Halo Infinite API are
        /// pretty repetitive.
        /// </summary>
        /// <param name="endpoint">The API endpoint to which the request is sent.</param>
        /// <param name="method">HTTP method to be used for the request.</param>
        /// <param name="spartanToken">Token issued by the Halo Waypoint service.</param>
        /// <param name="clearanceToken">Clearance token that is obtained from the Halo Waypoint service.</param>
        /// <param name="userAgent">User agent to be used for the request.</param>
        /// <param name="content">If the request contains data to be sent to the Halo Waypoint service, include it here. Expected format is JSON.</param>
        /// <returns>Response string in case of a successful request. Null if request failed.</returns>
        private async Task<string> ExecuteAPIRequest(string endpoint, HttpMethod method, string spartanToken, string clearanceToken, string userAgent, string content = "")
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(endpoint),
                Method = method
            };

            if (!string.IsNullOrEmpty(content))
            {
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }

            request.Headers.Add("x-343-authorization-spartan", spartanToken);
            request.Headers.Add("343-clearance", clearanceToken);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return null;
            }
        }
    }
}
