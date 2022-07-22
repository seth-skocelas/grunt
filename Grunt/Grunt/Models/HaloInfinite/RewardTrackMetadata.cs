namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class RewardTrackMetadata
    {
        public string TrackId { get; set; }
        public int XpPerRank { get; set; }
        public RankSnapshot[] Ranks { get; set; }
        public DisplayString Name { get; set; }
        public DisplayString Description { get; set; }
        public int OperationNumber { get; set; }
        public DisplayString DateRange { get; set; }
        public bool IsRitual { get; set; }
        public string SummaryImagePath { get; set; }
        public int WeekNumber { get; set; }
        public string BackgroundImagePath { get; set; }
    }
}
