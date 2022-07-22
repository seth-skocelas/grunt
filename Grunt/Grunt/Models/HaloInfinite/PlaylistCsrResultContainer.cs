using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class PlaylistCsrResultContainer
    {
        public List<PlaylistCsrResults> Value { get; set; }
    }
}
