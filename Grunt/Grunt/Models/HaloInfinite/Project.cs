using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    public class Project : Asset
    {
        public CustomProjectData CustomData { get; set; }
        public AssetLink[] MapLinks { get; set; }
        public object[] PlaylistLinks { get; set; }
        public object[] PrefabLinks { get; set; }
        public AssetLink[] UgcGameVariantLinks { get; set; }
        public object[] MapModePairLinks { get; set; }
        public PlayAssetStats AssetStats { get; set; }
    }
}
