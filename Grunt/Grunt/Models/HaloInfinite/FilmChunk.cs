// <copyright file="FilmChunk.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class FilmChunk
    {
        public int Index { get; set; }
        public int ChunkStartTimeOffsetMilliseconds { get; set; }
        public int DurationMilliseconds { get; set; }
        public int ChunkSize { get; set; }
        public string FileRelativePath { get; set; }
        public int ChunkType { get; set; }
    }

}
