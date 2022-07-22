namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AssetRating
    {
        public float AverageRating { get; set; }
        public int TotalCount { get; set; }
        public object[] Ratings { get; set; }
    }

}
