namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class OverrideQuery
    {
        public Query[] Query { get; set; }
        public OverrideSettings Settings { get; set; }
    }


}
