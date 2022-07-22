using Grunt.Models.HaloInfinite.ApiIngress;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class File
    {
        public ApiEndpoint Uri { get; set; }
        public string ETag { get; set; }
        public int ContentLength { get; set; }
        public int Usage { get; set; }
    }
}
