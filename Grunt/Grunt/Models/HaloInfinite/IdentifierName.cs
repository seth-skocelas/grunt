using System.Text.Json.Serialization;

namespace Grunt.Models.HaloInfinite
{
    public class IdentifierName
    {
        [JsonPropertyName("m_identifier")]
        public int MIdentifier { get; set; }
    }

}
