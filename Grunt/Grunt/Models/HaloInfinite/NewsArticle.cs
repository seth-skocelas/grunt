namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class NewsArticle
    {
        public DisplayString ShortHeadline { get; set; }
        public DisplayString FullHeadline { get; set; }
        public DisplayString Body { get; set; }
        public ArticleImage ArticleImage { get; set; }
        public ArticleAction[] ArticleActions { get; set; }
    }
}
