namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class VersionRating
    {
        public string AssetVersionId { get; set; }
        public int Score { get; set; }
        public APIFormattedDate LastModified { get; set; }
    }
}