using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite.ApiIngress
{
    public class ApiSettingsContainer
    {
        public Dictionary<string, ApiAuthority> Authorities { get; set; }
        public Dictionary<string, ApiRetryPolicy> RetryPolicies { get; set; }
        public ApiSettings Settings { get; set; }
        public Dictionary<string, ApiEndpoint> Endpoints { get; set; }
    }
}
