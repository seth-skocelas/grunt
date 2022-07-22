// <copyright file="GameVariantAssetStats.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class GameVariantAssetStats
    {
        public int Favorites { get; set; }
        public int FilmBookmarks { get; set; }
        public int Likes { get; set; }
        public AssetRating Ratings { get; set; }
        public int ParentAssetCount { get; set; }
        public APIFormattedDate LastModifiedDateUtc { get; set; }
        public bool IgnoreReports { get; set; }
    }
}
