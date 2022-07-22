﻿namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AcademyDrill
    {
        public string TitleStringID { get; set; }
        public AcademySeries[] Series { get; set; }
        public int SpriteFrameIndex { get; set; }
        public string DescriptionStringID { get; set; }
    }
}
