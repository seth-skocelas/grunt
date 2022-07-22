using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class PlayerCores
    {
        public Models.HaloInfinite.Foundation.Core[] Cores { get; set; }
    }
}
