using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlayerSkillResult : ResultContainer
    {
        public SkillResult Result { get; set; }
    }
}
