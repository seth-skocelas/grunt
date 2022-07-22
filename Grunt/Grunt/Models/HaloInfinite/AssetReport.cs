using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AssetReport : Asset
    {
        public AssetReportCustomData CustomData { get; set; }
    }
}
