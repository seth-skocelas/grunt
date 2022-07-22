namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class SeasonRewardTrack
    {
        public DisplayString DateRange { get; set; }
        public DisplayString Name { get; set; }
        public string Logo { get; set; }
        public int Number { get; set; }
        public DisplayString Description { get; set; }
        public string SummaryBackgroundPath { get; set; }
        public string ChallengesBackgroundPath { get; set; }
        public string BattlePassLogoImage { get; set; }
        public string SeasonLogoImage { get; set; }
        public string RitualLogoImage { get; set; }
        public string StorefrontBackgroundImage { get; set; }
        public string CardBackgroundImage { get; set; }
        public DisplayString NarrativeBlurb { get; set; }
        public string BattlePassSeasonUpsellBackgroundImage { get; set; }
        public string ProgressionBackgroundImage { get; set; }
    }
}
