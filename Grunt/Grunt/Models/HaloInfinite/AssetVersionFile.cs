using Grunt.Models.HaloInfinite.ApiIngress;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AssetVersionFile
    {
        public string Prefix { get; set; }
        public string[] FileRelativePaths { get; set; }
        public ApiEndpoint PrefixEndpoint { get; set; }
    }

}
