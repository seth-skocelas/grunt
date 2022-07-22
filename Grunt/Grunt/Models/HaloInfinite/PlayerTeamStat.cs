namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlayerTeamStat
    {
        public int TeamId { get; set; }
        public Stats Stats { get; set; }
    }
}
