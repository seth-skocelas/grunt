namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Server
    {
        public string Region { get; set; }
        public string ServerUrl { get; set; }
    }

}
