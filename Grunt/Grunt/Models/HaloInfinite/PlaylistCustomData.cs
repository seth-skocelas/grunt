namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlaylistCustomData
    {
        public PlaylistEntry[] PlaylistEntries { get; set; }
        public int Strategy { get; set; }
        public int MinTeams { get; set; }
        public int MinTeamSize { get; set; }
        public int MaxTeams { get; set; }
        public int MaxTeamSize { get; set; }
        public int MaxTeamImbalance { get; set; }
        public int MaxSplitscreenPlayersAllowed { get; set; }
        public bool AllowFriendJoinInProgress { get; set; }
        public bool AllowMatchmakingJoinInProgress { get; set; }
        public bool AllowBotJoinInProgress { get; set; }
        public int ExitExperienceDurationSec { get; set; }
        public bool FireteamLeaderKickAllowed { get; set; }
        public bool DisableMidgameChat { get; set; }
        public int[] AllowedDeviceInputs { get; set; }
        public int BotDifficulty { get; set; }
        public int MinFireteamSize { get; set; }
        public int MaxFireteamSize { get; set; }
    }
}
