using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AssetReport : Asset
    {
        public AssetReportCustomData CustomData { get; set; }
    }
}
