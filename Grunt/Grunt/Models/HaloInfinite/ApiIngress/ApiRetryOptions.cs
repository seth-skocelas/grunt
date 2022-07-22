using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpartan.Grunt.Models.HaloInfinite.ApiIngress
{
    public class ApiRetryOptions
    {
        public int MaxRetryCount { get; set; }
        public int RetryDelayMs { get; set; }
        public float RetryGrowth { get; set; }
        public int RetryJitterMs { get; set; }
        public bool RetryIfNotFound { get; set; }
    }
}
