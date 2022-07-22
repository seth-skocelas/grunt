namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class PlayerDecks
    {
        public AssignedDeck[] AssignedDecks { get; set; }
        public string ClearanceId { get; set; }
    }
}
