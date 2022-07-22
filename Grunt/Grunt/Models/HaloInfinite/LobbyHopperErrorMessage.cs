// <copyright file="LobbyHopperErrorMessage.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class LobbyHopperErrorMessage
    {
        public string GameStartError { get; set; }
        public int GameStartErrorId { get; set; }
        public DisplayString DisplayString { get; set; }
    }
}
