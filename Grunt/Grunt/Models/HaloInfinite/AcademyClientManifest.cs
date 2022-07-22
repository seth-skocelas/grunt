namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AcademyClientManifest
    {
        public AcademyTutorial Tutorial { get; set; }
        public AcademyCategory[] Categories { get; set; }
    }
}
