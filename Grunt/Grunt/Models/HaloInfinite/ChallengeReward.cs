using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ChallengeReward
    {
        public List<InventoryAmount> InventoryItems { get; set; }
        public int OperationExperience { get; set; }
    }
}
