namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AcademyDrill
    {
        public string TitleStringID { get; set; }
        public AcademySeries[] Series { get; set; }
        public int SpriteFrameIndex { get; set; }
        public string DescriptionStringID { get; set; }
    }
}
