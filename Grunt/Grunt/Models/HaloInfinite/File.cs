using OpenSpartan.Grunt.Models.HaloInfinite.ApiIngress;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class File
    {
        public ApiEndpoint Uri { get; set; }
        public string ETag { get; set; }
        public int ContentLength { get; set; }
        public int Usage { get; set; }
    }
}
