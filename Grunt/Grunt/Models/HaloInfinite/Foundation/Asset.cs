namespace Grunt.Models.HaloInfinite.Foundation
{
    public abstract class Asset
    {
        public string AssetId { get; set; }
        public string AssetVersionId { get; set; }
        public string PublicName { get; set; }
        public string Description { get; set; }
        public int InspectionResult { get; set; }
        public int CloneBehavior { get; set; }
        public int AssetHome { get; set; }
        public object[] Tags { get; set; }
        public object[] Contributors { get; set; }
        public AssetVersionFile Files { get; set; }
        public string VersionId { get; set; }
        public int AssetKind { get; set; }
    }
}
