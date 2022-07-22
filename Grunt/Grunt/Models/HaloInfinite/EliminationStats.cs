namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class EliminationStats
    {
        public int AlliesRevived { get; set; }
        public int EliminationAssists { get; set; }
        public int Eliminations { get; set; }
        public int EnemyRevivesDenied { get; set; }
        public int Executions { get; set; }
        public int KillsAsLastPlayerStanding { get; set; }
        public int LastPlayersStandingKilled { get; set; }
        public int RoundsSurvived { get; set; }
        public int TimesRevivedByAlly { get; set; }
        public int? LivesRemaining { get; set; }
        public int EliminationOrder { get; set; }
    }
}
