namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Configuration
    {
        public int ConfigurationId { get; set; }
        public string ConfigurationPath { get; set; }
    }

}
