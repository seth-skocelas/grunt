// <copyright file="ActiveChallenge.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    /// <summary>
    /// Container for active challenges associated with a player.
    /// </summary>
    [IsAutomaticallySerializable]
    public class ActiveChallenge
    {
        /// <summary>
        /// Gets or sets the path to the active challenge.
        /// </summary>
        public string? Path { get; set; }

        /// <summary>
        /// Gets or sets the progress against the goal of the challenge.
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// Gets or sets the unique challenge ID.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a challenge can reroll (be re-used).
        /// </summary>
        public bool CanReroll { get; set; }
    }

}
