namespace Grunt.Models.HaloInfinite
{
    public class AuthoringAssetStats
    {
        public int Favorites { get; set; }
        public int FilmBookmarks { get; set; }
        public int Likes { get; set; }
        public AuthoringAssetRatings Ratings { get; set; }
        public int ParentAssetCount { get; set; }
        public APIFormattedDate LastModifiedDateUtc { get; set; }
        public bool IgnoreReports { get; set; }
    }
}
