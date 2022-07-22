// <copyright file="PlayerItem.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlayerItem
    {
        public int Amount { get; set; }
        public string ItemId { get; set; }
        public string ItemPath { get; set; }
        public string ItemType { get; set; }
        public string CoreType { get; set; }
        public string Source { get; set; }
        public APIFormattedDate FirstAcquiredDate { get;set; }
    }
}
