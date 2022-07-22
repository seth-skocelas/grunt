namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class ArticleAction
    {
        public DisplayString ActionTitle { get; set; }
        public DisplayString ActionDescription { get; set; }
        public string ActionUri { get; set; }
    }
}
