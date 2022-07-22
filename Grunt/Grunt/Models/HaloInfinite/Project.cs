using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
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
