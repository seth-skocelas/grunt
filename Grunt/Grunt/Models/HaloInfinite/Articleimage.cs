namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class ArticleImage
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Path { get; set; }
    }
}
