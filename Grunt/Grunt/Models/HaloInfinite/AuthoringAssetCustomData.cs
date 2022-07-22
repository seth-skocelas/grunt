using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AuthoringAssetCustomData
    {
        public Dictionary<string, string> KeyValues { get; set; }
        public int FilmLength { get; set; }
        public List<FilmChunk> Chunks { get; set; }
        public bool HasGameEnded { get; set; }
        public int ManifestRefreshSeconds { get; set; }
        public string MatchId { get; set; }
        public int FilmMajorVersion { get; set; }

    }
}
