namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class CPUPreset
    {
        public int PhysicalCores { get; set; }
        public int LogicalCores { get; set; }
        public int L3CacheSizeMB { get; set; }
        public int RAMSizeGB { get; set; }
        public int BaseFreqMHz { get; set; }
    }
}
