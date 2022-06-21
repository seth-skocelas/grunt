using Newtonsoft.Json;

namespace Grunt.Models.HaloInfinite
{
    public class IdentifierName
    {
        [JsonProperty("m_identifier")]
        public int MIdentifier { get; set; }
    }

}
