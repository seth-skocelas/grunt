namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class CustomFilmData
    {
        public int FilmLength { get; set; }
        public FilmChunk[] Chunks { get; set; }
        public bool HasGameEnded { get; set; }
        public int ManifestRefreshSeconds { get; set; }
        public string MatchId { get; set; }
        public int FilmMajorVersion { get; set; }
    }

}
