using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AssetReport : Asset
    {
        public AssetReportCustomData CustomData { get; set; }
    }
}
