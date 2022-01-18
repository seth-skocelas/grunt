namespace Grunt.Util
{
    internal class GlobalConstants
    {
        internal static readonly string HALO_SPARTAN_TOKEN_URL = "https://settings.svc.halowaypoint.com/spartan-token";
        internal static readonly string HALO_WAYPOINT_USER_AGENT = "HaloWaypoint/2021112313511900 CFNetwork/1327.0.4 Darwin/21.2.0";

        internal static readonly string[] DEFAULT_AUTH_SCOPES = new string[] { "Xboxlive.signin", "Xboxlive.offline_access" };
        internal static readonly string XBOX_LIVE_AUTH_URL = "https://login.live.com/oauth20_authorize.srf";
        internal static readonly string XBOX_LIVE_TOKEN_URL = "https://login.live.com/oauth20_token.srf";
        internal static readonly string XBOX_LIVE_NATIVE_RELYING_PARTY_URL = "http://auth.xboxlive.com";
        internal static readonly string XBOX_LIVE_NATIVE_AUTH_URL = "https://user.auth.xboxlive.com/user/authenticate";
        internal static readonly string XBOX_LIVE_XSTS_RELYING_PARTY = "http://xboxlive.com";
        internal static readonly string XBOX_LIVE_XSTS_AUTH_URL = "https://xsts.auth.xboxlive.com/xsts/authorize";
        internal static readonly string HALO_XSTS_RELYING_PARTY = "https://prod.xsts.halowaypoint.com/";

        // Halo API endpoints
        internal static readonly string HALO_INFINITE_GIVEAWAYS_ENDPOINT = "https://economy.svc.halowaypoint.com/hi/players/xuid({0})/giveaways";
    }
}
