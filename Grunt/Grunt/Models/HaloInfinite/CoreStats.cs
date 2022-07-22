namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
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
}
