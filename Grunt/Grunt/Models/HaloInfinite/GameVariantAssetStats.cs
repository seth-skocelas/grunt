namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class GameVariantAssetStats
    {
        public int Favorites { get; set; }
        public int FilmBookmarks { get; set; }
        public int Likes { get; set; }
        public AssetRating Ratings { get; set; }
        public int ParentAssetCount { get; set; }
        public APIFormattedDate LastModifiedDateUtc { get; set; }
        public bool IgnoreReports { get; set; }
    }

}
