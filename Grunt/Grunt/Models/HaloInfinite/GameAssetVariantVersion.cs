using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    public class GameAssetVariantVersion : Asset
    {
        public CustomAssetData CustomData { get; set; }
        public AssetVersionFiles AssetVersionFiles { get; set; }
        public AssetLinks Links { get; set; }
        public SpartanDate CreatedDate { get; set; }
        public SpartanDate LastModifiedDate { get; set; }
        public int VersionNumber { get; set; }
        public string Note { get; set; }
        public int AssetState { get; set; }
        public object[] Tags { get; set; }
        public object[] Contributors { get; set; }
        public int AssetHome { get; set; }
        public bool ExemptFromAutoDelete { get; set; }
        public string Player { get; set; }
        public string StringCulture { get; set; }
        public string PreviousAssetVersionId { get; set; }
    }
}
