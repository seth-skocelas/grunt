// <copyright file="AuthoringAsset.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AuthoringAsset
    {
        public string AssetId { get; set; }
        public int Kind { get; set; }
        public string OriginalOwner { get; set; }
        public string Admin { get; set; }
        public APIFormattedDate LastModifiedDateUtc { get; set; }
        public APIFormattedDate CreatedDateUtc { get; set; }
        public string InternalName { get; set; }
        public string Description { get; set; }
        public APIFormattedDate HardDeleteTimeUtc { get; set; }
        public List<Permission> Permissions { get; set; }
        public AuthoringAssetStats AssetStats { get; set; }
        public int AssetHome { get; set; }
        public bool IsCurrentlyBeingEdited { get; set; }
    }
}
