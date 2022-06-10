using Newtonsoft.Json;

namespace Grunt.Models.HaloInfinite
{
    public class SortingMetadata
    {
        [JsonProperty("categoryWeight")]
        public int CategoryWeight { get; set; }
        [JsonProperty("subCategoryWeight")]
        public int SubCategoryWeight { get; set; }
    }

}
