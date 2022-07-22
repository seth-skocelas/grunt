namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Achievement
    {
        public int Id { get; set; }
        public string XboxLiveId { get; set; }
        public string SteamId { get; set; }
    }

}
