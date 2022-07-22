using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
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
