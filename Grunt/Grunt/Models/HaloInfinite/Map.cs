using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    public class Map : Asset
    {
        public CustomMapData CustomData { get; set; }
        public object[] PrefabLinks { get; set; }
        public PlayAssetStats AssetStats { get; set; }
    }
}
