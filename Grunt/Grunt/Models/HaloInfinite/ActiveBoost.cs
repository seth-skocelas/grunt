namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ActiveBoost
    {
        public APIFormattedDate ExpirationDate { get; set; }
        public string State { get; set; }
        public string BoostPath { get; set; }
        public float EffectiveMultiplier { get; set; }
        public int Matches { get; set; }
    }
}
