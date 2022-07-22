using OpenSpartan.Grunt.Models.HaloInfinite.ApiIngress;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AssetVersionFile
    {
        public string Prefix { get; set; }
        public string[] FileRelativePaths { get; set; }
        public ApiEndpoint PrefixEndpoint { get; set; }
    }

}
