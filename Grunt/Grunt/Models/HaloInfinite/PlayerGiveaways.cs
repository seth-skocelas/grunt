// <copyright file="PlayerGiveaways.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlayerGiveaways
    {
        // TODO: This needs to be tweaked to see what giveaways are available
        // and represent that through the correct strongly-typed entity rather
        // than a plain object.
        public object[] GiveawayResults { get; set; }
    }

}
