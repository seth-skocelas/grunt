using Grunt.Models.HaloInfinite.Foundation;
using System;

namespace Grunt.Models.HaloInfinite
{
    public class MatchInfo
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Duration { get; set; }
        public int LifecycleMode { get; set; }
        public int GameVariantCategory { get; set; }
        public string LevelId { get; set; }
        public Asset MapVariant { get; set; }
        public UGCGameVariant UgcGameVariant { get; set; }
        public string ClearanceId { get; set; }
        public Asset Playlist { get; set; }
        public int PlaylistExperience { get; set; }
        public Asset PlaylistMapModePair { get; set; }
        public string SeasonId { get; set; }
        public string PlayableDuration { get; set; }
        public bool TeamsEnabled { get; set; }
        public bool TeamScoringEnabled { get; set; }
    }

}
