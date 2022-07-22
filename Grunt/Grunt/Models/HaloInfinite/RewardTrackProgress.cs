namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class RewardTrackProgress
    {
        public int Rank { get; set; }
        public int PartialProgress { get; set; }
        public bool IsOwned { get; set; }
    }

}
