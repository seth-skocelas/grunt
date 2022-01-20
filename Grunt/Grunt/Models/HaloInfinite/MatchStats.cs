using System;

namespace Grunt.Models.HaloInfinite
{

    public class MatchStats
    {
        public string MatchId { get; set; }
        public MatchInfo MatchInfo { get; set; }
        public Team[] Teams { get; set; }
        public Player[] Players { get; set; }
    }

    public class Team
    {
        public int TeamId { get; set; }
        public int Outcome { get; set; }
        public int Rank { get; set; }
        public Stats Stats { get; set; }
    }

    public class Stats
    {
        public CoreStats CoreStats { get; set; }
        public object BombStats { get; set; }
        public object CaptureTheFlagStats { get; set; }
        public object EliminationStats { get; set; }
        public object ExtractionStats { get; set; }
        public object InfectionStats { get; set; }
        public object OddballStats { get; set; }
        public object ZonesStats { get; set; }
        public object StockpileStats { get; set; }
    }

    public class CoreStats
    {
        public int Score { get; set; }
        public int PersonalScore { get; set; }
        public int RoundsWon { get; set; }
        public int RoundsLost { get; set; }
        public int RoundsTied { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public float KDA { get; set; }
        public int Suicides { get; set; }
        public int Betrayals { get; set; }
        public string AverageLifeDuration { get; set; }
        public int GrenadeKills { get; set; }
        public int HeadshotKills { get; set; }
        public int MeleeKills { get; set; }
        public int PowerWeaponKills { get; set; }
        public int ShotsFired { get; set; }
        public int ShotsHit { get; set; }
        public float Accuracy { get; set; }
        public int DamageDealt { get; set; }
        public int DamageTaken { get; set; }
        public int CalloutAssists { get; set; }
        public int VehicleDestroys { get; set; }
        public int DriverAssists { get; set; }
        public int Hijacks { get; set; }
        public int EmpAssists { get; set; }
        public int MaxKillingSpree { get; set; }
        public Medal[] Medals { get; set; }
        public PersonalScore[] PersonalScores { get; set; }
        public float DeprecatedDamageDealt { get; set; }
        public float DeprecatedDamageTaken { get; set; }
    }

    public class Medal
    {
        public long NameId { get; set; }
        public int Count { get; set; }
        public int TotalPersonalScoreAwarded { get; set; }
    }

    public class PersonalScore
    {
        public long NameId { get; set; }
        public int Count { get; set; }
        public int TotalPersonalScoreAwarded { get; set; }
    }

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

    public class ParticipationInfo
    {
        public DateTime FirstJoinedTime { get; set; }
        public object LastLeaveTime { get; set; }
        public bool PresentAtBeginning { get; set; }
        public bool JoinedInProgress { get; set; }
        public bool LeftInProgress { get; set; }
        public bool PresentAtCompletion { get; set; }
        public string TimePlayed { get; set; }
        public object ConfirmedParticipation { get; set; }
    }

    public class PlayerTeamStat
    {
        public int TeamId { get; set; }
        public Stats Stats { get; set; }
    }
}
