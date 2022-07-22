namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class PerformanceValue
    {
        public int Count { get; set; }
        public double Expected { get; set; }
        public double StdDev { get; set; }
    }
}
