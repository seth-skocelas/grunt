namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AcademyCategory
    {
        public string DrillType { get; set; }
        public AcademyDrill[] Drills { get; set; }
    }
}
