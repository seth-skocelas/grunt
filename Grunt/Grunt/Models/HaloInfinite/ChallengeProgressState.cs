namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class ChallengeProgressState
    {
        public string Path { get; set; }
        public string Id { get; set; }
        public int PreviousProgress { get; set; }
        public int Progress { get; set; }
    }
}
