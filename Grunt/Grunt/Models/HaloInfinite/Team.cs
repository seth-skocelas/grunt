namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Team
    {
        public int TeamId { get; set; }
        public int Outcome { get; set; }
        public int Rank { get; set; }
        public Stats Stats { get; set; }
    }
}
