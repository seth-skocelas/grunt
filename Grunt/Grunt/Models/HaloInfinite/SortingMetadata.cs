using System.Text.Json.Serialization;

namespace Grunt.Models.HaloInfinite
{
    public class SortingMetadata
    {
        [JsonPropertyName("categoryWeight")]
        public int CategoryWeight { get; set; }
        [JsonPropertyName("subCategoryWeight")]
        public int SubCategoryWeight { get; set; }
    }

}
