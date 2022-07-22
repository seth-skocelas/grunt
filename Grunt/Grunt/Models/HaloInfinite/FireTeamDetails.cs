using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grunt.Models.HaloInfinite
{

    public class FireTeamDetails
    {
        public string FireteamId { get; set; }
        public int PlayerCount { get; set; }
        public int MaxPlayers { get; set; }
        public int JoinabilityStatus { get; set; }
        public object PlaylistRef { get; set; }
        public int Activity { get; set; }
        public int FireteamLeaderMenuActivity { get; set; }
    }

}
