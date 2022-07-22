// <copyright file="FavoriteAsset.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;
using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class FavoriteAsset : Asset
    {
        //TODO: Figure out what the type is here.
        public object Links { get; set; }
        public string Name { get; set; }
        //TODO: Figure out what the type is here.
        public object CustomData { get; set; }
        public List<VersionRating> VersionRatings { get; set; }
    }
}
