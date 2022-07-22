using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ChallengeReward
    {
        public List<InventoryAmount> InventoryItems { get; set; }
        public int OperationExperience { get; set; }
    }
}
