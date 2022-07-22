namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class CustomizationData
    {
        public SpartanBody SpartanBody { get; set; }
        public Appearance Appearance { get; set; }
        public ArmorCoreCollection ArmorCores { get; set; }
        public WeaponCoreCollection WeaponCores { get; set; }
        public AiCoreCollection AiCores { get; set; }
        public VehicleCoreCollection VehicleCores { get; set; }
    }
}
