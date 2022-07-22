using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class UGCGameVariant : Asset
    {
        public object CustomData { get; set; }
        public PlayAssetStats AssetStats { get; set; }
    }
}
