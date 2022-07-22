namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class PlaylistEntry
    {
        public string MapModePairAssetId { get; set; }
        public PlaylistMapModePairMetadata Metadata { get; set; }
    }
}
