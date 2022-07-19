/// <summary>
/// This file is an aggregating ground for discovered URLs. It will be standardized in the future.
/// </summary>
namespace Grunt.Util
{
    internal class GlobalConstants
    {
        internal static readonly string HALO_WAYPOINT_USER_AGENT = "HaloWaypoint/2021112313511900 CFNetwork/1327.0.4 Darwin/21.2.0";
        internal static readonly string HALO_PC_USER_AGENT = "SHIVA-2043073184/6.10021.18539.0 (release; PC)";
        internal static readonly string[] DEFAULT_AUTH_SCOPES = new string[] { "Xboxlive.signin", "Xboxlive.offline_access" };


        // Generic Halo Infinite endpoints
        internal static readonly string HALO_INFINITE_GIVEAWAYS_ENDPOINT = "https://economy.svc.halowaypoint.com/hi/players/xuid({0})/giveaways";                                                   // GetGiveaways()
        internal static readonly string HALO_INFINITE_CUSTOMIZATION_ENDPOINT = "https://economy.svc.halowaypoint.com/hi/players/xuid({0})/customization?view=private";                              // GetCustomization()
        internal static readonly string HALO_INFINITE_PROGRESSION_ENDPOINT = "https://economy.svc.halowaypoint.com/hi/players/xuid({0})/rewardtracks/operations?view=all";
        internal static readonly string HALO_INFINITE_SPARTAN_BODY_ENDPOINT = "https://economy.svc.halowaypoint.com/hi/players/xuid({0})/customization/spartanbody";
        internal static readonly string HALO_INFINITE_INVENTORY_ENDPOINT = "https://economy.svc.halowaypoint.com/hi/players/xuid({0})/inventory";
        // Operation reward levels https://economy.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/stores/operationrewardlevels?flight=c1178956-c7c8-4860-a3a7-da5caa55faad
        // Boosts: https://economy.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/boosts?flight=c1178956-c7c8-4860-a3a7-da5caa55faad
        // XXP Grants: https://economy.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/stores/xpgrants?flight=c1178956-c7c8-4860-a3a7-da5caa55faad
        // HCS: https://economy.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/stores/hcs?flight=c1178956-c7c8-4860-a3a7-da5caa55faad
        // Stores boosts: https://economy.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/stores/boosts?flight=c1178956-c7c8-4860-a3a7-da5caa55faad
        // Stores operations: https://economy.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/stores/operations?flight=c1178956-c7c8-4860-a3a7-da5caa55faad
        // Stores main: https://economy.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/stores/main?flight=c1178956-c7c8-4860-a3a7-da5caa55faad
        // Cores: https://economy.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/cores?flight=c1178956-c7c8-4860-a3a7-da5caa55faad
        // Currencies: https://economy.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/currencies?flight=c1178956-c7c8-4860-a3a7-da5caa55faad
        // Event reward tracks: https://economy.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/rewardtracks/events/ritualsynthwave?flight=c1178956-c7c8-4860-a3a7-da5caa55faad 
        // POST to this: https://economy.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/currencies/cR/transactions?flight=c1178956-c7c8-4860-a3a7-da5caa55faad

        internal static readonly string HALO_INFINITE_SEASON_DETAILS_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Seasons/Season{0}.json";
        internal static readonly string HALO_INFINITE_RITUAL_EVENT_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/RewardTracks/Events/Rituals/{0}.json";
        internal static readonly string HALO_INFINITE_METADATA_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Metadata/Metadata.json";
        internal static readonly string HALO_INFINITE_VISOR_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/waypoint/file/visors/{0}.json";
        internal static readonly string HALO_INFINITE_MODEL_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/waypoint/file/models/{0}.json";
        internal static readonly string HALO_INFINITE_ANIMATION_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/waypoint/file//animation/spartan-default.json";
        //https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/RewardTracks/Events/Rituals/ritualOlympus.json
        internal static readonly string HALO_INFINITE_ARMOR_CORE_LIST_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/waypoint/file/armor-core-list.json";
        internal static readonly string HALO_INFINITE_ARMOR_CORE_DETAILS_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/cores/armorcores/{0}.json";
        // Expect a GET: https://gamecms-hacs.svc.halowaypoint.com/hi/waypoint/file//models/olympus-body.json
        // This is an example of challenge details endpoints.
        //"https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/ChallengeContent/ClientChallengeDefinitions/WeaponChallenges/Heroic/HKillCommandoRifle.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_HELMETS_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/Helmets/{0}.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_COATINGS_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/Coatings/{0}.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_THEME_DETAILS_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/Themes/{0}.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_KNEEPADS_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/KneePads/{0}.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_VISORS_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/Visors/{0}.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_GLOVES_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/Gloves/{0}.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_SHOULDERS_RIGHT_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/ShouldersRight/{0}.json";
        internal static readonly string HALO_INFINITE_INVENTORY_ARMOR_SHOULDERS_LEFT_ENDPOINT = "https://gamecms-hacs.svc.halowaypoint.com/hi/Progression/file/Inventory/Armor/ShouldersLeft/{0}.json";




