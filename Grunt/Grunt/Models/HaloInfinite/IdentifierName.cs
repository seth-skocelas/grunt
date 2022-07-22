using System.Text.Json.Serialization;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class IdentifierName
    {
        [JsonPropertyName("m_identifier")]
        public int MIdentifier { get; set; }
    }

}
