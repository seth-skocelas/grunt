namespace Grunt.Models.HaloInfinite
{
    public class Link
    {
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
