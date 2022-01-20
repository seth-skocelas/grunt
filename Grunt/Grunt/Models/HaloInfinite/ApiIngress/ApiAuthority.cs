
namespace Grunt.Models.HaloInfinite.ApiIngress
{
    public class ApiAuthority
    {
        public string AuthorityId { get; set; }
        public int Scheme { get; set; }
        public string Hostname { get; set; }
        public int? Port { get; set; }
        public int[] AuthenticationMethods { get; set; }
    }
}
