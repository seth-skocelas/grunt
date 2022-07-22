// <copyright file="Asset.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite.Foundation
{
    public abstract class Asset
    {
        public string AssetId { get; set; }
        public string VersionId { get; set; }
        public string AssetVersionId { get; set; }
        public string PublicName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int InspectionResult { get; set; }
        public int CloneBehavior { get; set; }
        public int AssetHome { get; set; }
        public string[] Tags { get; set; }
        public string[] Contributors { get; set; }
        public AssetVersionFile Files { get; set; }
        public int AssetKind { get; set; }
        public int Order { get; set; }
    }
}
