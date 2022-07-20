using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grunt.Models
{
    public class XboxDisplayClaims
    {
        [JsonPropertyName("xui")]
        public XboxXui[] Xui { get; set; }
    }
}
