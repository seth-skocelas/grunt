namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class TestAcademyTutorial
    {
        public string Title { get; set; }
        public TestDrill[] Series { get; set; }
        public int SpriteFrameIndex { get; set; }
    }

}
