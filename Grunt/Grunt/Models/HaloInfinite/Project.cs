// <copyright file="Project.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Project : Asset
    {
        public CustomProjectData CustomData { get; set; }
        public AssetLink[] MapLinks { get; set; }
        public object[] PlaylistLinks { get; set; }
        public object[] PrefabLinks { get; set; }
        public AssetLink[] UgcGameVariantLinks { get; set; }
        public object[] MapModePairLinks { get; set; }
        public PlayAssetStats AssetStats { get; set; }
    }
}
