using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    public class AssetLink : Asset
    {
        public AssetVersionFiles Files { get; set; }
        public object[] Contributors { get; set; }
        public PlayAssetStats AssetStats { get; set; }
    }
}
