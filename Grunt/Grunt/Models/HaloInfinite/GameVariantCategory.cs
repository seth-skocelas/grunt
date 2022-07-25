// <copyright file="MatchInfo.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    /// <summary>
    /// Category a game variant falls into.
    /// </summary>
    public enum GameVariantCategory
    {
        MultiplayerSlayer = 6,
        MultiplayerAttrition = 7,
        MultiplayerFiesta = 9,
        MultiplayerStrongholds = 11,
        MultiplayerBastion = 12,
        MultiplayerCtf = 15,
        MultiplayerOddball = 18,
        MultiplayerGrifball = 25,
        MultiplayerLandGrab = 39,
    }
}