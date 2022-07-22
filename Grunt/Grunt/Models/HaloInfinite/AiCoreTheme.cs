namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AiCoreTheme : Models.HaloInfinite.Foundation.Theme
    {
        public string ModelPath { get; set; }
        public string ColorPath { get; set; }
    }
}
