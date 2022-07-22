namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class DevicePresetOverrides
    {
        public int Version { get; set; }
        public NvidiaPreset Nvidia { get; set; }
        public AMDPreset AMD { get; set; }
        public IntelPreset Intel { get; set; }
    }
}
