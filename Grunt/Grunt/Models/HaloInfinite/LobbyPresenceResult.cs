using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class LobbyPresenceResult
    {
        public FireTeamDetails FireteamDetails { get; set; }
        public object MatchDetails { get; set; }
    }

}
