namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ActiveChallenge
    {
        public string Path { get; set; }
        public int Progress { get; set; }
        public string Id { get; set; }
        public bool CanReroll { get; set; }
    }

}
