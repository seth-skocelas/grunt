namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class SubsetDataContainer
    {
        public int StatBucketGameType { get; set; }
        public string EngineName { get; set; }
        public string VariantName { get; set; }
    }

}
