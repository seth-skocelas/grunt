namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class VersionRating
    {
        public string AssetVersionId { get; set; }
        public int Score { get; set; }
        public APIFormattedDate LastModified { get; set; }
    }
}