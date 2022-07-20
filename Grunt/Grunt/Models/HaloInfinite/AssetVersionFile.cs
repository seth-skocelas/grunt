using Grunt.Models.HaloInfinite.ApiIngress;

namespace Grunt.Models.HaloInfinite
{
    public class AssetVersionFile
    {
        public string Prefix { get; set; }
        public string[] FileRelativePaths { get; set; }
        public ApiEndpoint PrefixEndpoint { get; set; }
    }

}
