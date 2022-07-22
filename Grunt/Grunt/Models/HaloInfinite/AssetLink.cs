using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AssetLink : Asset
    {
        public PlayAssetStats AssetStats { get; set; }
    }
}
