using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Prefab : Asset
    {
        public PrefabCustomData CustomData { get; set; }
        public PlayAssetStats AssetStats { get; set; }
    }
}
