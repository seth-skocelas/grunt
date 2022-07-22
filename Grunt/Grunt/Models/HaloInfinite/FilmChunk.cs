namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
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
