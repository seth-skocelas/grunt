using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slipspace.Models
{
    public class SpartanTokenRequest
    {
        public string Audience { get; set; }
        public string MinVersion { get; set; }
        public SpartanTokenProof[] Proof { get; set; }
    }
}
