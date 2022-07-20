namespace Grunt.Models.HaloInfinite
{

    public class Playlist
    {
        public PlaylistCustomData CustomData { get; set; }
        public object[] Tags { get; set; }
        public PlaylistRotationEntry[] RotationEntries { get; set; }
        public string AssetId { get; set; }
        public string VersionId { get; set; }
        public string PublicName { get; set; }
        public string Description { get; set; }
        public AssetVersionFile Files { get; set; }
        public object[] Contributors { get; set; }
        public int AssetHome { get; set; }
        public PlayAssetStats AssetStats { get; set; }
        public int InspectionResult { get; set; }
        public int CloneBehavior { get; set; }
        public int Order { get; set; }
    }
}
