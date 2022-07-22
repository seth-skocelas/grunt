using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AssetLink : Asset
    {
        public PlayAssetStats AssetStats { get; set; }
    }
}
