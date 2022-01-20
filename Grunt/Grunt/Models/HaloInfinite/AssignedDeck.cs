namespace Grunt.Models.HaloInfinite
{
    public class AssignedDeck
    {
        public string Id { get; set; }
        public string Path { get; set; }
        public ActiveChallenge[] ActiveChallenges { get; set; }
        public UpcomingChallenge[] UpcomingChallenges { get; set; }
        public WaypointDate Expiration { get; set; }
        public CompletedChallenge[] CompletedChallenges { get; set; }
    }

}
