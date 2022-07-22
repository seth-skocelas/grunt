namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class CPUPresetSnapshot
    {
        public CPUPreset Low { get; set; }
        public CPUPreset Medium { get; set; }
        public CPUPreset High { get; set; }
        public CPUPreset Ultra { get; set; }
    }
}
