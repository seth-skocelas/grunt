using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class EngineGameVariant : Asset
    {
        public PlayAssetStats AssetStats { get; set; }
        public EngineGameVariantCustomData CustomData { get; set; }
    }

}
