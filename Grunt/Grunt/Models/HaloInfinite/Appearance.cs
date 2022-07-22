namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Appearance
    {
        public APIFormattedDate? LastModifiedDateUtc { get; set; }
        public string ServiceTag { get; set; }
        public string ActionPosePath { get; set; }
        public string StancePath { get; set; }
        public string BackdropImagePath { get; set; }
        public Emblem Emblem { get; set; }
        public string IntroEmotePath { get; set; }
    }
}
