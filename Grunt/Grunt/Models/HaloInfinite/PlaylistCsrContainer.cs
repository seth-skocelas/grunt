namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class PlaylistCsrContainer
    {
        public PlaylistCsr Current { get; set; }
        public PlaylistCsr SeasonMax { get; set; }
        public PlaylistCsr AllTimeMax { get; set; }
    }
}
