using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class LobbyPresenceResultContainer
    {
        public string Id { get; set; }
        public int ResultCode { get; set; }
        public LobbyPresenceResult Result { get; set; }
    }

}
