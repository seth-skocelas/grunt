using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{

    public class SearchResultsContainer
    {
        public AssetTag[] Tags { get; set; }
        public int EstimatedTotal { get; set; }
        public int Start { get; set; }
        public int Count { get; set; }
        public int ResultCount { get; set; }
        public List<AssetSearchResult> Results { get; set; }
        public Links Links { get; set; }
    }
}
