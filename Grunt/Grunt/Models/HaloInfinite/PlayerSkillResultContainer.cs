using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class PlayerSkillResultContainer
    {
        public List<PlayerSkillResult> Value { get; set; }
    }
}
