namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class PlayerTeamStat
    {
        public int TeamId { get; set; }
        public Stats Stats { get; set; }
    }
}
