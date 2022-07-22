// <copyright file="AssetAuthoringSession.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AssetAuthoringSession
    {
        public string ContainerUri { get; set; }
        public string ContainerSas { get; set; }
        public APIFormattedDate ExpirationTime { get; set; }
        public bool ReadOnly { get; set; }
        public string SessionId { get; set; }
        public string AssetId { get; set; }
        public CustomAssetData CustomData { get; set; }
        public string PublicName { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
        public AuthoringAssetLinks Links { get; set; }
        public string[] Contributors { get; set; }
        public string StringCulture { get; set; }
        public string PreviousAssetVersionId { get; set; }
        public AssetVersionFile ContainerFiles { get; set; }
    }
}
