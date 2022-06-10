using Grunt.Endpoints;
using Grunt.Models.HaloInfinite;
using Grunt.Models.HaloInfinite.ApiIngress;
using Grunt.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Grunt.Core
{
    public class HaloInfiniteClient
    {
        private string _spartanToken = string.Empty;
        private string _xuid = string.Empty;
        private string _clearanceToken = string.Empty;

        public ApiSettingsContainer EndpointData { get; private set; }

        public HaloInfiniteClient(string spartanToken, string xuid, string clearanceToken = "")
        {
            this._spartanToken = spartanToken;
            this._xuid = xuid;
            this._clearanceToken = clearanceToken;

            EndpointData = JsonConvert.DeserializeObject<ApiSettingsContainer>(File.ReadAllText("endpoints.json"));
        }

        public string SpartanToken
        {
            get
            {
                return _spartanToken;
            }
            set
            {
                _spartanToken = value;
            }
        }

        public string Xuid
        {
            get
            {
                return _xuid;
            }
            set
            {
                _xuid = value;
            }
        }

        public string ClearanceToken
        {
            get
            {
                return _clearanceToken;
            }
            set
            {
                _clearanceToken = value;
            }
        }


        /// <summary>
        /// Gets the list of API settings as provided by the official Halo API. This is the latest version of all available endpoints.
        /// </summary>
        /// <returns>An instance of ApiSettingsContainer if the call is successful. Otherwise, returns null.</returns>
        public async Task<ApiSettingsContainer> GetApiSettingsContainer()
        {
            var response = await ExecuteAPIRequest<string>(SettingsEndpoints.HIPC,
                                           HttpMethod.Get,
                                           false,
                                           false,
                                           GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<ApiSettingsContainer>(response);
            }
            else
            {
                return null;
            }
        }

        //================================================
        // Academy
        //================================================

        /// <summary>
        /// Get bot customization information.
        /// </summary>
        /// <param name="flightId">ID of the flight/clearance associated with the request.</param>
        /// <returns>If successful, returns an instance of BotCustomizationData that contains bot customization information. Otherwise, returns null.</returns>
        public async Task<BotCustomizationData> AcademyGetBotCustomization(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/multiplayer/file/Academy/BotCustomizationData.json?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<BotCustomizationData>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the client manifest for the Academy.
        /// </summary>
        /// <returns>If successful, returns an instance of AcademyClientManifest that contains the definition of drills available in the Academy. Otherwise, returns null.</returns>
        public async Task<AcademyClientManifest> AcademyGetContent()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/multiplayer/file/Academy/AcademyClientManifest.json",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<AcademyClientManifest>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the client manifest for the Academy. From the endpoint name we can infer that this is test data.
        /// </summary>
        /// <param name="clearanceId">ID of the flight/clearance associated with the request.</param>
        /// <returns>If successful, returns an instance of TestAcademyClientManifest that contains the definition of drills available in the Academy. Otherwise, returns null.</returns>
        public async Task<TestAcademyClientManifest> AcademyGetContentTest(string clearanceId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/multiplayer/file/Academy/AcademyClientManifest_Test.json?flight={clearanceId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<TestAcademyClientManifest>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets definitions for stars awarded in the Academy. This call breaks if a user agent is specified.
        /// </summary>
        /// <returns>If successful, returns an instance of AcademyStarDefinitions that contains definitions for stars awarded in the Academy. Otherwise, returns null.</returns>
        public async Task<AcademyStarDefinitions> AcademyGetStarDefinitions()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/multiplayer/file/Academy/AcademyStarGUIDDefinitions.json",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<AcademyStarDefinitions>(response);
            }
            else
            {
                return null;
            }
        }

        //================================================
        // Crashes
        //================================================

        /// <summary>
        /// Uploads crash information. Have not yet seen this live in the game, and have no information on how it works at this time.
        /// </summary>
        /// <returns>Uknown.</returns>
        private async Task<string> CrashesUpload()
        {
            var response = await ExecuteAPIRequest<string>($"https://crashes.svc.halowaypoint.com:443/crashes/hipc/bf05b320-ee8f-4be5-879d-505b669654c9",
                                   HttpMethod.Get,
                                   false,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //================================================
        // Economy
        //================================================

        /// <summary>
        /// Gets information about an individual AI Core.
        /// </summary>
        /// <param name="player">The player identifier in the format "xuid(XUID_VALUE)".</param>
        /// <param name="coreId">Unique AI Core ID.</param>
        /// <returns>An instance of Core containing AI core customization metadata if request was successful. Return value is null otherwise.</returns>
        public async Task<Models.HaloInfinite.Core> EconomyAiCoreCustomization(string player, string coreId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/ais/{coreId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<Models.HaloInfinite.Core>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get AI core customization for a player.
        /// </summary>
        /// <param name="player">The player identifier in the format "xuid(XUID_VALUE)".</param>
        /// <returns>An instance of AiCores containing AI core customization metadata if request was successful. Return value is null otherwise.</returns>
        public async Task<AiCores> EconomyAiCoresCustomization(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/ais",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<AiCores>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get details about all owned cores for a player.
        /// </summary>
        /// <param name="player">The player identifier in the format "xuid(000000)"</param>
        /// <returns>An instance of PlayerCores containing player core customization metadata if request was successful. Return value is null otherwise.</returns>
        public async Task<PlayerCores> EconomyAllOwnedCoresDetails(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/cores",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<PlayerCores>(response);
            }
            else
            {
                return null;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyArmorCoreCustomization(string player, string coreId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/armors/{coreId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyArmorCoresCustomization(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/armors",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyGetActiveBoosts(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/boosts",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyGetAwardedRewards(string player, string rewardId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/rewards/{rewardId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyGetBoostsStore(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/boosts",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyGetEventsStore(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/events",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyGetGiveawayRewards(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/giveaways",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyGetHCSStore(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/hcs",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyGetInventoryItems(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/inventory",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyGetMainStore(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/main",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyGetMultiplePlayersCustomization()
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/customization",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyGetOperationRewardLevelsStore(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/operationrewardlevels",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyGetOperationsStore(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/operations",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyGetRewardTrack(string player, string rewardTrackType, string trackId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/rewardtracks/{rewardTrackType}s/{trackId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyGetVirtualCurrencyBalances(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/currencies",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyGetXpGrantsStore(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/xpgrants",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyOwnedCoreDetails(string player, string coreId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/cores/{coreId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyPlayerAppearanceCustomization(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/appearance",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyPlayerCustomization(string player, string viewType)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization?view={viewType}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyPlayerOperations(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/rewardtracks/operations",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyPostCurrencyTransaction(string player, string currencyId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/currencies/{currencyId}/transactions",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyPurchaseStorefrontOfferingTransaction(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/storetransactions",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyScheduledStorefrontOfferings(string player, string storeId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/{storeId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomySpartanBodyCustomization(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/spartanbody",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyVehicleCoreCustomization(string player, string coreId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/vehicles/{coreId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyVehicleCoresCustomization(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/vehicles",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyWeaponCoreCustomization(string player, string coreId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/weapons/{coreId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> EconomyWeaponCoresCustomization(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/weapons",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //================================================
        // GameCms
        //================================================
        /// <summary>
        /// Returns the collection of available achievements to unlock in the game.
        /// </summary>
        /// <remarks>
        /// Keep in mind that this is not a list of achievements that the player has unlocked - it's just an aggregation of all available achievements in Halo Infinite.
        /// </remarks>
        /// <returns>If successful, returns an instance of AchievementCollection that contains the list of available achievements. Otherwise, returns null.</returns>
        public async Task<AchievementCollection> GameCmsGetAchievements()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Multiplayer/file/Live/Achievements.json",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<AchievementCollection>(response);
            }
            else
            {
                return null;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetArmorCoreManifest(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/Inventory/Manifest/armorcores.json?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetAsyncComputeOverrides()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Specs/file/graphics/AsyncComputeOverrides.json",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetBanMessage(string messageIdentity, string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Banning/file/BanMessages/{messageIdentity}.json?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetChallenge(string challengePath, string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/{challengePath}?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetChallengeDeck(string challengeDeckPath, string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/{challengeDeckPath}?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetClawAccess(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/TitleAuthorization/file/claw/access.json?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetCpuPresets()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Specs/file/cpu/presets.json",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetCustomGameDefaults()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Multiplayer/file/NonMatchmaking/customgame.json",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetCustomizationCatalog(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/inventory/catalog/inventory_catalog.json?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets information about graphic device preset overrides.
        /// </summary>
        /// <remarks>
        /// The exact purpose of this function is unknown at this time, and requires additional investigation.
        /// </remarks>
        /// <returns>If successful, and instance of DevicePresetOverrides. Otherwise, returs null.</returns>
        public async Task<DevicePresetOverrides> GameCmsGetDevicePresetOverrides()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Specs/file/graphics/DevicePresetOverrides.json",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<DevicePresetOverrides>(response);
            }
            else
            {
                return null;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetEvent(string eventPath, string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/{eventPath}?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetEventManifest(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/RewardTracks/Manifest/eventmanifest.json?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetGraphicsSpecControlOverrides()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Specs/file/graphics/GraphicsSpecControlOverrides.json",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetGraphicSpecs()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Specs/file/graphics/overrides.json",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets an image for an associated game CMS asset. Example path is "progression/inventory/armor/gloves/003-001-olympus-8e7c9dff-sm.png".
        /// </summary>
        /// <param name="filePath">Path to the CMS image.</param>
        /// <returns>If successful, returns the byte array for the requested image. Otherwise, returns null.</returns>
        public async Task<byte[]> GameCmsGetImage(string filePath)
        {
            var response = await ExecuteAPIRequest<byte[]>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/images/file/{filePath}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a specific item from the Game CMS, such as armor emplems, weapon cores, vehicle cores, and others.
        /// </summary>
        /// <remarks>
        /// For example, you may find that you can get the data about an armor emblem with the path "/inventory/armor/emblems/013-001-363f4a25.json".
        /// </remarks>
        /// <param name="itemPath">Path to the item to be obtained. Example is "/inventory/armor/emblems/013-001-363f4a25.json".</param>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, an instance of InGameItem. Otherwise, null.</returns>
        public async Task<InGameItem> GameCmsGetItem(string itemPath, string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/{itemPath}?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<InGameItem>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the list of possible error messages that a player can get when attempting to join multiplayer games.
        /// </summary>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, returns an instance of LobbyHopperErrorMessageList that contains possible errors. Otherwise, returns null.</returns>
        public async Task<LobbyHopperErrorMessageList> GameCmsGetLobbyErrorMessages(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Multiplayer/file/gameStartErrorMessages/LobbyHoppperErrorMessageList.json?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<LobbyHopperErrorMessageList>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns metadata on currently available in-game manufacturers and currencies.
        /// </summary>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, an instance of Metadata containing the information about in-game manufacturers and currencies. Otherwise, null.</returns>
        public async Task<Metadata> GameCmsGetMetadata(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/metadata/metadata.json?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<Metadata>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the network configuration for the current flight.
        /// </summary>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, returns an instance of NetworkConfiguration. Otherwise, returns null.</returns>
        public async Task<NetworkConfiguration> GameCmsGetNetworkConfiguration(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Multiplayer/file/network/config.json?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<NetworkConfiguration>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the currently relevant news.
        /// </summary>
        /// <param name="filePath">Path to the news collection. Example is "/articles/articles.json".</param>
        /// <returns>If successful, returns a News instance containing the currently active news. Otherwise, returns null.</returns>
        public async Task<News> GameCmsGetNews(string filePath)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/news/file/{filePath}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<News>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns information about a message that is displayed when, I assume, authentication fails.
        /// </summary>
        /// <remarks>It's unclear where this is actually used because the sample response is a test one, without any relevant context.</remarks>
        /// <returns>If successful, an instance of OEConfiguration containing the message. Otherwise, null.</returns>
        public async Task<OEConfiguration> GameCmsGetNotAllowedInTitleMessage()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/branches/hi/OEConfiguration/data/authfail/Default.json",
                                   HttpMethod.Get,
                                   false,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<OEConfiguration>(response);
            }
            else
            {
                return null;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetProgressionFile(string filePath)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/{filePath}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get recommended drivers for the current version of Halo Infinite.
        /// </summary>
        /// <returns>If successful, returns an instance of DriverManifest that contains details on supported drivers. Otherwise, returns null.</returns>
        public async Task<DriverManifest> GameCmsGetRecommendedDrivers()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Specs/file/graphics/RecommendedDrivers.json",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<DriverManifest>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns information about a given Halo Infinite season.
        /// </summary>
        /// <remarks>
        /// Keep in mind that the season numbers do not align cleanly with the public season numbers. For example, public Season 2 is Season 7 in this API. That is caused by a number of test season that 343 added to the product ahead of release.
        /// </remarks>
        /// <param name="seasonPath">The path to the season. Typical example is "Seasons/Season7.json" for the Lone Wolves season.</param>
        /// <param name="flightId"></param>
        /// <returns></returns>
        public async Task<SeasonRewardTrack> GameCmsGetSeasonRewardTrack(string seasonPath, string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/{seasonPath}?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<SeasonRewardTrack>(response);
            }
            else
            {
                return null;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetSeasonRewardTrackManifest(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/RewardTracks/Manifest/seasonmanifest.json?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetStorefronts(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/Store/storefronts.json?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetUiConfigurationJson()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/branches/oly/UI-Settings/data/Settings.json",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsOrigin(string path)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443://{path}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //================================================
        // GameCmsGetGuide
        //================================================
        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetGuideImages(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/images/guide/xo?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetGuideMultiplayer(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Multiplayer/guide/xo?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetGuideNews(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/News/guide/xo?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetGuideProgression(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/guide/xo?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetGuideSpecs(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Specs/guide/xo?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> GameCmsGetGuideTitleAuthorization(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/TitleAuthorization/guide/xo?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //================================================
        // HIUGC
        //================================================
        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCCheckAssetPlayerBookmark(string title, string player, string assetType, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/players/{player}/favorites/{assetType}/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCCreateAssetVersionAgnostic(string title, string assetType, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}/versions",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCDeleteAllVersions(string title, string assetType, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}/versions",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCDeleteAsset(string title, string assetType, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCDeleteVersion(string title, string assetType, string assetId, string versionId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}/versions/{versionId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCEndSession(string title, string assetType, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}/sessions/active",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCFavoriteAnAsset(string player, string assetType, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/hi/players/{player}/favorites/{assetType}/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCGetAsset(string title, string assetType, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCGetBlob()
        {
            var response = await ExecuteAPIRequest<string>($"https://blobs-infiniteugc.svc.halowaypoint.com:443",
                                   HttpMethod.Get,
                                   false,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCGetLatestAssetVersion(string title, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/films/{assetId}/versions/latest",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCGetLatestAssetVersionAgnostic(string title, string assetType, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}/versions/latest",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCGetPublishedVersion(string title, string assetType, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}/versions/published",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCGetSessionBlob()
        {
            var response = await ExecuteAPIRequest<string>($"https://s3infiniteugcsessions.blob.core.windows.net:443",
                                   HttpMethod.Get,
                                   false,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }


        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCGetSpecificAssetVersion(string title, string assetType, string assetId, string versionId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}/versions/{versionId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCListAllVersions(string title, string assetType, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}/versions",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCListPlayerAssets(string title, string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/players/{player}/assets",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCListPlayerFavorites(string player, string assetType)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/hi/players/{player}/favorites/{assetType}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCListPlayerFavoritesAgnostic(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/hi/players/{player}/favorites",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCPatchAssetVersion(string title, string assetType, string assetId, string versionId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}/versions/{versionId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCPublishAssetVersion(string assetType, string assetId, string versionId, string clearanceId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/hi/{assetType}/{assetId}/publish/{versionId}?clearanceId={clearanceId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCRateAnAsset(string player, string assetType, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/hi/players/{player}/ratings/{assetType}/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCReportAnAsset(string player, string assetType, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/hi/players/{player}/reports/{assetType}/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCSpawnAsset(string title, string assetType)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCSpectateFilm(string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/hi/films/{assetId}/spectate",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCStartSessionAgnostic(string title, string assetType, string assetId, string includeContainerSas)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}/sessions?include-container-sas={includeContainerSas}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCStringValidation(string title)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/validation/strings",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCUndeleteAsset(string title, string assetType, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCUndeleteVersion(string title, string assetType, string assetId, string versionId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}/versions/{versionId}/recover",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCUnpublishAsset(string assetType, string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/hi/{assetType}/{assetId}/unpublish",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCUploadImage(string title, string assetType, string assetId, string sessionId, string filePath, string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://authoring-infiniteugc.svc.halowaypoint.com:443/{title}/{assetType}/{assetId}/sessions/{sessionId}/Image/{filePath}?player={player}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //================================================
        // HIUGCDiscovery
        //================================================

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCDiscoveryGetEngineGameVariant(string assetId, string versionId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/engineGameVariants/{assetId}/versions/{versionId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCDiscoveryGetEngineGameVariantWithoutVersion(string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/engineGameVariants/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCDiscoveryGetManifest(string assetId, string versionId, string clearanceId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/manifests/{assetId}/versions/{versionId}?clearanceId={clearanceId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        // Example branch is HIREL according to HIUGCDiscoveryGetManifestByBuild, but that needs to be validated.
        public async Task<string> HIUGCDiscoveryGetManifestByBranch(string branchName)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/manifests/branches/{branchName}/game",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the current game manifest.
        /// </summary>
        /// <param name="buildNumber">Build for which the manifest needs to be obtained. Maps to official Halo builds, such as 6.10022.10499.</param>
        /// <returns>An instance of Manifest containing game manifest information if request is successful. Otherwise, returns null.</returns>
        public async Task<Manifest> HIUGCDiscoveryGetManifestByBuild(string buildNumber)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/manifests/builds/{buildNumber}/game",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<Manifest>(response);
            }
            else
            {
                return null;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCDiscoveryGetManifestWithoutVersion(string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/manifests/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Returns information about a given map at a specific release version.
        /// </summary>
        /// <param name="assetId">Unique map ID. For example, the ID for the Recharge map is "8420410b-044d-44d7-80b6-98a766c8c39f".</param>
        /// <param name="versionId">Unique version ID for a map. For example, for the Recharge map a version is "068c0974-f748-41ba-b457-b8fed603576e".</param>
        /// <returns>An instance of Map containing map metadata if request is successful. Otherwise, returns null.</returns>
        public async Task<Map> HIUGCDiscoveryGetMap(string assetId, string versionId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/maps/{assetId}/versions/{versionId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<Map>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns information about a given map and mode combination. For example, the Breaker map can be used in Big Team Battle (BTB).
        /// </summary>
        /// <remarks>
        /// An example fully constructed HTTP request to the API is: https://discovery-infiniteugc.svc.halowaypoint.com/hi/mapModePairs/9e056bcc-b9bc-4845-9fe3-6d667f018463/versions/37b8cd75-d1ce-4abf-9349-a76673503410.
        /// This request represents the BTB game mode on the Breaker map.
        /// </remarks>
        /// <param name="assetId">Unique ID for the map and mode combination.</param>
        /// <param name="versionId">Unique version ID for the map and mode combination.</param>
        /// <param name="clearanceId">ID of the currently active flight.</param>
        /// <returns>An instance of Map containing map metadata if request is successful. Otherwise, returns null.</returns>
        public async Task<MapModePair> HIUGCDiscoveryGetMapModePair(string assetId, string versionId, string clearanceId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/mapModePairs/{assetId}/versions/{versionId}?clearanceId={clearanceId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<MapModePair>(response);
            }
            else
            {
                return null;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCDiscoveryGetMapModePairWithoutVersion(string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/mapModePairs/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Returns information about a given map.
        /// </summary>
        /// <param name="assetId">Unique map ID. For example, the ID for the Recharge map is "8420410b-044d-44d7-80b6-98a766c8c39f".</param>
        /// <returns>An instance of Map containing map metadata if request is successful. Otherwise, returns null.</returns>
        public async Task<Map> HIUGCDiscoveryGetMapWithoutVersion(string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/maps/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<Map>(response);
            }
            else
            {
                return null;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCDiscoveryGetPlaylist(string assetId, string versionId, string clearanceId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/playlists/{assetId}/versions/{versionId}?clearanceId={clearanceId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCDiscoveryGetPlaylistWithoutVersion(string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/playlists/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCDiscoveryGetPrefab(string assetId, string versionId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/prefabs/{assetId}/versions/{versionId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCDiscoveryGetPrefabWithoutVersion(string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/prefabs/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Returns the project details that are associated with a given version of a manifest. This manifest contains all the maps and modes to show in the custom game menus.
        /// </summary>
        /// <param name="assetId">Unique asset ID representing the project. Example asset ID currently active is the custom game manifest ID: "a9dc0785-2a99-4fec-ba6e-0216feaaf041".</param>
        /// <param name="versionId">Version ID for the project. As an example, a version of a production manifest is "a4e68648-f994-44bb-853e-d09ee224d799".</param>
        /// <returns>An instance of Project containing current game project information if request is successful. Otherwise, returns null.</returns>
        public async Task<Project> HIUGCDiscoveryGetProject(string assetId, string versionId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/projects/{assetId}/versions/{versionId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<Project>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns information on a project (collection of game modes and maps). This manifest contains all the maps and modes to show in the custom game menus.
        /// </summary>
        /// <param name="assetId">Unique asset ID representing the project. Example asset ID currently active is the custom game manifest ID: "a9dc0785-2a99-4fec-ba6e-0216feaaf041".</param>
        /// <returns>An instance of Project containing current game project information if request is successful. Otherwise, returns null.</returns>
        public async Task<Project> HIUGCDiscoveryGetProjectWithoutVersion(string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/projects/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<Project>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns information about available tags that can be associated with game assets.
        /// </summary>
        /// <returns>An instance of TagInfo containing a list of tags if the request is successful. Otherwise, returns null.</returns>
        public async Task<TagInfo> HIUGCDiscoveryGetTagsInfo()
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/info/tags",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<TagInfo>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns information about a game asset version. This information is specific only to the version specified and does not contain general asset metadata. To get general asset metadata, use HIUGCDiscoveryGetUgcGameVariantWithoutVersion.
        /// </summary>
        /// <param name="assetId">Unique ID for the game asset. For example, for "Arena:Attrition" game mode, the asset ID is "cefd4723-7bf2-4784-91bb-7c7c3dc9e324".</param>
        /// <param name="versionId">Version for the asset to obtain. Example value is "latest".</param>
        /// <returns>An instance of UGCGameVariant containing game variant metadata if the request is successful. Otherwise, returns null.</returns>
        public async Task<UGCGameVariant> HIUGCDiscoveryGetUgcGameVariant(string assetId, string versionId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/ugcGameVariants/{assetId}/versions/{versionId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<UGCGameVariant>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns general asset metadata related to a game asset.
        /// </summary>
        /// <param name="assetId">Unique ID for the game asset. For example, for "LandGrab-DefaultFiesta" game mode, the asset ID is "6d10405f-6d8d-406d-af8a-56c0d6caa73d".</param>
        /// <returns>An instance of GameAssetVariant containing asset metadata if the request is successful. Otherwise, returns null.</returns>
        public async Task<UGCGameVariant> HIUGCDiscoveryGetUgcGameVariantWithoutVersion(string assetId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/ugcGameVariants/{assetId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<UGCGameVariant>(response);
            }
            else
            {
                return null;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> HIUGCDiscoverySearch()
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/search",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Returns information about available film chunks that are used to reconstruct the entire match.
        /// </summary>
        /// <param name="matchId">Unique ID for the match.</param>
        /// <returns>An instance of Film containing film metadata if the request is successful. Otherwise, returns null.</returns>
        /// <remarks>Despite the name of this request, the data captured here is not actually a movie but rather a full re-creation of the match, using in-game assets and player positions.</remarks>
        public async Task<Film> HIUGCDiscoverySpectateByMatchId(string matchId)
        {
            var response = await ExecuteAPIRequest<string>($"https://discovery-infiniteugc.svc.halowaypoint.com:443/hi/films/matches/{matchId}/spectate",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<Film>(response);
            }
            else
            {
                return null;
            }
        }

        //================================================
        // Lobby
        //================================================
        //TODO: This function requires manual intervention/checks.
        public async Task<string> LobbyGameConnection()
        {
            var response = await ExecuteAPIRequest<string>($"https://lobby-hi.svc.halowaypoint.com:443/",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets a list of available lobby servers.
        /// </summary>
        /// <returns>A list of Server instances if the request is successful. Otherwise, returns null.</returns>
        public async Task<List<Server>> LobbyGetQosServers()
        {
            var response = await ExecuteAPIRequest<string>($"https://lobby-hi.svc.halowaypoint.com:443/titles/hi/qosservers",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<List<Server>>(response);
            }
            else
            {
                return null;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> JoinLobby(string lobbyId, string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://lobby-hi.svc.halowaypoint.com:443/hi/lobbies/{lobbyId}/players/{player}?auth=st",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> LobbyConnection()
        {
            var response = await ExecuteAPIRequest<string>($"https://lobby-hi.svc.halowaypoint.com:443/",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> LobbyConnectionPublish()
        {
            var response = await ExecuteAPIRequest<string>($"https://lobby-hi.svc.halowaypoint.com:443/",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> LobbyConnectionSubscribe()
        {
            var response = await ExecuteAPIRequest<string>($"https://lobby-hi.svc.halowaypoint.com:443/",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> LobbyPresence()
        {
            var response = await ExecuteAPIRequest<string>($"https://lobby-hi.svc.halowaypoint.com:443/hi/presence",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> LobbyRegisterJoinLobbyHandle(string handleId, string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://lobby-hi.svc.halowaypoint.com:443/hi/handles/{handleId}/players/{player}?auth=st",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets a third-party join handle for a lobby.
        /// </summary>
        /// <param name="lobbyId">Unique lobby ID.</param>
        /// <param name="player">Player ID in the format of "xuid(XUID_VALUE)".</param>
        /// <param name="handleAudience">Audience for the join handle. Example value is "Friends".</param>
        /// <param name="handlePlatform">Platform for the join handle. Example value is "Discord".</param>
        /// <returns>An instance of LobbyJoinHandle if the request is successful. Otherwise, returns null.</returns>
        /// <remarks>It seems that this request requires a more "broad access" Spartan token that is generated by the game, and is not open to third-party apps. Additional investigation is required.</remarks>
        public async Task<LobbyJoinHandle> LobbyThirdPartyJoinHandle(string lobbyId, string player, string handleAudience, string handlePlatform)
        {
            var response = await ExecuteAPIRequest<string>($"https://lobby-hi.svc.halowaypoint.com:443/hi/lobbies/{lobbyId}/players/{player}/thirdPartyJoinHandle?audience={handleAudience}&platform={handlePlatform}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<LobbyJoinHandle>(response);
            }
            else
            {
                return null;
            }
        }

        //================================================
        // Setting
        //================================================
        //TODO: This function requires manual intervention/checks.
        public async Task<string> SettingGetFeatureFlags(string platform, string version)
        {
            var response = await ExecuteAPIRequest<string>($"https://settings.svc.halowaypoint.com:443/featureflags/{platform}/{version}",
                                   HttpMethod.Get,
                                   false,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Get a list of features enables for a given flight.
        /// </summary>
        /// <param name="flightId">Clearance ID/flight that is being used.</param>
        /// <returns>An instance of FlightedFeatureFlags containing a list of enabled and disabled features if the request is successful. Otherwise, returns null.</returns>
        public async Task<FlightedFeatureFlags> SettingGetFlightedFeatureFlags(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://settings.svc.halowaypoint.com:443/featureflags/hi?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<FlightedFeatureFlags>(response);
            }
            else
            {
                return null;
            }
        }

        //================================================
        // Settings
        //================================================

        /// <summary>
        /// Gets the currently assigned clearance/flight ID.
        /// </summary>
        /// <param name="audience">Audience that the request is targeting. Standard value is RETAIL.</param>
        /// <param name="sandbox">Identifier associated with the sandbox. Typical value is UNUSED.</param>
        /// <param name="buildNumber">Number of the game build the data is requested for. Example value is 211755.22.01.23.0549-0.</param>
        /// <returns>An instance of PlayerClearance if the request is successful. Otherwise, returns null.</returns>
        public async Task<PlayerClearance> SettingsGetClearance(string audience, string sandbox, string buildNumber)
        {
            var response = await ExecuteAPIRequest<string>($"https://settings.svc.halowaypoint.com:443/oban/flight-configurations/titles/hi/audiences/{audience}/active?sandbox={sandbox}&build={buildNumber}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<PlayerClearance>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the the player clearance/flight ID.
        /// </summary>
        /// <param name="audience">Audience that the request is targeting. Standard value is RETAIL.</param>
        /// <param name="player">The player identifier in the format "xuid(000000)".</param>
        /// <param name="sandbox">Identifier associated with the sandbox. Typical value is UNUSED.</param>
        /// <param name="buildNumber">Number of the game build the data is requested for. Example value is 211755.22.01.23.0549-0.</param>
        /// <returns>An instance of PlayerClearance if the request is successful. Otherwise, returns null.</returns>
        public async Task<PlayerClearance> SettingsGetPlayerClearance(string audience, string player, string sandbox, string buildNumber)
        {
            var response = await ExecuteAPIRequest<string>($"https://settings.svc.halowaypoint.com:443/oban/flight-configurations/titles/hi/audiences/{audience}/players/{player}/active?sandbox={sandbox}&build={buildNumber}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<PlayerClearance>(response);
            }
            else
            {
                return null;
            }
        }

        //================================================
        // Skill
        //================================================

        /// <summary>
        /// Returns individual player stats for a given match.
        /// </summary>
        /// <param name="matchId">The unique match ID.</param>
        /// <param name="playerIds">Array of player IDs. Each ID string should be in the format of "xuid(XUID_VALUE)."</param>
        /// <returns></returns>
        public async Task<PlayerSkillResultValue> SkillGetMatchPlayerResult(string matchId, List<string> playerIds)
        {
            var formattedPlayerList = string.Join(",", playerIds);
            var response = await ExecuteAPIRequest<string>($"https://skill.svc.halowaypoint.com:443/hi/matches/{matchId}/skill?players={formattedPlayerList}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<PlayerSkillResultValue>(response);
            }
            else
            {
                return null;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> SkillGetPlaylistCsr(string playlistId)
        {
            var response = await ExecuteAPIRequest<string>($"https://skill.svc.halowaypoint.com:443/hi/playlist/{playlistId}/csrs",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //================================================
        // Stats
        //================================================
        /// <summary>
        /// Gets the summary information for applicable bans to players and devices.
        /// </summary>
        /// <param name="targetlist">A list of targets that need to be checked. Authenticated devices can be included as "Authenticated(Device)". Individual players can be specified as "xuid(XUID_VALUE)".</param>
        /// <returns>An instance of BanSummary containing applicable ban information if request was successful. Return value is null otherwise.</returns>
        /// <remarks>In some quick tests, it seems that including Authenticated(Device) in the request results in 401 Unauthorized if called outside the game. Additional work might be required to understand how to validate the device.</remarks>
        public async Task<BanSummary> StatsBanSummary(List<string> targetlist)
        {
            var formattedTargetList = string.Join(",", targetlist);
            var response = await ExecuteAPIRequest<string>($"https://banprocessor.svc.halowaypoint.com:443/hi/bansummary?auth=st&targets={formattedTargetList}",
                                   HttpMethod.Get,
                                   false,
                                   false,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<BanSummary>(response); ;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets challenge decks that are available for a player.
        /// </summary>
        /// <param name="player">The player identifier in the format "xuid(000000)"</param>
        /// <returns>An instance of PlayerDecks containing deck information if request was successful. Return value is null otherwise.</returns>
        public async Task<PlayerDecks> StatsGetChallengeDecks(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://halostats.svc.halowaypoint.com:443/hi/players/{player}/decks",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<PlayerDecks>(response); ;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the summary on number of played matches.
        /// </summary>
        /// <param name="player">The player identifier in the format "xuid(000000)"</param>
        /// <returns>An instance of PlayerMatchCount containing match counts if request was successful. Return value is null otherwise.</returns>
        public async Task<PlayerMatchCount> StatsGetMatchCount(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://halostats.svc.halowaypoint.com:443/hi/players/{player}/matches/count",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<PlayerMatchCount>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets match history for a player.
        /// </summary>
        /// <param name="player">The player identifier in the format "xuid(000000)"</param>
        /// <returns>An instance of MatchContainer containing match metadata if request was successful. Return value is null otherwise.</returns>
        public async Task<MatchContainer> StatsGetMatchHistory(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://halostats.svc.halowaypoint.com:443/hi/players/{player}/matches",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<MatchContainer>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets stats for a specific match.
        /// </summary>
        /// <param name="matchId">Match ID in GUID format.</param>
        /// <returns>An instance of MatchStats containing match metadata if request was successful. Return value is null otherwise.</returns>
        public async Task<MatchStats> StatsGetMatchStats(string matchId)
        {
            var response = await ExecuteAPIRequest<string>($"https://halostats.svc.halowaypoint.com:443/hi/matches/{matchId}/stats",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<MatchStats>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get challenge progression associated with a given match. 
        /// </summary>
        /// <param name="player">The player identifier in the format "xuid(000000)"</param>
        /// <param name="matchId">Match ID in GUID format.</param>
        /// <returns>An instance of MatchProgression containing match challenge progression metadata if request was successful. Return value is null otherwise.</returns>
        public async Task<MatchProgression> StatsGetPlayerMatchProgression(string player, string matchId)
        {
            var response = await ExecuteAPIRequest<string>($"https://halostats.svc.halowaypoint.com:443/hi/players/{player}/matches/{matchId}/progression",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<MatchProgression>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets match privacy settings for a given player.
        /// </summary>
        /// <param name="player">The player identifier in the format "xuid(000000)"</param>
        /// <returns>An instance of MatchesPrivacy containing match privacy metadata if request was successful. Return value is null otherwise.</returns>
        public async Task<MatchesPrivacy> StatsMatchPrivacy(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://halostats.svc.halowaypoint.com:443/hi/players/{player}/matches-privacy",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<MatchesPrivacy>(response);
            }
            else
            {
                return null;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> StatsProcessPlayerChallengeAction(string player, string deckId, string challengeId)
        {
            var response = await ExecuteAPIRequest<string>($"https://halostats.svc.halowaypoint.com:443/hi/players/{player}/decks/{deckId}/challenges/{challengeId}",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> StatsPutCampaignProgress(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://halostats.svc.halowaypoint.com:443/hi/players/{player}/campaign/progress",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> StatsPutPlayerPresenceInMatch(string player, string matchId)
        {
            var response = await ExecuteAPIRequest<string>($"https://halostats.svc.halowaypoint.com:443/hi/players/{player}/matches/{matchId}/present-in-match",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //================================================
        // Telemetry
        //================================================
        /// <summary>
        /// Likely deals with in-game telemetry. Early investigations point to WebSockets communication, so additional work is required for full context.
        /// </summary>
        /// <returns>Unknown</returns>
        private async Task<string> TelemetryHighPriority()
        {
            var response = await ExecuteAPIRequest<string>($"https://telemetry-clients.svc.halowaypoint.com:443/",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Likely deals with in-game telemetry. Early investigations point to WebSockets communication, so additional work is required for full context.
        /// </summary>
        /// <returns>Unknown</returns>
        private async Task<string> TelemetryLowPriority()
        {
            var response = await ExecuteAPIRequest<string>($"https://telemetry-clients.svc.halowaypoint.com:443/",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //================================================
        // TextModeration
        //================================================
        /// <summary>
        /// Gets a specific moderation proof signing key.
        /// </summary>
        /// <param name="keyId">Key ID. Full list can be obtained by a call to TextModerationGetSigningKeys.</param>
        /// <returns>An instance of Key containing a single signing key data if request was successful. Return value is null otherwise.</returns>
        public async Task<Key> TextModerationGetSigningKey(string keyId)
        {
            var response = await ExecuteAPIRequest<string>($"https://text.svc.halowaypoint.com:443/hi/moderation-proof-keys/{keyId}",
                                   HttpMethod.Get,
                                   false,
                                   false,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<Key>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a list of available moderation proof signing keys.
        /// </summary>
        /// <returns>An instance of ModerationProofKeys containing signing key data if request was successful. Return value is null otherwise.</returns>
        public async Task<ModerationProofKeys> TextModerationGetSigningKeys()
        {
            var response = await ExecuteAPIRequest<string>($"https://text.svc.halowaypoint.com:443/hi/moderation-proof-keys",
                                   HttpMethod.Get,
                                   false,
                                   false,
                                   GlobalConstants.HALO_PC_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<ModerationProofKeys>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Likely posts text for moderation. Have not yet seen this live in the game, and have no information on how it works at this time.
        /// </summary>
        /// <param name="player">Player ID likely in "xuid(XUID_VALUE)" format.</param>
        /// <returns>Unknown</returns>
        private async Task<string> TextModerationPostInappropriateMessageReport(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://text.svc.halowaypoint.com:443/hi/players/{player}/text-message-reports",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Likely posts text for moderation. Have not yet seen this live in the game, and have no information on how it works at this time.
        /// </summary>
        /// <param name="player">Player ID likely in "xuid(XUID_VALUE)" format.</param>
        /// <returns>Unknown</returns>
        private async Task<string> TextModerationPostTextForModeration(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://text.svc.halowaypoint.com:443/hi/players/{player}/text-messages",
                                   HttpMethod.Get,
                                   true,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //================================================
        // Xbl
        //================================================
        //TODO: This function requires manual intervention/checks.
        public async Task<string> XblGetProfileSettingsForSpeechAccessibility()
        {
            var response = await ExecuteAPIRequest<string>($"https://profile.xboxlive.com:443/users/me/profile/settings?settings=SpeechAccessibility",
                                   HttpMethod.Get,
                                   false,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //================================================
        // XboxLive
        //================================================
        //TODO: This function requires manual intervention/checks.
        public async Task<string> XboxLiveTitleManagedStorage(string xuid, string scid)
        {
            var response = await ExecuteAPIRequest<string>($"https://titlestorage.xboxlive.com:443/trustedplatform/users/xuid({xuid})/scids/{scid}/data/thunderhead_campaign_saves",
                                   HttpMethod.Get,
                                   false,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //TODO: This function requires manual intervention/checks.
        public async Task<string> XboxLiveTitleManagedStorageFile(string xuid, string scid, string filename, string type)
        {
            var response = await ExecuteAPIRequest<string>($"https://titlestorage.xboxlive.com:443/trustedplatform/users/xuid({xuid})/scids/{scid}/data/thunderhead_campaign_saves/{filename},{type}",
                                   HttpMethod.Get,
                                   false,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        //================================================
        // Xboxlive
        //================================================
        //TODO: This function requires manual intervention/checks.
        public async Task<string> XboxliveQoSEndpoints()
        {
            var response = await ExecuteAPIRequest<string>($"https://gameserverds.xboxlive.com:443/xplatqosservers",
                                   HttpMethod.Get,
                                   false,
                                   false,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Executes an API request in a standard way against a given API endpoint. This is a helper method that's put
        /// in place to simplify how the API calls are made because most requests against the Halo Infinite API are
        /// pretty repetitive.
        /// </summary>
        /// <param name="endpoint">The API endpoint to which the request is sent.</param>
        /// <param name="method">HTTP method to be used for the request.</param>
        /// <param name="useSpartanToken">Determines whether a Spartan token needs to be applied to teh request.</param>
        /// <param name="useClearance">Determines whether a clearance/flight ID needs to be applied to the request.</param>
        /// <param name="userAgent">User agent to be used for the request.</param>
        /// <param name="content">If the request contains data to be sent to the Halo Waypoint service, include it here. Expected format is JSON.</param>
        /// <returns>Response string in case of a successful request. Null if request failed.</returns>
        private async Task<T> ExecuteAPIRequest<T>(string endpoint, HttpMethod method, bool useSpartanToken, bool useClearance, string userAgent, string content = "")
        {
            var client = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli
            });

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(endpoint),
                Method = method
            };

            if (!string.IsNullOrEmpty(content))
            {
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }

            if (useSpartanToken)
            {
                request.Headers.Add("x-343-authorization-spartan", this._spartanToken);
            }

            if (useClearance)
            {
                request.Headers.Add("343-clearance", this._clearanceToken);
            }
            
            request.Headers.Add("User-Agent", userAgent);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                if (typeof(T) == typeof(string))
                {
                    return (T)Convert.ChangeType(response.Content.ReadAsStringAsync().Result, typeof(T));
                }
                else if (typeof(T) == typeof(byte[]))
                {
                    using (MemoryStream dataStream = new MemoryStream())
                    {
                        response.Content.ReadAsStreamAsync().Result.CopyTo(dataStream);
                        return (T)Convert.ChangeType(dataStream.ToArray(), typeof(T));
                    }
                }
                else
                {
                    throw new NotSupportedException("The specified type is not supported. You can onlty get results in string or byte array formats.");
                }
            }
            else
            {
                return default;
            }
        }
    }
}
