namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AuthoringAssetRatings
    {
        public float AverageRating { get; set; }
        public int TotalCount { get; set; }
        //TODO: Figure out what this is.
        public object[] Ratings { get; set; }
    }
}
