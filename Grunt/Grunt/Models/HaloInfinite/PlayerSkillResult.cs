using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlayerSkillResult : ResultContainer
    {
        public SkillResult Result { get; set; }
    }
}
