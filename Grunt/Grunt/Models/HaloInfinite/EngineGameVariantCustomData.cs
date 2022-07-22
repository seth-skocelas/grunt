namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class EngineGameVariantCustomData
    {
        public SubsetDataContainer SubsetData { get; set; }
        public LocalizedDataContainer LocalizedData { get; set; }
    }

}
