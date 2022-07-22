namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlayerDecks
    {
        public AssignedDeck[] AssignedDecks { get; set; }
        public string ClearanceId { get; set; }
    }
}
