using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{

    public class GameAssetVariant : Asset
    {
        public int Kind { get; set; }
        public string OriginalOwner { get; set; }
        public string Admin { get; set; }
        public SpartanDate LastModifiedDateUtc { get; set; }
        public SpartanDate CreatedDateUtc { get; set; }
        public string InternalName { get; set; }
        public object HardDeleteTimeUtc { get; set; }
        public Permission[] Permissions { get; set; }
        public GameVariantAssetStats AssetStats { get; set; }
        public bool IsCurrentlyBeingEdited { get; set; }
    }
}
