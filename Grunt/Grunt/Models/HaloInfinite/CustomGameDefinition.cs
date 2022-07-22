// <copyright file="CustomGameDefinition.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class CustomGameDefinition
    {
        public int MaxPlayerCount { get; set; }
        public int MaxPlayersPerClient { get; set; }
        public string RulesId { get; set; }
        public int DefaultMaxFireteamSizeSliderValue { get; set; }
        public int MaxTeamCount { get; set; }
        public int MaxPlayersInMediumVmInstance { get; set; }
        public bool DefaultObserversAllowed { get; set; }
        public GameVariant DefaultMap { get; set; }
        public GameVariant DefaultGameVariant { get; set; }
    }
}
