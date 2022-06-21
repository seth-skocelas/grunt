namespace Grunt.Models.HaloInfinite
{
    public class CustomGameDefinition
    {
        public int MaxPlayerCount { get; set; }
        public int MaxPlayersPerClient { get; set; }
        public string RulesId { get; set; }
        public int DefaultMaxFireteamSizeSliderValue { get; set; }
        public int MaxTeamCount { get; set; }
        public int MaxPlayersInMediumVmInstance { get; set; }
        public bool DefaultObserversAllowed { get; set; }
        public GameVariant DefaultMap { get; set; }
        public GameVariant DefaultGameVariant { get; set; }
    }
}
