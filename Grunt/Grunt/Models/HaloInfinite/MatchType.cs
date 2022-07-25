// <copyright file="MatchType.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    /// <summary>
    /// Types of matches that a user can query with <see cref="OpenSpartan.Grunt.Core.HaloInfiniteClient.StatsGetMatchHistory"/>.
    /// </summary>
    public enum MatchType
    {
        All,
        Matchmaking,
        Custom,
        Local
    }
}
