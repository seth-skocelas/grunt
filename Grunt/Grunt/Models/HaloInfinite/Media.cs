using Grunt.Models.HaloInfinite.ApiIngress;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Media
    {
        public ApiEndpoint MediaUrl { get; set; }
        public string MimeType { get; set; }
        public DisplayString Caption { get; set; }
        public DisplayString AlternateText { get; set; }
        public string FolderPath { get; set; }
        public string FileName { get; set; }
    }

}
