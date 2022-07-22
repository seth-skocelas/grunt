// <copyright file="EliminationStats.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class EliminationStats
    {
        public int AlliesRevived { get; set; }
        public int EliminationAssists { get; set; }
        public int Eliminations { get; set; }
        public int EnemyRevivesDenied { get; set; }
        public int Executions { get; set; }
        public int KillsAsLastPlayerStanding { get; set; }
        public int LastPlayersStandingKilled { get; set; }
        public int RoundsSurvived { get; set; }
        public int TimesRevivedByAlly { get; set; }
        public int? LivesRemaining { get; set; }
        public int EliminationOrder { get; set; }
    }
}
