// <copyright file="ApiEndpoint.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

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
