// <copyright file="Playlist.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Playlist
    {
        public PlaylistCustomData CustomData { get; set; }
        public object[] Tags { get; set; }
        public PlaylistRotationEntry[] RotationEntries { get; set; }
        public string AssetId { get; set; }
        public string VersionId { get; set; }
        public string PublicName { get; set; }
        public string Description { get; set; }
        public AssetVersionFile Files { get; set; }
        public object[] Contributors { get; set; }
        public int AssetHome { get; set; }
        public PlayAssetStats AssetStats { get; set; }
        public int InspectionResult { get; set; }
        public int CloneBehavior { get; set; }
        public int Order { get; set; }
    }
}
