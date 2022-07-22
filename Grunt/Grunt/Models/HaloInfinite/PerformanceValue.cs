namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PerformanceValue
    {
        public int Count { get; set; }
        public double Expected { get; set; }
        public double StdDev { get; set; }
    }
}
