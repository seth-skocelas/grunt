using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpartan.Grunt.Models
{

    public class SpartanToken
    {
        [JsonPropertyName("SpartanToken")]
        public string Token { get; set; }
        public APIFormattedDate ExpiresUtc { get; set; }
        public string TokenDuration { get; set; }
    }
}
