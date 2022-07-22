using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlaylistCsrResults : ResultContainer
    {
        public PlaylistCsrContainer Result { get; set; }
    }
}
