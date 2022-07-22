using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class MapModePair : Asset
    {
        public object CustomData { get; set; }
        public Map MapLink { get; set; }
        public UGCGameVariant UgcGameVariantLink { get; set; }
        public int Order { get; set; }
    }
}
