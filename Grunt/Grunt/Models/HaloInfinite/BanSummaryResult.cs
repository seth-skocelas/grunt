using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class BanSummaryResult : ResultContainer
    {
        public BanResult Result { get; set; }
    }

}
