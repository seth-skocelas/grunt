namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Player
    {
        public string PlayerId { get; set; }
        public int PlayerType { get; set; }
        public object BotAttributes { get; set; }
        public int LastTeamId { get; set; }
        public int Outcome { get; set; }
        public int Rank { get; set; }
        public ParticipationInfo ParticipationInfo { get; set; }
        public PlayerTeamStat[] PlayerTeamStats { get; set; }
    }
}
