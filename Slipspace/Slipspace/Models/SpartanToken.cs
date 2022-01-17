using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slipspace.Models
{

    public class SpartanToken
    {
        [JsonProperty("SpartanToken")]
        public string Token { get; set; }
        public SpartanTokenExpirationDate ExpiresUtc { get; set; }
        public string TokenDuration { get; set; }
    }
}
