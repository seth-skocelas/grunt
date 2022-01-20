using Grunt.Endpoints;
using Grunt.Models.HaloInfinite;
using Grunt.Models.HaloInfinite.ApiIngress;
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
        private string _xuid = string.Empty;
        private string _clearanceToken = string.Empty;

        public HaloInfiniteClient(string spartanToken, string xuid, string clearanceToken = "")
        {
            this._spartanToken = spartanToken;
            this._xuid = xuid;
            this._clearanceToken = clearanceToken;
        }

        public async Task<ApiSettingsContainer> GetApiSettingsContainer()
        {
            var response = await ExecuteAPIRequest(SettingsEndpoints.HIPC,
                                           HttpMethod.Get,
                                           false,
                                           false,
                                           GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<ApiSettingsContainer>(response);
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
        private async Task<string> ExecuteAPIRequest(string endpoint, HttpMethod method, bool useSpartanToken, bool useClearance, string content = "")
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

            if (useSpartanToken)
            {
                request.Headers.Add("x-343-authorization-spartan", this._spartanToken);
            }

            if (useClearance)
            {
                request.Headers.Add("343-clearance", this._clearanceToken);
            }
            
            request.Headers.Add("User-Agent", GlobalConstants.HALO_WAYPOINT_USER_AGENT);
            request.Headers.Add("Accept-Content", "application/json");

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
