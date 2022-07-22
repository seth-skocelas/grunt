namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class TestDrillCategory
    {
        public string DrillType { get; set; }
        public AcademyDrill[] Drills { get; set; }
    }

}
