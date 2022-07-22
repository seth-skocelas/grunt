namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AppearanceCustomization
    {
        public string Status { get; set; }
        public Appearance Appearance { get; set; }
    }
}
