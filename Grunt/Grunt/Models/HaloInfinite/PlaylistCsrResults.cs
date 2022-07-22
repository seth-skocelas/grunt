using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class PlaylistCsrResults : ResultContainer
    {
        public PlaylistCsrContainer Result { get; set; }
    }
}
