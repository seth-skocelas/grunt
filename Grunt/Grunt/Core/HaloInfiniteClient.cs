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

        public HaloInfiniteClient(string spartanToken, string xuid, string clearanceToken = "")
        {
            this._spartanToken = spartanToken;
            this._xuid = xuid;
            this._clearanceToken = clearanceToken;
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
        /// <remarks>INACTIVE API</remarks>
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
        /// <include file='../APIDocsExamples/Economy_AiCoreCustomization.xml' path='//example'/>
        /// <param name="player">The player identifier in the format "xuid(XUID_VALUE)".</param>
        /// <param name="coreId">Unique AI Core ID. Example ID is "304-100-ai-core-debb20e3".</param>
        /// <returns>An instance of Core containing AI core customization metadata if request was successful. Return value is null otherwise.</returns>
        public async Task<Models.HaloInfinite.AiCore> EconomyAiCoreCustomization(string player, string coreId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/ais/{coreId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<Models.HaloInfinite.AiCore>(response);
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
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
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

        /// <summary>
        /// Gets information about a specific armor core a player owns.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_ArmorCoreCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="coreId">The unique identifier for an armor core. An example value is "017-001-eag-c13d0b38".</param>
        /// <returns>If successful, returns an instance of ArmorCore containing customization information. Otherwise, returns null.</returns>
        public async Task<ArmorCore> EconomyArmorCoreCustomization(string player, string coreId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/armors/{coreId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<ArmorCore>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about all armor cores a player owns.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_ArmorCoresCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of ArmorCoreCollection that contains the list of armor cores. Otherwise, returns null.</returns>
        public async Task<ArmorCoreCollection> EconomyArmorCoresCustomization(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/armors",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<ArmorCoreCollection>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about currently active boosts for the player.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetActiveBoosts.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of ActiveBoostsContainer that contains the list of active boosts. Otherwise, returns null.</returns>
        public async Task<ActiveBoostsContainer> EconomyGetActiveBoosts(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/boosts",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<ActiveBoostsContainer>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about a reward given to a player.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetAwardedRewards.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="rewardId">The unique ID for the reward given to a player. Example value is "Challenges-35a86ae3-017c-4b5a-b633-b2802a770e0a".</param>
        /// <returns></returns>
        public async Task<RewardSnapshot> EconomyGetAwardedRewards(string player, string rewardId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/rewards/{rewardId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<RewardSnapshot>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about boosts offering in the store for a given player.
        /// </summary>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of StoreItem containing boost information. Otherwise, returns null.</returns>
        public async Task<StoreItem> EconomyGetBoostsStore(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/boosts",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<StoreItem>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns information about store events. The endpoint currently returns a 404, which is either transient (no events) or no longer relevant. Additional investigation is necessary.
        /// </summary>
        /// <remarks>INACTIVE API</remarks>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>Unknown</returns>
        private async Task<string> EconomyGetEventsStore(string player)
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

        /// <summary>
        /// Gets the information about giveaways available for a given player.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetGiveawayRewards.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of PlayerGiveaways containing available giveaways. Otherwise, returns null.</returns>
        public async Task<PlayerGiveaways> EconomyGetGiveawayRewards(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/giveaways",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<PlayerGiveaways>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about items available for sale in the Halo Championship Series (HCS) store.
        /// </summary>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, an instance of StoreItem containing store offerings. Otherwise, returns null.</returns>
        public async Task<StoreItem> EconomyGetHCSStore(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/hcs",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<StoreItem>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about items available in the current player's inventory.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetInventoryItems.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of PlayerInventory that contains a list of items in the player's inventory. Otherwise, returns null.</returns>
        public async Task<PlayerInventory> EconomyGetInventoryItems(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/inventory",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<PlayerInventory>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the information about all available items in the main store.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetMainStore.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of StoreItem that contains information about items available in the main store. Otherwise, returns null.</returns>
        public async Task<StoreItem> EconomyGetMainStore(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/main",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<StoreItem>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about customizations for multiple players.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetMultiplePlayersCustomization.xml' path='//example'/>
        /// <param name="playerIds">Array of player IDs. Each ID string should be in the format of "xuid(XUID_VALUE)."</param>
        /// <returns>If successful, returns an instance of PlayerCustomizationCollection that contains player customizations. Otherwise, returns null.</returns>
        public async Task<PlayerCustomizationCollection> EconomyGetMultiplePlayersCustomization(List<string> playerIds)
        {
            var formattedPlayerList = string.Join(",", playerIds);
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/customization?players={formattedPlayerList}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<PlayerCustomizationCollection>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about the operations reward levels store.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetOperationRewardLevelsStore.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of StoreItem that contains information about items available in the operations reward levels store. Otherwise, returns null.</returns>
        public async Task<StoreItem> EconomyGetOperationRewardLevelsStore(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/operationrewardlevels",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<StoreItem>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about the operations store.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetOperationsStore.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of StoreItem that contains information about items available in the operations store. Otherwise, returns null.</returns>
        public async Task<StoreItem> EconomyGetOperationsStore(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/operations",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<StoreItem>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about rewards associated with a given reward track, such as a season or special event.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetRewardTrack.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="rewardTrackType">Type of reward track. For seasons, this is usually "operation". This parameter is a singular noun, and is pluralized automatically in the function (the "s" character is appended).</param>
        /// <param name="trackId">Unique identifier for the reward track. An example value is "battlepass-noblesacrifice.json".</param>
        /// <returns>If successful, returns an instance of RewardTrack containing information for reward track tiers. Otherwise, returns null.</returns>
        public async Task<RewardTrackMetadata> EconomyGetRewardTrack(string player, string rewardTrackType, string trackId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/rewardtracks/{rewardTrackType}s/{trackId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<RewardTrackMetadata>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the amount of currencies that the player has in their account.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetVirtualCurrencyBalances.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of CurrencySnapshot that contains the balances. Otherwise, returns null.</returns>
        public async Task<CurrencySnapshot> EconomyGetVirtualCurrencyBalances(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/currencies",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<CurrencySnapshot>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about items on sale in the XP grants store.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetXpGrantsStore.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of StoreItem that contains information about items in the store. Otherwise, returns null.</returns>
        public async Task<StoreItem> EconomyGetXpGrantsStore(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/xpgrants",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<StoreItem>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about a specific owned core.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_OwnedCoreDetails.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="coreId">The unque core ID. An example is "017-001-eag-c13d0b38".</param>
        /// <returns>If successful, returns an instance of Core containing core information. Otherwise, returns null.</returns>
        public async Task<Models.HaloInfinite.Foundation.Core> EconomyOwnedCoreDetails(string player, string coreId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/cores/{coreId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<Models.HaloInfinite.Foundation.Core>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the current player appearance customization state.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_PlayerAppearanceCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of AppearanceCustomization containing customization information. Otherwise, returns null.</returns>
        public async Task<AppearanceCustomization> EconomyPlayerAppearanceCustomization(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/appearance",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<AppearanceCustomization>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about available player customizations.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_PlayerCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="viewType">Determines which view into customizations is shown. Available values are "public" and "private". The private view enables showing all available cores, while the public view only shows equipped cores.</param>
        /// <returns>If successful, returns an instance of CustomizationData containing player customizations. Otherwise, returns null.</returns>
        public async Task<CustomizationData> EconomyPlayerCustomization(string player, string viewType)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization?view={viewType}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<CustomizationData>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets available reward tracks for a player based on current and past battle passes.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_PlayerOperations.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of OperationRewardTrackSnapshot containing battle pass information. Otherwise, returns null.</returns>
        public async Task<OperationRewardTrackSnapshot> EconomyPlayerOperations(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/rewardtracks/operations",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<OperationRewardTrackSnapshot>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about transactions that the player executed.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_PostCurrencyTransaction.xml' path='//example'/>
        /// <remarks>
        /// This function is likely used as a POST as well (hence the name - right now we're only using GET). Once we discover how this API works, we can extend the functionality further.
        /// </remarks>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="currencyId">The unique identifier for the currency. Valid values include "cr", "rerollcurrency", "xpboost", and "xpgrant".</param>
        /// <returns>If successful, returns an instance of TransactionSnapshot listing all existing transactions. Otherwise, returns null.</returns>
        public async Task<TransactionSnapshot> EconomyPostCurrencyTransaction(string player, string currencyId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/currencies/{currencyId}/transactions",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<TransactionSnapshot>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// This API does not work with GET requests and is likely used to post transactions. Additional investigation is required.
        /// </summary>
        /// <remarks>INACTIVE API</remarks>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>Unknown.</returns>
        private async Task<string> EconomyPurchaseStorefrontOfferingTransaction(string player)
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

        /// <summary>
        /// Gets information about offerings for a player in a given store.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_ScheduledStorefrontOfferings.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="storeId">The unique store identifier. An example value is "hcs".</param>
        /// <returns>If successful, returns an instance of StoreItem containing offerings. Otherwise, returns null.</returns>
        public async Task<StoreItem> EconomyScheduledStorefrontOfferings(string player, string storeId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/stores/{storeId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<StoreItem>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the currently active Spartan body customization.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_SpartanBodyCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of SpartanBody containing the customization information. Otherwise, returns null.</returns>
        public async Task<SpartanBody> EconomySpartanBodyCustomization(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/spartanbody",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<SpartanBody>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about a vehicle core.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_VehicleCoreCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="coreId">Unique vehicle core ID. Example value is "409-304-olympus-e8b8a8b3".</param>
        /// <returns>If successful, returns an instance of VehicleCore. Otherwise, returns null.</returns>
        public async Task<VehicleCore> EconomyVehicleCoreCustomization(string player, string coreId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/vehicles/{coreId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<VehicleCore>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about the vehicle core customizations availale to a player.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_VehicleCoresCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of VehicleCoreCollection containing a list of available vehicle cores. Otherwise, returns null.</returns>
        public async Task<VehicleCoreCollection> EconomyVehicleCoresCustomization(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/vehicles",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<VehicleCoreCollection>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about a specific weapon core.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_WeaponCoreCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="coreId">The unique ID of the weapon core.</param>
        /// <returns>If successful, returns an instance of WeaponCore containing information about the weapon core. Otherwise, returns null.</returns>
        public async Task<WeaponCore> EconomyWeaponCoreCustomization(string player, string coreId)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/weapons/{coreId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<WeaponCore>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about weapon cores equipped on a player.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_WeaponCoresCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of WeaponCoreCollection. Otherwise, returns null.</returns>
        public async Task<WeaponCoreCollection> EconomyWeaponCoresCustomization(string player)
        {
            var response = await ExecuteAPIRequest<string>($"https://economy.svc.halowaypoint.com:443/hi/players/{player}/customization/weapons",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<WeaponCoreCollection>(response);
            }
            else
            {
                return null;
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

        /// <summary>
        /// The API doesn't seem to exist anymore.
        /// Tracked in: https://github.com/dend/grunt/issues/10
        /// </summary>
        /// <remarks>INACTIVE API</remarks>
        /// <param name="flightId">The unique ID for the currently active flight.</param>
        /// <returns>Unknown</returns>
        private async Task<string> GameCmsGetArmorCoreManifest(string flightId)
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

        /// <summary>
        /// Gets information about active async compute overrides. Unknown what the concrete purpose of this API is yet.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetAsyncComputeOverrides.xml' path='//example'/>
        /// <returns>If successful, returns an instance of AsyncComputeOverrides containing override metadata. Otherwise, returns null.</returns>
        public async Task<AsyncComputeOverrides> GameCmsGetAsyncComputeOverrides()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Specs/file/graphics/AsyncComputeOverrides.json",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<AsyncComputeOverrides>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// The API likely obtains a specific ban message, but unless someone banned can confirm what this looks like, can't tell what the data is.
        /// Tracked in: https://github.com/dend/grunt/issues/9
        /// </summary>
        /// <remarks>INACTIVE API</remarks>
        /// <param name="messageIdentity">The unique ID for the ban message.</param>
        /// <param name="flightId">The unique ID for the currently active flight.</param>
        /// <returns>Unknown.</returns>
        private async Task<string> GameCmsGetBanMessage(string messageIdentity, string flightId)
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

        /// <summary>
        /// Gets the information about a specific challenge deck.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetChallengeDeck.xml' path='//example'/>
        /// <param name="challengeDeckPath">Path to the challenge deck. An example value is "ChallengeContent/ClientChallengeDeckDefinitions/S2EntrenchedWeeklyDeck2.json".</param>
        /// <param name="flightId">Unique identifier for the currently active flight.</param>
        /// <returns>If successful, returns an instance of ChallengeDeckDefinition containing challenge deck metadata. Otherwise, returns null.</returns>
        public async Task<ChallengeDeckDefinition> GameCmsGetChallengeDeck(string challengeDeckPath, string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/{challengeDeckPath}?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<ChallengeDeckDefinition>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the information about a specific currency type.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetCurrency.xml' path='//example'/>
        /// <param name="currencyPath">Path to the currency. An example is "currency/currencies/cr.json".</param>
        /// <param name="flightId">Unique identifier for the currently active flight.</param>
        /// <returns>If successful, returns an instance of CurrencyDefinition containing information about the specified currency. Otherwise, returns null.</returns>
        public async Task<CurrencyDefinition> GameCmsGetCurrency(string currencyPath, string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/{currencyPath}?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<CurrencyDefinition>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns XUIDs with special access.
        /// </summary>
        /// <remarks>
        /// Based on the "claw" terminology, these are likely accounts with access to clawback services (for transaction refunds).
        /// At least one of the accounts returned for this API call is flagged as a member of the Xbox Scarlett team, so it's likely these are accounts that have a more direct access to Halo services.
        /// </remarks>
        /// <include file='../APIDocsExamples/GameCms_GetClawAccess.xml' path='//example'/>
        /// <param name="flightId">Unique identifier for the currently active flight.</param>
        /// <returns>If successful, returns an instance of ClawAccessSnapshot containing relevant XUID lists. Otherwise, returns null.</returns>
        public async Task<ClawAccessSnapshot> GameCmsGetClawAccess(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/TitleAuthorization/file/claw/access.json?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<ClawAccessSnapshot>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the pre-defined CPU presets for different game performance configurations.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetCPUPresets.xml' path='//example'/>
        /// <returns>If successful, returns an instance of CPUPresetSnapshot containing preset information. Otherwise, returns null.</returns>
        public async Task<CPUPresetSnapshot> GameCmsGetCpuPresets()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Specs/file/cpu/presets.json",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<CPUPresetSnapshot>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns the parameters for new custom games started in Halo Infinite.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetCustomGameDefaults.xml' path='//example'/>
        /// <returns>If successful, returns an instance of CustomGameDefinition containing game parameters. Otherwise, returns null.</returns>
        public async Task<CustomGameDefinition> GameCmsGetCustomGameDefaults()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Multiplayer/file/NonMatchmaking/customgame.json",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<CustomGameDefinition>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the full list of existing in-game items.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetCustomizationCatalog.xml' path='//example'/>
        /// <param name="flightId">Unique identifier for the currently active flight.</param>
        /// <returns>If successful, returns an instance of InventoryDefinition containing the full list of available items. Otherwise, returns null.</returns>
        public async Task<InventoryDefinition> GameCmsGetCustomizationCatalog(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/inventory/catalog/inventory_catalog.json?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<InventoryDefinition>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets information about graphic device preset overrides.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetDevicePresetOverrides.xml' path='//example'/>
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

        /// <summary>
        /// Gets information about an in-game event.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetEvent.xml' path='//example'/>
        /// <param name="eventPath">The path to the event file. An example value is "RewardTracks/Events/Rituals/ritualEagleStrike.json".</param>
        /// <param name="flightId">Unique identifier for the currently active flight.</param>
        /// <returns></returns>
        public async Task<RewardTrackMetadata> GameCmsGetEvent(string eventPath, string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/file/{eventPath}?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<RewardTrackMetadata>(response);
            }
            else
            {
                return null;
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

        /// <summary>
        /// Gets the queries used to obtain override values for graphic device specifications.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetGraphicsSpecControlOverrides.xml' path='//example'/>
        /// <returns>If successful, returns an instance of OverrideQueryDefinition containing query definitions. Otherwise, returns null.</returns>
        public async Task<OverrideQueryDefinition> GameCmsGetGraphicsSpecControlOverrides()
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Specs/file/graphics/GraphicsSpecControlOverrides.json",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<OverrideQueryDefinition>(response);
            }
            else
            {
                return null;
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
        /// <include file='../APIDocsExamples/GameCms_GetRecommendedDrivers.xml' path='//example'/>
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
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, an instance of SeasonRewardTrack containing season information. Otherwise, returns null.</returns>
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

        /// <summary>
        /// This API currently returns a 404, and is not active. Additional investigation required.
        /// </summary>
        /// <remarks>INACTIVE API</remarks>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>Unknown.</returns>
        private async Task<string> GameCmsGetSeasonRewardTrackManifest(string flightId)
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

        /// <summary>
        /// API currently returns a 403 Forbidden even though the correct Spartan token and clearance are used. Haven't seen this API in the logs either, so not sure if it's still active.
        /// </summary>
        /// <remarks>INACTIVE API</remarks>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>Unknown.</returns>
        private async Task<string> GameCmsGetStorefronts(string flightId)
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

        /// <summary>
        /// This API currently returns a 400 Bad Request with a "Title mismatch between path and flight" message. Assuming because the branch is pre-cooked in the URL 
        /// </summary>
        /// <remarks>INACTIVE API</remarks>
        /// <returns>Unknown.</returns>
        private async Task<string> GameCmsGetUiConfigurationJson()
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

        //================================================
        // GameCmsGetGuide
        //================================================
        /// <summary>
        /// Gets a list of all available image files currently used by the multiplayer service.
        /// </summary>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <include file='../APIDocsExamples/GameCms_GetGuideImages.xml' path='//example'/>
        /// <returns>If successful, an instance of GuideContainer containing file information. Otherwise, returns null.</returns>
        public async Task<GuideContainer> GameCmsGetGuideImages(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/images/guide/xo?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<GuideContainer>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a list of all available multiplayer files currently used by the multiplayer service.
        /// </summary>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <include file='../APIDocsExamples/GameCms_GetGuideMultiplayer.xml' path='//example'/>
        /// <returns>If successful, an instance of GuideContainer containing file information. Otherwise, returns null.</returns>
        public async Task<GuideContainer> GameCmsGetGuideMultiplayer(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Multiplayer/guide/xo?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<GuideContainer>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a list of all available news files currently used by the multiplayer service.
        /// </summary>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <include file='../APIDocsExamples/GameCms_GetGuideNews.xml' path='//example'/>
        /// <returns>If successful, an instance of GuideContainer containing file information. Otherwise, returns null.</returns>
        public async Task<GuideContainer> GameCmsGetGuideNews(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/News/guide/xo?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<GuideContainer>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a list of all available progression files currently used by the multiplayer service.
        /// </summary>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <include file='../APIDocsExamples/GameCms_GetGuideProgression.xml' path='//example'/>
        /// <returns>If successful, an instance of GuideContainer containing file information. Otherwise, returns null.</returns>
        public async Task<GuideContainer> GameCmsGetGuideProgression(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Progression/guide/xo?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<GuideContainer>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a list of all available spec files currently used by the multiplayer service.
        /// </summary>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <include file='../APIDocsExamples/GameCms_GetGuideSpecs.xml' path='//example'/>
        /// <returns>If successful, an instance of GuideContainer containing file information. Otherwise, returns null.</returns>
        public async Task<GuideContainer> GameCmsGetGuideSpecs(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/Specs/guide/xo?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<GuideContainer>(response);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a list of all available title authorization files currently used by the multiplayer service.
        /// </summary>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <include file='../APIDocsExamples/GameCms_GetGuideTitleAuthorization.xml' path='//example'/>
        /// <returns>If successful, an instance of GuideContainer containing file information. Otherwise, returns null.</returns>
        public async Task<GuideContainer> GameCmsGetGuideTitleAuthorization(string flightId)
        {
            var response = await ExecuteAPIRequest<string>($"https://gamecms-hacs.svc.halowaypoint.com:443/hi/TitleAuthorization/guide/xo?flight={flightId}",
                                   HttpMethod.Get,
                                   true,
                                   true,
                                   GlobalConstants.HALO_WAYPOINT_USER_AGENT);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<GuideContainer>(response);
            }
            else
            {
                return null;
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
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetProjectWithoutVersion.xml' path='//example'/>
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
        /// <remarks>INACTIVE API</remarks>
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
        /// <remarks>INACTIVE API</remarks>
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
        /// <remarks>INACTIVE API</remarks>
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
        /// <remarks>INACTIVE API</remarks>
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
