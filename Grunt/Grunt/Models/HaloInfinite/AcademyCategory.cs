namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AcademyCategory
    {
        public string DrillType { get; set; }
        public AcademyDrill[] Drills { get; set; }
    }
}
