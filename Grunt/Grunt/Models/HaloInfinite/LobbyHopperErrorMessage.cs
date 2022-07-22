namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class LobbyHopperErrorMessage
    {
        public string GameStartError { get; set; }
        public int GameStartErrorId { get; set; }
        public DisplayString DisplayString { get; set; }
    }
}
