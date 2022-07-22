using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AssetSearchResult : Asset
    {
        public string Name { get; set; }
        public string[] Tags { get; set; }
        public string ThumbnailUrl { get; set; }
        public string[] ReferencedAssets { get; set; }
        public string OriginalAuthor { get; set; }
        public int Likes { get; set; }
        public int Bookmarks { get; set; }
        public int PlaysRecent { get; set; }
        public int NumberOfObjects { get; set; }
        public APIFormattedDate DateCreatedUtc { get; set; }
        public APIFormattedDate DateModifiedUtc { get; set; }
        public APIFormattedDate DatePublishedUtc { get; set; }
        public bool HasNodeGraph { get; set; }
        public bool ReadOnlyClones { get; set; }
        public int PlaysAllTime { get; set; }
        public int ParentAssetCount { get; set; }
        public float AverageRating { get; set; }
        public int NumberOfRatings { get; set; }
    }
}
