namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ChallengeProgressState
    {
        public string Path { get; set; }
        public string Id { get; set; }
        public int PreviousProgress { get; set; }
        public int Progress { get; set; }
    }
}
