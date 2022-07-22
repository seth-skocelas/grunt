namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class BanSummary
    {
        public BanSummaryResult[] Results { get; set; }
        public Links Links { get; set; }
    }
}