        // Match progression: https://halostats.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/matches/95c34bba-901f-4282-bb0e-234e09b4c5e5/progression
        internal static readonly string HALO_INFINITE_DECKS_ENDPOINT = "https://halostats.svc.halowaypoint.com/hi/players/xuid({0})/decks";
        // Match count: https://halostats.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/matches/count
        // Inventory



        // Generic Halo endpoints
        internal static readonly string HALO_SETTINGS_ENDPOINT = "https://profile.svc.halowaypoint.com/users/me/settings";
        internal static readonly string HALO_INSIDER_ENDPOINT = "https://profile.svc.halowaypoint.com/users/me/halo-insider";
        internal static readonly string HALO_ME_ENDPOINT = "https://profile.svc.halowaypoint.com/users/me";
        internal static readonly string HALO_SERVICE_AWARDS_ENDPOINT = "https://profile.svc.halowaypoint.com/users/me/service-awards";
        // Edit Halo Insider status by PATCHing {"communicationsOptIn":false,"country":"US","haloGamesPlayed":["Halo5","HaloMCC","Halo4","Halo3ODST","Halo3","HaloCE","Halo5Forge","HaloReach","Halo2","HaloWars2","HaloWars","HaloFireteamRaven","HaloSpartanStrike","HaloSpartanAssault","Other"],"haloGamesPreference":["Halo5","Halo4","HaloMCC","Halo5Forge","HaloReach","Halo3ODST","HaloCE","Halo2","Halo3","Other","HaloSpartanAssault","HaloSpartanStrike","HaloFireteamRaven","HaloWars","HaloWars2"],"haloModesPreference":["Campaign","SocialMultiplayer","CampaignCoop","Multiplayer","Competitive","Other","UGC"],"preferredPlayDays":["Sunday","Saturday"],"preferredPlayTimes":["Evening","Night"],"timezone":"Pacific Standard Time","consoleOptIn":true,"consoles":["XboxOneX"],"consoleAudio":["SurroundSpeakers","GamingHeadset"],"consoleInput":["XboxOneController"],"consoleVideo":["UHD4k"],"pcOptIn":false,"pcAudio":[],"pcInput":[]}
        // "https://profile.svc.halowaypoint.com/users/me/halo-insider";

        internal static readonly string HALO_SERVICE_AWARDS_DETAILS_ENDPOINT = "https://wpcontent.svc.halowaypoint.com/service-awards/{0}?lang=en";

        // Redeem code and POST {"code":"DIFFERENT "}
        internal static readonly string HALO_CODE_REDEEM_ENDPOINT = "https://voucher.svc.halowaypoint.com/users/xuid(2533274855333605)/codes";


        // Playlist-based CSR: https://skill.svc.halowaypoint.com/hi/playlist/edfef3ac-9cbe-4fa2-b949-8f29deafd483/csrs?flight=c1178956-c7c8-4860-a3a7-da5caa55faad&players=xuid(2533274855333605)&season=CsrSeason1

        // Map screenshot: https://blobs-infiniteugc.svc.halowaypoint.com/ugcstorage/map/4f196016-0101-4844-8358-2504f7c44656/b7a5f610-4a9c-49de-85f0-2e9aa81193a3/images/screenshot1.png

    }
    // Tags: https://discovery-infiniteugc.svc.halowaypoint.com/hi/info/tags?flight=c1178956-c7c8-4860-a3a7-da5caa55faad
    // Spectate match: https://discovery-infiniteugc.svc.halowaypoint.com/hi/films/matches/d356949b-0d39-4cda-8521-fa474d41a480/spectate
    // Map details (Arena - live fire): https://discovery-infiniteugc.svc.halowaypoint.com/hi/mapModePairs/8651ab45-349a-49ae-8b2c-383ebfb0f664/versions/99aafa58-1dca-48fa-ae8f-d412c6f13a0f
    // Arena - Recharge: https://discovery-infiniteugc.svc.halowaypoint.com/hi/mapModePairs/54993269-2aff-4bd0-b81c-83b7f84ca9f9/versions/78d24a48-9709-41a0-b84e-ef5805d63a2b
}

// POST presence: https://lobby-hi.svc.halowaypoint.com/hi/presence
// QoS Servers: https://lobby-hi.svc.halowaypoint.com/titles/hi/qosservers
// 3P lobby alias: https://lobby-hi.svc.halowaypoint.com/hi/lobbies/467716e9-71c2-4bbb-b3a4-4398bda2946b/players/xuid(2533274855333605)/thirdPartyJoinHandle?audience=Friends&platform=Discord

// Ban processor: https://banprocessor.svc.halowaypoint.com/hi/bansummary?auth=st&targets=Authenticated(Device),xuid(2533274855333605)

// PUT here to rate the game https://authoring-infiniteugc.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/ratings/UgcGameVariants/4d0f6e15-cc3f-46e0-9d06-22de6311c4cb
// PUT request to favorite rematch: https://authoring-infiniteugc.svc.halowaypoint.com/hi/players/xuid(2533274855333605)/favorites/UgcGameVariants/4d0f6e15-cc3f-46e0-9d06-22de6311c4cb

// Me: https://wpcomms.svc.halowaypoint.com/users/me
// Notifications: https://wpcomms.svc.halowaypoint.com/users/me/notifications?offset=0&limit=20
// Notifications count: https://wpcomms.svc.halowaypoint.com/users/me/notifications/count