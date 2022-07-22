namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Outfit
    {
        public CustomizationData CustomizationData { get; set; }
        public int OutfitID { get; set; }
    }
}
