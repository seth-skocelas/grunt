using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class PlaylistRotationEntry : Asset
    {
        public PlaylistMapModePairMetadata Metadata { get; set; }
        public PlayAssetStats AssetStats { get; set; }
    }
}
