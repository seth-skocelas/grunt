namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class PlayerCustomization
    {
        public string Id { get; set; }
        public string ResultCode { get; set; }
        public CustomizationData Result { get; set; }
    }

}
