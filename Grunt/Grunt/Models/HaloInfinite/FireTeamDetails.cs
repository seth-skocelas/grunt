// <copyright file="FireTeamDetails.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class FireTeamDetails
    {
        public string FireteamId { get; set; }
        public int PlayerCount { get; set; }
        public int MaxPlayers { get; set; }
        public int JoinabilityStatus { get; set; }
        public object PlaylistRef { get; set; }
        public int Activity { get; set; }
        public int FireteamLeaderMenuActivity { get; set; }
    }

}
