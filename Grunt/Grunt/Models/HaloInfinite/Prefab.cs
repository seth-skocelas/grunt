using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Prefab : Asset
    {
        public PrefabCustomData CustomData { get; set; }
        public PlayAssetStats AssetStats { get; set; }
    }
}
