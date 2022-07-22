namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class News
    {
        public NewsArticle[] NewsArticles { get; set; }
    }
}
