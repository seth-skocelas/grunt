namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class FlightedFeatureFlags
    {
        public string[] EnabledFeatures { get; set; }
        public string[] DisabledFeatures { get; set; }
    }

}
