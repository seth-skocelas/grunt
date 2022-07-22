using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpartan.Grunt.Models.HaloInfinite.ApiIngress
{
    public class ApiEndpoint
    {
        public string EndpointId { get; set; }
        public string AuthorityId { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string RetryPolicyId { get; set; }
        public string TopicName { get; set; }
        public int AcknowledgementTypeId { get; set; }
        public bool AuthenticationLifetimeExtensionSupported { get; set; }
        public bool ClearanceAware { get; set; }
    }
}
