using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlaylistRotationEntry : Asset
    {
        public PlaylistMapModePairMetadata Metadata { get; set; }
        public PlayAssetStats AssetStats { get; set; }
    }
}
