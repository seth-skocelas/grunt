namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Film
    {
        public int FilmStatusBond { get; set; }
        public CustomFilmData CustomData { get; set; }
        public string BlobStoragePathPrefix { get; set; }
        public string AssetId { get; set; }
    }
}
