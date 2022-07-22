namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AssetRating
    {
        public float AverageRating { get; set; }
        public int TotalCount { get; set; }
        public object[] Ratings { get; set; }
    }

}
