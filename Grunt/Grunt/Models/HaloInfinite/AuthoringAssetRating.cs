using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AuthoringAssetRating
    {
        //TODO: Figure out what this is.
        public object Links { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AssetId { get; set; }
        public string AssetVersionId { get; set; }
        public AuthoringAssetRatingCustomData CustomData { get; set; }
        public List<VersionRating> VersionRatings { get; set; }
        public int AssetKind { get; set; }
    }
}
