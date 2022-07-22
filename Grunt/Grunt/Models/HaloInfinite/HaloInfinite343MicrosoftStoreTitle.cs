// <copyright file="HaloInfinite343MicrosoftStoreTitle.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class HaloInfinite343MicrosoftStoreTitle
    {
        public StoreProductMapping[] ProductMapping { get; set; }
        public string ContainerId { get; set; }
    }
}
