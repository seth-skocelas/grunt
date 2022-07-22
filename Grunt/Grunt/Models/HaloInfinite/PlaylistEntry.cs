namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlaylistEntry
    {
        public string MapModePairAssetId { get; set; }
        public PlaylistMapModePairMetadata Metadata { get; set; }
    }
}
