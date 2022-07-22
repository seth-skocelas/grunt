// <copyright file="AuthoringAssetCustomData.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

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
