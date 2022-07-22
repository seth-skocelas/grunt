// <copyright file="AuthoringAssetRating.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
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
