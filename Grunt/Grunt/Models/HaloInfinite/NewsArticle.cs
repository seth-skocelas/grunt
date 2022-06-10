namespace Grunt.Models.HaloInfinite
{
    public class NewsArticle
    {
        public DisplayString ShortHeadline { get; set; }
        public DisplayString FullHeadline { get; set; }
        public DisplayString Body { get; set; }
        public Articleimage ArticleImage { get; set; }
        public ArticleAction[] ArticleActions { get; set; }
    }
}
