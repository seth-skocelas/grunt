namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class FlightedFeatureFlags
    {
        public string[] EnabledFeatures { get; set; }
        public string[] DisabledFeatures { get; set; }
    }

}
