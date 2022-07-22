using System.Text.Json.Serialization;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class SortingMetadata
    {
        [JsonPropertyName("categoryWeight")]
        public int CategoryWeight { get; set; }
        [JsonPropertyName("subCategoryWeight")]
        public int SubCategoryWeight { get; set; }
    }

}
