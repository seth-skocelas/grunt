using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{

    public class AuthoringAssetVersionContainer
    {
        public int Start { get; set; }
        public int Count { get; set; }
        public int ResultCount { get; set; }
        public List<AuthoringAssetVersion> Results { get; set; }
        public object[] Links { get; set; }
    }
}
