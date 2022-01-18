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

        // Generic Halo Infinite endpoints
        internal static readonly string HALO_INFINITE_GIVEAWAYS_ENDPOINT = "https://economy.svc.halowaypoint.com/hi/players/xuid({0})/giveaways";                                                   // GetGiveaways()
        internal static readonly string HALO_INFINITE_CUSTOMIZATION_ENDPOINT = "https://economy.svc.halowaypoint.com/hi/players/xuid({0})/customization?view=private";                              // GetCustomization()
        internal static readonly string HALO_INFINITE_METADATA_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Metadata/Metadata.json";
        internal static readonly string HALO_INFINITE_PROGRESSION_ENDPOINT = "https://economy.svc.halowaypoint.com/hi/players/xuid({0})/rewardtracks/operations?view=all";
        internal static readonly string HALO_INFINITE_DECKS_ENDPOINT = "https://halostats.svc.halowaypoint.com/hi/players/xuid({0})/decks";
        internal static readonly string HALO_INFINITE_SEASON_DETAILS_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Seasons/Season{0}.json";
        internal static readonly string HALO_INFINITE_RITUAL_EVENT_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/RewardTracks/Events/Rituals/{0}.json";


        // Expect to PUT: {"BodyType":"Large","RightArm":"None","LeftArm":"None","LeftLeg":"None","RightLeg":"None","VoicePath":"Inventory/Spartan/Voices/105-000-voice-001-f2ad7c5e.json"}
        internal static readonly string HALO_INFINITE_SPARTAN_BODY_ENDPOINT = "https://economy.svc.halowaypoint.com/hi/players/xuid({0})/customization/spartanbody";
        internal static readonly string HALO_INFINITE_MODEL_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/waypoint/file/models/{0}.json";
        internal static readonly string HALO_INFINITE_ANIMATION_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/waypoint/file//animation/spartan-default.json";
        //https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/RewardTracks/Events/Rituals/ritualOlympus.json

        internal static readonly string HALO_INFINITE_ARMOR_CORE_LIST_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/waypoint/file/armor-core-list.json";
        internal static readonly string HALO_INFINITE_ARMOR_CORE_DETAILS_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/cores/armorcores/{0}.json";
        // Expect a GET: https://gamecms-hacs.svc.halowaypoint.com/hi/waypoint/file//models/olympus-body.json

        // Inventory
        internal static readonly string HALO_INFINITE_INVENTORY_ENDPOINT = "https://economy.svc.halowaypoint.com/hi/players/xuid({0})/inventory";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_HELMETS_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/Helmets/{0}.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_COATINGS_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/Coatings/{0}.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_THEME_DETAILS_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/Themes/{0}.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_KNEEPADS_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/KneePads/{0}.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_VISORS_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/Visors/{0}.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_GLOVES_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/Gloves/{0}.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_SHOULDERS_RIGHT_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/ShouldersRight/{0}.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_SHOULDERS_LEFT_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/ShouldersLeft/{0}.json";


        internal static readonly string HALO_INFINITE_VISOR_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/waypoint/file/visors/{0}.json";
        // This is an example of challenge details endpoints.
        //"https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/ChallengeContent/ClientChallengeDefinitions/WeaponChallenges/Heroic/HKillCommandoRifle.json";

        // Generic Halo endpoints
        internal static readonly string HALO_SETTINGS_ENDPOINT = "https://profile.svc.halowaypoint.com/users/me/settings";
        internal static readonly string HALO_INSIDER_ENDPOINT = "https://profile.svc.halowaypoint.com/users/me/halo-insider";
        internal static readonly string HALO_ME_ENDPOINT = "https://profile.svc.halowaypoint.com/users/me";
        internal static readonly string HALO_SERVICE_AWARDS_ENDPOINT = "https://profile.svc.halowaypoint.com/users/me/service-awards";
        internal static readonly string HALO_SERVICE_AWARDS_DETAILS_ENDPOINT = "https://wpcontent.svc.halowaypoint.com/service-awards/{0}?lang=en";

        // Redeem code and POST {"code":"DIFFERENT "}
        internal static readonly string HALO_CODE_REDEEM_ENDPOINT = "https://voucher.svc.halowaypoint.com/users/xuid(2533274855333605)/codes";

        // Edit Halo Insider status by PATCHing {"communicationsOptIn":false,"country":"US","haloGamesPlayed":["Halo5","HaloMCC","Halo4","Halo3ODST","Halo3","HaloCE","Halo5Forge","HaloReach","Halo2","HaloWars2","HaloWars","HaloFireteamRaven","HaloSpartanStrike","HaloSpartanAssault","Other"],"haloGamesPreference":["Halo5","Halo4","HaloMCC","Halo5Forge","HaloReach","Halo3ODST","HaloCE","Halo2","Halo3","Other","HaloSpartanAssault","HaloSpartanStrike","HaloFireteamRaven","HaloWars","HaloWars2"],"haloModesPreference":["Campaign","SocialMultiplayer","CampaignCoop","Multiplayer","Competitive","Other","UGC"],"preferredPlayDays":["Sunday","Saturday"],"preferredPlayTimes":["Evening","Night"],"timezone":"Pacific Standard Time","consoleOptIn":true,"consoles":["XboxOneX"],"consoleAudio":["SurroundSpeakers","GamingHeadset"],"consoleInput":["XboxOneController"],"consoleVideo":["UHD4k"],"pcOptIn":false,"pcAudio":[],"pcInput":[]}
        // "https://profile.svc.halowaypoint.com/users/me/halo-insider";
    }
}
