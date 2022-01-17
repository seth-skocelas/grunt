using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slipspace.Models
{
    public class XboxDisplayClaims
    {
        [JsonProperty("xui")]
        public XboxXui[] Xui { get; set; }
    }
}
