namespace Grunt.Models.HaloInfinite
{
    public class Film
    {
        public int FilmStatusBond { get; set; }
        public CustomFilmData CustomData { get; set; }
        public string BlobStoragePathPrefix { get; set; }
        public string AssetId { get; set; }
    }
}
