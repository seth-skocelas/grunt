namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlaylistCsrContainer
    {
        public PlaylistCsr Current { get; set; }
        public PlaylistCsr SeasonMax { get; set; }
        public PlaylistCsr AllTimeMax { get; set; }
    }
}
