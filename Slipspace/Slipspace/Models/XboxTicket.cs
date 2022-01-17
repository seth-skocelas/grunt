using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slipspace.Models
{
    public class XboxTicket
    {
        public DateTime IssueInstant { get; set; }
        public DateTime NotAfter { get; set; }
        public string Token { get; set; }
        public XboxDisplayClaims DisplayClaims { get; set; }
    }
}
