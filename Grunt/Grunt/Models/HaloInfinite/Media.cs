using OpenSpartan.Grunt.Models.HaloInfinite.ApiIngress;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
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
