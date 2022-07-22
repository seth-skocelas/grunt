namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Manufacturer
    {
        public DisplayString ManufacturerName { get; set; }
        public string ManufacturerLogoImage { get; set; }
    }
}
