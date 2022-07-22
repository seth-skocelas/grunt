namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlayerCustomization
    {
        public string Id { get; set; }
        public string ResultCode { get; set; }
        public CustomizationData Result { get; set; }
    }

}
