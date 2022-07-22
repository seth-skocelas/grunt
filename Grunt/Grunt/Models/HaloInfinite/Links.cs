using Grunt.Models.HaloInfinite.ApiIngress;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Links
    {
        public ApiEndpoint Self { get; set; }
    }

}
