namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AcademyClientManifest
    {
        public AcademyTutorial Tutorial { get; set; }
        public AcademyCategory[] Categories { get; set; }
    }
}
