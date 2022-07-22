using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class MatchesPrivacy
    {
        public int MatchmadeGames { get; set; }
        public int OtherGames { get; set; }
    }

}
