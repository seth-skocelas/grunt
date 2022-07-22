namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class OverrideQuery
    {
        public Query[] Query { get; set; }
        public OverrideSettings Settings { get; set; }
    }


}
