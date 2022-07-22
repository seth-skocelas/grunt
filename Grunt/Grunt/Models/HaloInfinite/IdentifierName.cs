using System.Text.Json.Serialization;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class IdentifierName
    {
        [JsonPropertyName("m_identifier")]
        public int MIdentifier { get; set; }
    }

}
