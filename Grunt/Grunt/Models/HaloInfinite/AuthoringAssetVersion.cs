using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AuthoringAssetVersion
    {
        public AuthoringAssetCustomData CustomData { get; set; }
        public AssetVersionFile AssetVersionFiles { get; set; }
        public Dictionary<string,List<TargetAsset>> Links { get; set; }
        public string AssetId { get; set; }
        public string AssetVersionId { get; set; }
        public string PublicName { get; set; }
        public string Description { get; set; }
        public APIFormattedDate CreatedDate { get; set; }
        public APIFormattedDate LastModifiedDate { get; set; }
        public int VersionNumber { get; set; }
        public string Note { get; set; }
        public int AssetState { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Contributors { get; set; }
        public int AssetHome { get; set; }
        public bool ExemptFromAutoDelete { get; set; }
        public int InspectionResult { get; set; }
        public int CloneBehavior { get; set; }
        public string Player { get; set; }
        public string StringCulture { get; set; }
        public string? PreviousAssetVersionId { get; set; }
    }
}
