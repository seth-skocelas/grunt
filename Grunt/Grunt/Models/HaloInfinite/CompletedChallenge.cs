namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class CompletedChallenge
    {
        public string Path { get; set; }
        public int Progress { get; set; }
        public string Id { get; set; }
        public bool CanReroll { get; set; }
    }
}
