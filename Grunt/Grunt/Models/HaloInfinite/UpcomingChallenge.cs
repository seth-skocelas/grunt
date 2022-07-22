namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class UpcomingChallenge
    {
        public object Difficulty { get; set; }
        public object TypeIconPath { get; set; }
        public object IsUserEvent { get; set; }
        public string Path { get; set; }
        public int Progress { get; set; }
        public string Id { get; set; }
        public bool CanReroll { get; set; }
    }
}
