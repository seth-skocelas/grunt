// <copyright file="SearchResultsContainer.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class SearchResultsContainer
    {
        public AssetTag[] Tags { get; set; }
        public int EstimatedTotal { get; set; }
        public int Start { get; set; }
        public int Count { get; set; }
        public int ResultCount { get; set; }
        public List<AssetSearchResult> Results { get; set; }
        public Links Links { get; set; }
    }
}
