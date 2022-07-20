using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    public class PlaylistRotationEntry : Asset
    {
        public PlaylistMapModePairMetadata Metadata { get; set; }
        public PlayAssetStats AssetStats { get; set; }
    }
}
