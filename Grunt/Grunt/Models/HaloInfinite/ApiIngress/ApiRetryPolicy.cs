using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpartan.Grunt.Models.HaloInfinite.ApiIngress
{
    public class ApiRetryPolicy
    {
        public string RetryPolicyId { get; set; }
        public int TimeoutMs { get; set; }
        public ApiRetryOptions RetryOptions { get; set; }
    }
}
