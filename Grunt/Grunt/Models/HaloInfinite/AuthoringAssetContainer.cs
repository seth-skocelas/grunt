using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{

    public class AuthoringAssetContainer
    {
        public int EstimatedTotal { get; set; }
        public int Start { get; set; }
        public int Count { get; set; }
        public int ResultCount { get; set; }
        public List<AuthoringAsset> Results { get; set; }
        public object Links { get; set; }
    }
}
