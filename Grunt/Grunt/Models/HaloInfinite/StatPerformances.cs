namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class StatPerformances
    {
        public PerformanceValue Kills { get; set; }
        public PerformanceValue Deaths { get; set; }
    }
}
