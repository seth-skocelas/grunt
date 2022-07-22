using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Manifest : Asset
    {
        public ManifestCustomData CustomData { get; set; }
        public Map[] MapLinks { get; set; }
        public UGCGameVariant[] UgcGameVariantLinks { get; set; }
        public object[] PlaylistLinks { get; set; }
        public EngineGameVariant[] EngineGameVariantLinks { get; set; }
        public PlayAssetStats AssetStats { get; set; }
    }
}
