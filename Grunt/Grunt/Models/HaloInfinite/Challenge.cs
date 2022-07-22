namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Challenge
    {
        public DisplayString Description { get; set; }
        public string Difficulty { get; set; }
        public string Category { get; set; }
        public Reward Reward { get; set; }
        public int ThresholdForSuccess { get; set; }
        public DisplayString Title { get; set; }
    }
}
