namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class TestDrillCategory
    {
        public string DrillType { get; set; }
        public AcademyDrill[] Drills { get; set; }
    }

}
