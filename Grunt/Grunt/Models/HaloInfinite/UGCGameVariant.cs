using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class UGCGameVariant : Asset
    {
        public object CustomData { get; set; }
        public PlayAssetStats AssetStats { get; set; }
    }
}
