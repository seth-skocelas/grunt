namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AcademyTutorial
    {
        public string Title { get; set; }
        public AcademySeries[] Series { get; set; }
        public int SpriteFrameIndex { get; set; }
    }
}
