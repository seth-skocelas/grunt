// <copyright file="HaloInfiniteClient.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OpenSpartan.Grunt.Converters;
using OpenSpartan.Grunt.Endpoints;
using OpenSpartan.Grunt.Models;
using OpenSpartan.Grunt.Models.HaloInfinite;
using OpenSpartan.Grunt.Models.HaloInfinite.ApiIngress;
using OpenSpartan.Grunt.Util;

namespace OpenSpartan.Grunt.Core
{
    /// <summary>
    /// Client used to access the Halo Infinite API surface.
    /// </summary>
    public class HaloInfiniteClient
    {
        private readonly JsonSerializerOptions serializerOptions = new()
        {
            WriteIndented = true,
            Converters =
            {
                new EmptyDateStringToNullJsonConverter(),
                new XmlDurationToTimeSpanJsonConverter(),
            },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="HaloInfiniteClient"/> class, used to access the Halo Infinite API.
        /// </summary>
        /// <param name="spartanToken">The Spartan token used to authenticate against the Halo Infinite API.</param>
        /// <param name="xuid">The player identifier in the format "xuid(XUID_VALUE)".</param>
        /// <param name="clearanceToken">ID of the flight/clearance currently active for the player. Optional when first instantiating the client.</param>
        public HaloInfiniteClient(string spartanToken, string xuid = "", string clearanceToken = "")
        {
            this.SpartanToken = spartanToken;
            this.Xuid = xuid;
            this.ClearanceToken = clearanceToken;
        }

        /// <summary>
        /// Gets or sets the Spartan token used to authenticate against the Halo Infinite API.
        /// </summary>
        public string SpartanToken { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the  player identifier in the format "xuid(XUID_VALUE)".
        /// </summary>
        public string Xuid { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ID of the flight/clearance currently active for the player.
        /// </summary>
        public string ClearanceToken { get; set; } = string.Empty;


        /// <summary>
        /// Gets the list of API settings as provided by the official Halo API. This is the latest version of all available endpoints.
        /// </summary>
        /// <include file='../APIDocsExamples/GetApiSettingsContainer.xml' path='//example'/>
        /// <returns>An instance of ApiSettingsContainer if the call is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<ApiSettingsContainer, HaloApiErrorContainer>> GetApiSettingsContainer()
        {
            return await this.ExecuteAPIRequest<ApiSettingsContainer>(
                HaloCoreEndpoints.HaloInfiniteEndpointsEndpoint,
                HttpMethod.Get,
                false,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        // ================================================
        // Academy
        // ================================================

        /// <summary>
        /// Get bot customization information.
        /// </summary>
        /// <include file='../APIDocsExamples/Academy_GetBotCustomization.xml' path='//example'/>
        /// <param name="flightId">ID of the flight/clearance associated with the request.</param>
        /// <returns>If successful, returns an instance of BotCustomizationData that contains bot customization information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<BotCustomizationData, HaloApiErrorContainer>> AcademyGetBotCustomization(string flightId)
        {
            return await this.ExecuteAPIRequest<BotCustomizationData>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/multiplayer/file/Academy/BotCustomizationData.json?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_PC_USER_AGENT);
        }

        /// <summary>
        /// Gets the client manifest for the Academy.
        /// </summary>
        /// <include file='../APIDocsExamples/Academy_GetContent.xml' path='//example'/>
        /// <returns>If successful, returns an instance of AcademyClientManifest that contains the definition of drills available in the Academy. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AcademyClientManifest, HaloApiErrorContainer>> AcademyGetContent()
        {
            return await this.ExecuteAPIRequest<AcademyClientManifest>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/multiplayer/file/Academy/AcademyClientManifest.json",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_PC_USER_AGENT);
        }

        /// <summary>
        /// Gets the client manifest for the Academy. From the endpoint name we can infer that this is test data.
        /// </summary>
        /// <include file='../APIDocsExamples/Academy_GetContentTest.xml' path='//example'/>
        /// <param name="clearanceId">ID of the flight/clearance associated with the request.</param>
        /// <returns>If successful, returns an instance of TestAcademyClientManifest that contains the definition of drills available in the Academy. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<TestAcademyClientManifest, HaloApiErrorContainer>> AcademyGetContentTest(string clearanceId)
        {
            return await this.ExecuteAPIRequest<TestAcademyClientManifest>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/multiplayer/file/Academy/AcademyClientManifest_Test.json?flight={clearanceId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_PC_USER_AGENT);
        }

        /// <summary>
        /// Gets definitions for stars awarded in the Academy. This call breaks if a user agent is specified.
        /// </summary>
        /// <include file='../APIDocsExamples/Academy_GetStarDefinitions.xml' path='//example'/>
        /// <returns>If successful, returns an instance of AcademyStarDefinitions that contains definitions for stars awarded in the Academy. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AcademyStarDefinitions, HaloApiErrorContainer>> AcademyGetStarDefinitions()
        {
            return await this.ExecuteAPIRequest<AcademyStarDefinitions>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/multiplayer/file/Academy/AcademyStarGUIDDefinitions.json",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_PC_USER_AGENT);
        }

        // ================================================
        // Economy
        // ================================================

        /// <summary>
        /// Gets information about an individual AI Core.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_AiCoreCustomization.xml' path='//example'/>
        /// <param name="player">The player identifier in the format "xuid(XUID_VALUE)".</param>
        /// <param name="coreId">Unique AI Core ID. Example ID is "304-100-ai-core-debb20e3".</param>
        /// <returns>If successful, returns an instance of Core containing AI core customization metadata if request was successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AiCore, HaloApiErrorContainer>> EconomyAiCoreCustomization(string player, string coreId)
        {
            return await this.ExecuteAPIRequest<AiCore>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/customization/ais/{coreId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Get AI core customization for a player.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_AiCoresCustomization.xml' path='//example'/>
        /// <param name="player">The player identifier in the format "xuid(XUID_VALUE)".</param>
        /// <returns>An instance of AiCores containing AI core customization metadata if request was successful. Return value is null otherwise.</returns>
        public async Task<HaloApiResultContainer<AiCoreContainer, HaloApiErrorContainer>> EconomyAiCoresCustomization(string player)
        {
            return await this.ExecuteAPIRequest<AiCoreContainer>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/customization/ais",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_PC_USER_AGENT);
        }

        /// <summary>
        /// Get details about all owned cores for a player.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_AllOwnedCoresDetails.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>An instance of PlayerCores containing player core customization metadata if request was successful. Return value is null otherwise.</returns>
        public async Task<HaloApiResultContainer<PlayerCores, HaloApiErrorContainer>> EconomyAllOwnedCoresDetails(string player)
        {
            return await this.ExecuteAPIRequest<PlayerCores>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/cores",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_PC_USER_AGENT);
        }

        /// <summary>
        /// Gets information about a specific armor core a player owns.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_ArmorCoreCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="coreId">The unique identifier for an armor core. An example value is "017-001-eag-c13d0b38".</param>
        /// <returns>If successful, returns an instance of ArmorCore containing customization information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<ArmorCore, HaloApiErrorContainer>> EconomyArmorCoreCustomization(string player, string coreId)
        {
            return await this.ExecuteAPIRequest<ArmorCore>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/customization/armors/{coreId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about all armor cores a player owns.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_ArmorCoresCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of ArmorCoreCollection that contains the list of armor cores. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<ArmorCoreCollection, HaloApiErrorContainer>> EconomyArmorCoresCustomization(string player)
        {
            return await this.ExecuteAPIRequest<ArmorCoreCollection>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/customization/armors",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about currently active boosts for the player.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetActiveBoosts.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of ActiveBoostsContainer that contains the list of active boosts. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<ActiveBoostsContainer, HaloApiErrorContainer>> EconomyGetActiveBoosts(string player)
        {
            return await this.ExecuteAPIRequest<ActiveBoostsContainer>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/boosts",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about a reward given to a player.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetAwardedRewards.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="rewardId">The unique ID for the reward given to a player. Example value is "Challenges-35a86ae3-017c-4b5a-b633-b2802a770e0a".</param>
        /// <returns>If successful, returns an instance of RewardSnapshot that contains the list of awarded rewards. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<RewardSnapshot, HaloApiErrorContainer>> EconomyGetAwardedRewards(string player, string rewardId)
        {
            return await this.ExecuteAPIRequest<RewardSnapshot>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/rewards/{rewardId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about boosts offering in the store for a given player.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetBoostsStore.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of StoreItem containing boost information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<StoreItem, HaloApiErrorContainer>> EconomyGetBoostsStore(string player)
        {
            return await this.ExecuteAPIRequest<StoreItem>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/stores/boosts",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the information about giveaways available for a given player.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetGiveawayRewards.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of PlayerGiveaways containing available giveaways. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<PlayerGiveaways, HaloApiErrorContainer>> EconomyGetGiveawayRewards(string player)
        {
            return await this.ExecuteAPIRequest<PlayerGiveaways>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/giveaways",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about items available for sale in the Halo Championship Series (HCS) store.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetHCSStore.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, an instance of StoreItem containing store offerings. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<StoreItem, HaloApiErrorContainer>> EconomyGetHCSStore(string player)
        {
            return await this.ExecuteAPIRequest<StoreItem>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/stores/hcs",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about items available in the current player's inventory.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetInventoryItems.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of PlayerInventory that contains a list of items in the player's inventory. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<PlayerInventory, HaloApiErrorContainer>> EconomyGetInventoryItems(string player)
        {
            return await this.ExecuteAPIRequest<PlayerInventory>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/inventory",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the information about all available items in the main store.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetMainStore.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of StoreItem that contains information about items available in the main store. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<StoreItem, HaloApiErrorContainer>> EconomyGetMainStore(string player)
        {
            return await this.ExecuteAPIRequest<StoreItem>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/stores/main",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about customizations for multiple players.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetMultiplePlayersCustomization.xml' path='//example'/>
        /// <param name="playerIds">Array of player IDs. Each ID string should be in the format of "xuid(XUID_VALUE)."</param>
        /// <returns>If successful, returns an instance of PlayerCustomizationCollection that contains player customizations. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<PlayerCustomizationCollection, HaloApiErrorContainer>> EconomyGetMultiplePlayersCustomization(List<string> playerIds)
        {
            var formattedPlayerList = string.Join(",", playerIds);
            return await this.ExecuteAPIRequest<PlayerCustomizationCollection>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/customization?players={formattedPlayerList}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about the operations reward levels store.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetOperationRewardLevelsStore.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of StoreItem that contains information about items available in the operations reward levels store. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<StoreItem, HaloApiErrorContainer>> EconomyGetOperationRewardLevelsStore(string player)
        {
            return await this.ExecuteAPIRequest<StoreItem>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/stores/operationrewardlevels",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about the operations store.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetOperationsStore.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of StoreItem that contains information about items available in the operations store. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<StoreItem, HaloApiErrorContainer>> EconomyGetOperationsStore(string player)
        {
            return await this.ExecuteAPIRequest<StoreItem>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/stores/operations",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about rewards associated with a given reward track, such as a season or special event.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetRewardTrack.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="rewardTrackType">Type of reward track. For seasons, this is usually "operation". This parameter is a singular noun, and is pluralized automatically in the function (the "s" character is appended).</param>
        /// <param name="trackId">Unique identifier for the reward track. An example value is "battlepass-noblesacrifice.json".</param>
        /// <returns>If successful, returns an instance of RewardTrack containing information for reward track tiers. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<RewardTrackMetadata, HaloApiErrorContainer>> EconomyGetRewardTrack(string player, string rewardTrackType, string trackId)
        {
            return await this.ExecuteAPIRequest<RewardTrackMetadata>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/rewardtracks/{rewardTrackType}s/{trackId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the amount of currencies that the player has in their account.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetVirtualCurrencyBalances.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of CurrencySnapshot that contains the balances. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<CurrencySnapshot, HaloApiErrorContainer>> EconomyGetVirtualCurrencyBalances(string player)
        {
            return await this.ExecuteAPIRequest<CurrencySnapshot>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/currencies",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about items on sale in the XP grants store.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_GetXpGrantsStore.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of StoreItem that contains information about items in the store. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<StoreItem, HaloApiErrorContainer>> EconomyGetXpGrantsStore(string player)
        {
            return await this.ExecuteAPIRequest<StoreItem>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/stores/xpgrants",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about a specific owned core.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_OwnedCoreDetails.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="coreId">The unque core ID. An example is "017-001-eag-c13d0b38".</param>
        /// <returns>If successful, returns an instance of Core containing core information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<GenericCore, HaloApiErrorContainer>> EconomyOwnedCoreDetails(string player, string coreId)
        {
            return await this.ExecuteAPIRequest<GenericCore>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/cores/{coreId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the current player appearance customization state.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_PlayerAppearanceCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of AppearanceCustomization containing customization information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AppearanceCustomization, HaloApiErrorContainer>> EconomyPlayerAppearanceCustomization(string player)
        {
            return await this.ExecuteAPIRequest<AppearanceCustomization>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/customization/appearance",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about available player customizations.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_PlayerCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="viewType">Determines which view into customizations is shown. Available values are "public" and "private". The private view enables showing all available cores, while the public view only shows equipped cores.</param>
        /// <returns>If successful, returns an instance of CustomizationData containing player customizations. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<CustomizationData, HaloApiErrorContainer>> EconomyPlayerCustomization(string player, string viewType)
        {
            return await this.ExecuteAPIRequest<CustomizationData>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/customization?view={viewType}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets available reward tracks for a player based on current and past battle passes.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_PlayerOperations.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of OperationRewardTrackSnapshot containing battle pass information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<OperationRewardTrackSnapshot, HaloApiErrorContainer>> EconomyPlayerOperations(string player)
        {
            return await this.ExecuteAPIRequest<OperationRewardTrackSnapshot>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/rewardtracks/operations",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about transactions that the player executed.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_PostCurrencyTransaction.xml' path='//example'/>
        /// <remarks>
        /// This function is likely used as a POST as well (hence the name - right now we're only using GET). Once we discover how this API works, we can extend the functionality further. <see href="https://github.com/OpenSpartan/grunt/issues/14">GitHub issue</see>.
        /// </remarks>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="currencyId">The unique identifier for the currency. Valid values include "cr", "rerollcurrency", "xpboost", and "xpgrant".</param>
        /// <returns>If successful, returns an instance of TransactionSnapshot listing all existing transactions. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<TransactionSnapshot, HaloApiErrorContainer>> EconomyPostCurrencyTransaction(string player, string currencyId)
        {
            return await this.ExecuteAPIRequest<TransactionSnapshot>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/currencies/{currencyId}/transactions",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// This API does not work with GET requests and is likely used to post transactions. Additional investigation is required.
        /// </summary>
        /// <remarks>INACTIVE API. See <see href="https://github.com/OpenSpartan/grunt/issues/15">GitHub issue</see>.</remarks>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>Unknown.</returns>
        private async Task<HaloApiResultContainer<string, HaloApiErrorContainer>> EconomyPurchaseStorefrontOfferingTransaction(string player)
        {
            return await this.ExecuteAPIRequest<string>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/storetransactions",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }


        /// <summary>
        /// Gets information about offerings for a player in a given store.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_ScheduledStorefrontOfferings.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="storeId">The unique store identifier. An example value is "hcs".</param>
        /// <returns>If successful, returns an instance of StoreItem containing offerings. Otherwise, returns null.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:Elements should be ordered by access", Justification = "Currently maintaining the order of APIs that are outlined in the endpoints response.")]
        public async Task<HaloApiResultContainer<StoreItem, HaloApiErrorContainer>> EconomyScheduledStorefrontOfferings(string player, string storeId)
        {
            return await this.ExecuteAPIRequest<StoreItem>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/stores/{storeId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the currently active Spartan body customization.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_SpartanBodyCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of SpartanBody containing the customization information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<SpartanBody, HaloApiErrorContainer>> EconomySpartanBodyCustomization(string player)
        {
            return await this.ExecuteAPIRequest<SpartanBody>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/customization/spartanbody",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about a vehicle core.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_VehicleCoreCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="coreId">Unique vehicle core ID. Example value is "409-304-olympus-e8b8a8b3".</param>
        /// <returns>If successful, returns an instance of VehicleCore. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<VehicleCore, HaloApiErrorContainer>> EconomyVehicleCoreCustomization(string player, string coreId)
        {
            return await this.ExecuteAPIRequest<VehicleCore>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/customization/vehicles/{coreId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about the vehicle core customizations availale to a player.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_VehicleCoresCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of VehicleCoreCollection containing a list of available vehicle cores. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<VehicleCoreCollection, HaloApiErrorContainer>> EconomyVehicleCoresCustomization(string player)
        {
            return await this.ExecuteAPIRequest<VehicleCoreCollection>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/customization/vehicles",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about a specific weapon core.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_WeaponCoreCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="coreId">The unique ID of the weapon core.</param>
        /// <returns>If successful, returns an instance of WeaponCore containing information about the weapon core. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<WeaponCore, HaloApiErrorContainer>> EconomyWeaponCoreCustomization(string player, string coreId)
        {
            return await this.ExecuteAPIRequest<WeaponCore>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/customization/weapons/{coreId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about weapon cores equipped on a player.
        /// </summary>
        /// <include file='../APIDocsExamples/Economy_WeaponCoresCustomization.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of WeaponCoreCollection. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<WeaponCoreCollection, HaloApiErrorContainer>> EconomyWeaponCoresCustomization(string player)
        {
            return await this.ExecuteAPIRequest<WeaponCoreCollection>(
                $"https://{HaloCoreEndpoints.EconomyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/customization/weapons",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        // ================================================
        // GameCms
        // ================================================

        /// <summary>
        /// Returns the collection of available achievements to unlock in the game.
        /// </summary>
        /// <remarks>
        /// Keep in mind that this is not a list of achievements that the player has unlocked - it's just an aggregation of all available achievements in Halo Infinite.
        /// </remarks>
        /// <include file='../APIDocsExamples/GameCms_GetAchievements.xml' path='//example'/>
        /// <returns>If successful, returns an instance of AchievementCollection that contains the list of available achievements. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AchievementCollection, HaloApiErrorContainer>> GameCmsGetAchievements()
        {
            return await this.ExecuteAPIRequest<AchievementCollection>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Multiplayer/file/Live/Achievements.json",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about active async compute overrides. Unknown what the concrete purpose of this API is yet.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetAsyncComputeOverrides.xml' path='//example'/>
        /// <returns>If successful, returns an instance of AsyncComputeOverrides containing override metadata. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AsyncComputeOverrides, HaloApiErrorContainer>> GameCmsGetAsyncComputeOverrides()
        {
            return await this.ExecuteAPIRequest<AsyncComputeOverrides>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Specs/file/graphics/AsyncComputeOverrides.json",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns information about an existing challenge.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetChallenge.xml' path='//example'/>
        /// <param name="challengePath">Path to the challenge file. Example is "ChallengeContent/ClientChallengeDefinitions/S1RotationalSet1Challenges/Normal/NTeamSlayerPlay.json".</param>
        /// <param name="flightId">The unique ID for the currently active flight.</param>
        /// <returns>If successful, returns an instance of Challenge containing challenge information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<Challenge, HaloApiErrorContainer>> GameCmsGetChallenge(string challengePath, string flightId)
        {
            return await this.ExecuteAPIRequest<Challenge>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Progression/file/{challengePath}?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the information about a specific challenge deck.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetChallengeDeck.xml' path='//example'/>
        /// <param name="challengeDeckPath">Path to the challenge deck. An example value is "ChallengeContent/ClientChallengeDeckDefinitions/S2EntrenchedWeeklyDeck2.json".</param>
        /// <param name="flightId">Unique identifier for the currently active flight.</param>
        /// <returns>If successful, returns an instance of ChallengeDeckDefinition containing challenge deck metadata. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<ChallengeDeckDefinition, HaloApiErrorContainer>> GameCmsGetChallengeDeck(string challengeDeckPath, string flightId)
        {
            return await this.ExecuteAPIRequest<ChallengeDeckDefinition>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Progression/file/{challengeDeckPath}?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the information about a specific currency type.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetCurrency.xml' path='//example'/>
        /// <param name="currencyPath">Path to the currency. An example is "currency/currencies/cr.json".</param>
        /// <param name="flightId">Unique identifier for the currently active flight.</param>
        /// <returns>If successful, returns an instance of CurrencyDefinition containing information about the specified currency. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<CurrencyDefinition, HaloApiErrorContainer>> GameCmsGetCurrency(string currencyPath, string flightId)
        {
            return await this.ExecuteAPIRequest<CurrencyDefinition>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Progression/file/{currencyPath}?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
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
        public async Task<HaloApiResultContainer<ClawAccessSnapshot, HaloApiErrorContainer>> GameCmsGetClawAccess(string flightId)
        {
            return await this.ExecuteAPIRequest<ClawAccessSnapshot>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/TitleAuthorization/file/claw/access.json?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the pre-defined CPU presets for different game performance configurations.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetCPUPresets.xml' path='//example'/>
        /// <returns>If successful, returns an instance of CPUPresetSnapshot containing preset information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<CPUPresetSnapshot, HaloApiErrorContainer>> GameCmsGetCpuPresets()
        {
            return await this.ExecuteAPIRequest<CPUPresetSnapshot>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Specs/file/cpu/presets.json",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns the parameters for new custom games started in Halo Infinite.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetCustomGameDefaults.xml' path='//example'/>
        /// <returns>If successful, returns an instance of CustomGameDefinition containing game parameters. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<CustomGameDefinition, HaloApiErrorContainer>> GameCmsGetCustomGameDefaults()
        {
            return await this.ExecuteAPIRequest<CustomGameDefinition>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Multiplayer/file/NonMatchmaking/customgame.json",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the full list of existing in-game items.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetCustomizationCatalog.xml' path='//example'/>
        /// <param name="flightId">Unique identifier for the currently active flight.</param>
        /// <returns>If successful, returns an instance of InventoryDefinition containing the full list of available items. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<InventoryDefinition, HaloApiErrorContainer>> GameCmsGetCustomizationCatalog(string flightId)
        {
            return await this.ExecuteAPIRequest<InventoryDefinition>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Progression/file/inventory/catalog/inventory_catalog.json?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about graphic device preset overrides.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetDevicePresetOverrides.xml' path='//example'/>
        /// <remarks>
        /// The exact purpose of this function is unknown at this time, and requires additional investigation.
        /// </remarks>
        /// <returns>If successful, an instance of DevicePresetOverrides. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<DevicePresetOverrides, HaloApiErrorContainer>> GameCmsGetDevicePresetOverrides()
        {
            return await this.ExecuteAPIRequest<DevicePresetOverrides>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Specs/file/graphics/DevicePresetOverrides.json",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about an in-game event.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetEvent.xml' path='//example'/>
        /// <param name="eventPath">The path to the event file. An example value is "RewardTracks/Events/Rituals/ritualEagleStrike.json".</param>
        /// <param name="flightId">Unique identifier for the currently active flight.</param>
        /// <returns>If successful, an instance of RewardTrackMetadata is returned. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<RewardTrackMetadata, HaloApiErrorContainer>> GameCmsGetEvent(string eventPath, string flightId)
        {
            return await this.ExecuteAPIRequest<RewardTrackMetadata>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Progression/file/{eventPath}?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the queries used to obtain override values for graphic device specifications.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetGraphicsSpecControlOverrides.xml' path='//example'/>
        /// <returns>If successful, returns an instance of OverrideQueryDefinition containing query definitions. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<OverrideQueryDefinition, HaloApiErrorContainer>> GameCmsGetGraphicsSpecControlOverrides()
        {
            return await this.ExecuteAPIRequest<OverrideQueryDefinition>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Specs/file/graphics/GraphicsSpecControlOverrides.json",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Unknown what this API specifically returns, but the assumption is that it's configuration for graphic setting overrides.
        /// </summary>
        /// <remarks>
        /// TODO: Need to figure out what the API response here is. Haven't seen this actually activated in-game. For the time being, the API call will return a raw response. For details, see <see href="https://github.com/OpenSpartan/grunt/issues/18">GitHub issue</see>.
        /// </remarks>
        /// <returns>Returns a string containing the response.</returns>
        public async Task<HaloApiResultContainer<string, HaloApiErrorContainer>> GameCmsGetGraphicSpecs()
        {
            return await this.ExecuteAPIRequest<string>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Specs/file/graphics/overrides.json",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets an image for an associated game CMS asset. Example path is "progression/inventory/armor/gloves/003-001-olympus-8e7c9dff-sm.png".
        /// </summary>
        /// <param name="filePath">Path to the CMS image.</param>
        /// <returns>If successful, returns the byte array for the requested image. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<byte[], HaloApiErrorContainer>> GameCmsGetImage(string filePath)
        {
            return await this.ExecuteAPIRequest<byte[]>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/images/file/{filePath}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets a specific item from the Game CMS, such as armor emplems, weapon cores, vehicle cores, and others.
        /// </summary>
        /// <remarks>
        /// For example, you may find that you can get the data about an armor emblem with the path "/inventory/armor/emblems/013-001-363f4a25.json".
        /// </remarks>
        /// <include file='../APIDocsExamples/GameCms_GetItem.xml' path='//example'/>
        /// <param name="itemPath">Path to the item to be obtained. Example is "/inventory/armor/emblems/013-001-363f4a25.json".</param>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, an instance of InGameItem. Otherwise, null.</returns>
        public async Task<HaloApiResultContainer<InGameItem, HaloApiErrorContainer>> GameCmsGetItem(string itemPath, string flightId)
        {
            return await this.ExecuteAPIRequest<InGameItem>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Progression/file/{itemPath}?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the list of possible error messages that a player can get when attempting to join multiplayer games.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetLobbyErrorMessages.xml' path='//example'/>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, returns an instance of LobbyHopperErrorMessageList that contains possible errors. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<LobbyHopperErrorMessageList, HaloApiErrorContainer>> GameCmsGetLobbyErrorMessages(string flightId)
        {
            return await this.ExecuteAPIRequest<LobbyHopperErrorMessageList>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Multiplayer/file/gameStartErrorMessages/LobbyHoppperErrorMessageList.json?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns metadata on currently available in-game manufacturers and currencies.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetMetadata.xml' path='//example'/>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, an instance of Metadata containing the information about in-game manufacturers and currencies. Otherwise, null.</returns>
        public async Task<HaloApiResultContainer<Metadata, HaloApiErrorContainer>> GameCmsGetMetadata(string flightId)
        {
            return await this.ExecuteAPIRequest<Metadata>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Progression/file/metadata/metadata.json?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns the network configuration for the current flight.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetNetworkConfiguration.xml' path='//example'/>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, returns an instance of NetworkConfiguration. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<NetworkConfiguration, HaloApiErrorContainer>> GameCmsGetNetworkConfiguration(string flightId)
        {
            return await this.ExecuteAPIRequest<NetworkConfiguration>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Multiplayer/file/network/config.json?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns the currently relevant news.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetNews.xml' path='//example'/>
        /// <param name="filePath">Path to the news collection. Example is "/articles/articles.json".</param>
        /// <returns>If successful, returns a News instance containing the currently active news. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<News, HaloApiErrorContainer>> GameCmsGetNews(string filePath)
        {
            return await this.ExecuteAPIRequest<News>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/news/file/{filePath}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns information about a message that is displayed when, I assume, authentication fails.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetNotAllowedInTitleMessage.xml' path='//example'/>
        /// <remarks>It's unclear where this is actually used because the sample response is a test one, without any relevant context.</remarks>
        /// <returns>If successful, an instance of OEConfiguration containing the message. Otherwise, null.</returns>
        public async Task<HaloApiResultContainer<OEConfiguration, HaloApiErrorContainer>> GameCmsGetNotAllowedInTitleMessage()
        {
            return await this.ExecuteAPIRequest<OEConfiguration>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/branches/hi/OEConfiguration/data/authfail/Default.json",
                HttpMethod.Get,
                false,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns a progression file. This method is using a generic parameter due to the fact that there are multiple progression file variants.
        /// </summary>
        /// <typeparam name="T">Type of progression file to be obtained.</typeparam>
        /// <param name="filePath">Path to the progression file.</param>
        /// <returns>If successful, returns an instance of T, where T is the type of the progression file. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<T, HaloApiErrorContainer>> GameCmsGetProgressionFile<T>(string filePath)
        {
            return await this.ExecuteAPIRequest<T>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Progression/file/{filePath}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Get recommended drivers for the current version of Halo Infinite.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetRecommendedDrivers.xml' path='//example'/>
        /// <returns>If successful, returns an instance of DriverManifest that contains details on supported drivers. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<DriverManifest, HaloApiErrorContainer>> GameCmsGetRecommendedDrivers()
        {
            return await this.ExecuteAPIRequest<DriverManifest>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Specs/file/graphics/RecommendedDrivers.json",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_PC_USER_AGENT);
        }

        /// <summary>
        /// Gets information about a given Halo Infinite season.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetSeasonRewardTrack.xml' path='//example'/>
        /// <remarks>
        /// Keep in mind that the season numbers do not align cleanly with the public season numbers. For example, public Season 2 is Season 7 in this API. That is caused by a number of test season that 343 added to the product ahead of release.
        /// </remarks>
        /// <param name="seasonPath">The path to the season. Typical example is "Seasons/Season7.json" for the Lone Wolves season.</param>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, an instance of SeasonRewardTrack containing season information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<SeasonRewardTrack, HaloApiErrorContainer>> GameCmsGetSeasonRewardTrack(string seasonPath, string flightId)
        {
            return await this.ExecuteAPIRequest<SeasonRewardTrack>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Progression/file/{seasonPath}?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_PC_USER_AGENT);
        }

        // ================================================
        // GameCmsGetGuide
        // ================================================

        /// <summary>
        /// Gets a list of all available image files currently used by the multiplayer service.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetGuide_Images.xml' path='//example'/>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, an instance of GuideContainer containing file information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<GuideContainer, HaloApiErrorContainer>> GameCmsGetGuideImages(string flightId)
        {
            return await this.ExecuteAPIRequest<GuideContainer>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/images/guide/xo?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets a list of all available multiplayer files currently used by the multiplayer service.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetGuide_Multiplayer.xml' path='//example'/>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, an instance of GuideContainer containing file information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<GuideContainer, HaloApiErrorContainer>> GameCmsGetGuideMultiplayer(string flightId)
        {
            return await this.ExecuteAPIRequest<GuideContainer>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Multiplayer/guide/xo?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets a list of all available news files currently used by the multiplayer service.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetGuide_News.xml' path='//example'/>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, an instance of GuideContainer containing file information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<GuideContainer, HaloApiErrorContainer>> GameCmsGetGuideNews(string flightId)
        {
            return await this.ExecuteAPIRequest<GuideContainer>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/News/guide/xo?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets a list of all available progression files currently used by the multiplayer service.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetGuide_Progression.xml' path='//example'/>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, an instance of GuideContainer containing file information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<GuideContainer, HaloApiErrorContainer>> GameCmsGetGuideProgression(string flightId)
        {
            return await this.ExecuteAPIRequest<GuideContainer>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Progression/guide/xo?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets a list of all available spec files currently used by the multiplayer service.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetGuide_Specs.xml' path='//example'/>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, an instance of GuideContainer containing file information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<GuideContainer, HaloApiErrorContainer>> GameCmsGetGuideSpecs(string flightId)
        {
            return await this.ExecuteAPIRequest<GuideContainer>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/Specs/guide/xo?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets a list of all available title authorization files currently used by the multiplayer service.
        /// </summary>
        /// <include file='../APIDocsExamples/GameCms_GetGuide_TitleAuthorization.xml' path='//example'/>
        /// <param name="flightId">Unique ID for the currently active flight.</param>
        /// <returns>If successful, an instance of GuideContainer containing file information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<GuideContainer, HaloApiErrorContainer>> GameCmsGetGuideTitleAuthorization(string flightId)
        {
            return await this.ExecuteAPIRequest<GuideContainer>(
                $"https://{HaloCoreEndpoints.GameCmsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/TitleAuthorization/guide/xo?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        // ================================================
        // HIUGC
        // ================================================

        /// <summary>
        /// Checks whether the player has favorited a specific asset.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_CheckAssetPlayerBookmark.xml' path='//example'/>
        /// <param name="title">Title for which the asset should be obtained. An example value is "hi".</param>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "373f3d27-cb4c-4d7b-b6c9-7757de3c1133" for "Arena:King of the Hill".</param>
        /// <returns>If successful, returns an instance of FavoriteAsset containing asset information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<FavoriteAsset, HaloApiErrorContainer>> HIUGCCheckAssetPlayerBookmark(string title, string player, string assetType, string assetId)
        {
            return await this.ExecuteAPIRequest<FavoriteAsset>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/players/{player}/favorites/{assetType}/{assetId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Creates a new version of an asset as part of a working editing session.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_CreateAssetVersionAgnostic.xml' path='//example'/>
        /// <param name="title">Title which contains the asset. An example value here is "hi".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <param name="starter">Container for the session descriptor that starts the new version. Example value should contain an existing session ID for SourceId and value of 1 for Source.</param>
        /// <returns>If version creation is successful, returns an instance of AuthoringAssetVersion. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AuthoringAssetVersion, HaloApiErrorContainer>> HIUGCCreateAssetVersionAgnostic(string title, string assetType, string assetId, AuthoringSessionSourceStarter starter)
        {
            return await this.ExecuteAPIRequest<AuthoringAssetVersion>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}/versions",
                HttpMethod.Post,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT,
                JsonSerializer.Serialize(starter));
        }

        /// <summary>
        /// Deletes all versions of an asset.
        /// </summary>
        /// <param name="title">Title which contains the asset. An example value here is "hi".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <returns>If deletion is successful, returns true. Otherwise, returns false.</returns>
        public async Task<HaloApiResultContainer<bool, HaloApiErrorContainer>> HIUGCDeleteAllVersions(string title, string assetType, string assetId)
        {
            return await this.ExecuteAPIRequest<bool>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}/versions",
                HttpMethod.Delete,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Deletes an asset.
        /// </summary>
        /// <param name="title">Title which contains the asset. An example value here is "hi".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <returns>If deletion is successful, returns true. Otherwise, returns false.</returns>
        public async Task<HaloApiResultContainer<bool, HaloApiErrorContainer>> HIUGCDeleteAsset(string title, string assetType, string assetId)
        {
            return await this.ExecuteAPIRequest<bool>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}",
                HttpMethod.Delete,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Deletes a specific version of an asset.
        /// </summary>
        /// <param name="title">Title which contains the asset. An example value here is "hi".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <param name="versionId">Unique ID for the version of the asset. Example value is "2674c887-7aa1-42ab-a6cd-4a2c60611d0e" for the "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" asset.</param>
        /// <returns>If deletion is successful, returns true. Otherwise, returns false.</returns>
        public async Task<HaloApiResultContainer<bool, HaloApiErrorContainer>> HIUGCDeleteVersion(string title, string assetType, string assetId, string versionId)
        {
            return await this.ExecuteAPIRequest<bool>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}/versions/{versionId}",
                HttpMethod.Delete,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// End all active asset authoring sessions for a given asset.
        /// </summary>
        /// <param name="title">Title which contains the asset. An example value here is "hi".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <returns>If session termination is successful, return true. Otherwise, returns false.</returns>
        public async Task<HaloApiResultContainer<bool, HaloApiErrorContainer>> HIUGCEndSession(string title, string assetType, string assetId)
        {
            return await this.ExecuteAPIRequest<bool>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}/sessions/active",
                HttpMethod.Delete,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Favorites an asset for the player.
        /// </summary>
        /// <remarks>
        /// This method expects a JSON body, but I don't yet know what the underlying data structure is.
        /// </remarks>
        /// <include file='../APIDocsExamples/HIUGC_FavoriteAnAsset.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <returns>If successful, returns an instance of FavoriteAsset confirming the addition of the asset to favorites. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<FavoriteAsset, HaloApiErrorContainer>> HIUGCFavoriteAnAsset(string player, string assetType, string assetId)
        {
            return await this.ExecuteAPIRequest<FavoriteAsset>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/favorites/{assetType}/{assetId}",
                HttpMethod.Put,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT,
                "{}");
        }

        /// <summary>
        /// Gets authoring metadata about a specific asset.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_GetAsset.xml' path='//example'/>
        /// <param name="title">Title which contains the asset. An example value here is "hi".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <returns>If successful, returns an instance of AuthoringAsset containing authoring metadata. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AuthoringAsset, HaloApiErrorContainer>> HIUGCGetAsset(string title, string assetType, string assetId)
        {
            return await this.ExecuteAPIRequest<AuthoringAsset>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns a binary blob using it's path as a reference.
        /// </summary>
        /// <param name="blobPath">Path to the blob to be obtained.</param>
        /// <returns>If successful, returns a binary blob containing file data. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<byte[], HaloApiErrorContainer>> HIUGCGetBlob(string blobPath)
        {
            return await this.ExecuteAPIRequest<byte[]>(
                $"https://blobs-infiniteugc.{HaloCoreEndpoints.ServiceDomain}/{blobPath}",
                HttpMethod.Get,
                false,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the films for the latest asset version.
        /// </summary>
        /// <remarks>
        /// Interestingly enough, this API call did not contain the Film suffix in the name. I added it for explicit identification because otherwise it would be confusing.
        /// </remarks>
        /// <include file='../APIDocsExamples/HIUGC_GetLatestAssetVersionFilm.xml' path='//example'/>
        /// <param name="title">Title which contains the asset. An example value here is "hi".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <returns>If successful, returns an instance of AuthoringAssetVersion containing film data in the CustomData property. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AuthoringAssetVersion, HaloApiErrorContainer>> HIUGCGetLatestAssetVersionFilm(string title, string assetId)
        {
            return await this.ExecuteAPIRequest<AuthoringAssetVersion>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/films/{assetId}/versions/latest",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets metadata related to the latest version of a specified asset.
        /// </summary>
        /// <remarks>
        /// Certain asset types, such as engine game variants, might return a 403 response code for the API, therefore you will not get a real version here.
        /// </remarks>
        /// <include file='../APIDocsExamples/HIUGC_GetLatestAssetVersionAgnostic.xml' path='//example'/>
        /// <param name="title">Title which contains the asset. An example value here is "hi".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <returns>If successful, returns an instance of AuthoringAssetVersion containing version metadata for an asset. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AuthoringAssetVersion, HaloApiErrorContainer>> HIUGCGetLatestAssetVersionAgnostic(string title, string assetType, string assetId)
        {
            return await this.ExecuteAPIRequest<AuthoringAssetVersion>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}/versions/latest",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns a published version of the asset.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_GetPublishedVersion.xml' path='//example'/>
        /// <param name="title">Title which contains the asset. An example value here is "hi".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <returns>If successful, returns an instance of AuthoringAssetVersion containing version metadata for a published asset. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AuthoringAssetVersion, HaloApiErrorContainer>> HIUGCGetPublishedVersion(string title, string assetType, string assetId)
        {
            return await this.ExecuteAPIRequest<AuthoringAssetVersion>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}/versions/published",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets metadata related to a concrete version of a specified asset.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_GetSpecificAssetVersion.xml' path='//example'/>
        /// <param name="title">Title which contains the asset. An example value here is "hi".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <param name="versionId">Unique ID for the version of the asset. Example value is "2674c887-7aa1-42ab-a6cd-4a2c60611d0e" for the "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" asset.</param>
        /// <returns>If successful, returns an instance of AuthoringAssetVersion that contains asset version information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AuthoringAssetVersion, HaloApiErrorContainer>> HIUGCGetSpecificAssetVersion(string title, string assetType, string assetId, string versionId)
        {
            return await this.ExecuteAPIRequest<AuthoringAssetVersion>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}/versions/{versionId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about all versions for a specified asset.
        /// </summary>
        /// <remarks>
        /// The underlying request supports specifying parameters that limit the search, such as ?start=number, however that is not yet implemented in this version of the API wrapper.
        /// </remarks>
        /// <include file='../APIDocsExamples/HIUGC_ListAllVersions.xml' path='//example'/>
        /// <param name="title">Title which contains the asset. An example value here is "hi".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <returns>If successful, returns an instance of AuthoringAssetVersionContainer that contains information about all available versions for an asset. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AuthoringAssetVersionContainer, HaloApiErrorContainer>> HIUGCListAllVersions(string title, string assetType, string assetId)
        {
            return await this.ExecuteAPIRequest<AuthoringAssetVersionContainer>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}/versions",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about all authored assets that a player owns.
        /// </summary>
        /// <remarks>
        /// The underlying request supports specifying parameters that limit the search, such as ?start=number, however that is not yet implemented in this version of the API wrapper.
        /// </remarks>
        /// <include file='../APIDocsExamples/HIUGC_ListPlayerAssets.xml' path='//example'/>
        /// <param name="title">Title which contains the asset. An example value here is "hi".</param>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="start">Number of results from which to start the iteration.</param>
        /// <param name="count">Number of assets to return. Maximum is 25. Going beyond 25 will result in only 25 values being returned.</param>
        /// <param name="includeTimes">Include times for asset modification.</param>
        /// <param name="sort">Property by which to sort the results. Example is "PlaysRecent".</param>
        /// <param name="order">Determines whether results are ordered in descending or ascending order.</param>
        /// <param name="keywords">List of keywords by which to filter.</param>
        /// <param name="kind">Type of asset to return.</param>
        /// <returns>If successful, returns an instance of AuthoringAssetContainer containing information about assets a player owns. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AuthoringAssetContainer, HaloApiErrorContainer>> HIUGCListPlayerAssets(string title, string player, int start, int count, bool includeTimes, string sort, ResultOrder order, List<string> keywords, AssetKind kind)
        {
            var formattedKeywordList = string.Empty;
            if (keywords != null && keywords.Count > 0)
            {
                formattedKeywordList = string.Join(",", keywords);
            }

            return await this.ExecuteAPIRequest<AuthoringAssetContainer>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/players/{player}/assets?start={start}&count={count}&include-times={includeTimes}&sort={sort}&order={order}&keywords={formattedKeywordList}&kind={kind}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about favorite assets of a specific type a player has registered on their account.
        /// </summary>
        /// <remarks>
        /// The underlying request supports specifying parameters that limit the search, such as ?start=number, however that is not yet implemented in this version of the API wrapper.
        /// </remarks>
        /// <include file='../APIDocsExamples/HIUGC_ListPlayerFavorites.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <returns>If successful, returns an instance of AuthoringFavoritesContainer containing the list of favorites. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AuthoringFavoritesContainer, HaloApiErrorContainer>> HIUGCListPlayerFavorites(string player, string assetType)
        {
            return await this.ExecuteAPIRequest<AuthoringFavoritesContainer>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/favorites/{assetType}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets authored favorites a player has registered on their account.
        /// </summary>
        /// <remarks>
        /// The underlying request supports specifying parameters that limit the search, such as ?start=number, however that is not yet implemented in this version of the API wrapper.
        /// </remarks>
        /// <include file='../APIDocsExamples/HIUGC_ListPlayerFavoritesAgnostic.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, returns an instance of AuthoringFavoritesContainer containing the list of favorites. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AuthoringFavoritesContainer, HaloApiErrorContainer>> HIUGCListPlayerFavoritesAgnostic(string player)
        {
            return await this.ExecuteAPIRequest<AuthoringFavoritesContainer>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/favorites",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Update an existing asset version.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_PatchAssetVersion.xml' path='//example'/>
        /// <param name="title">Title for the game for which the authoring session needs to be spawned. Example variant is "hi" for "Halo Infinite".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <param name="versionId">Unique ID for the asset version to be published.</param>
        /// <param name="patchedAsset">Updated asset version with custom configuration.</param>
        /// <returns>If successful, returns an instance of HIUGCPatchAssetVersion containing the changes. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AuthoringAssetVersion, HaloApiErrorContainer>> HIUGCPatchAssetVersion(string title, string assetType, string assetId, string versionId, AuthoringAssetVersion patchedAsset)
        {
            return await this.ExecuteAPIRequest<AuthoringAssetVersion>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}/versions/{versionId}",
                HttpMethod.Patch,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT,
                JsonSerializer.Serialize(patchedAsset));
        }

        /// <summary>
        /// Publishes an asset version.
        /// </summary>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <param name="versionId">Unique ID for the asset version to be published.</param>
        /// <param name="clearanceId">ID of the currently active flight.</param>
        /// <returns>If the publishing process is successful, returns true. Otherwise, returns false.</returns>
        public async Task<HaloApiResultContainer<bool, HaloApiErrorContainer>> HIUGCPublishAssetVersion(string assetType, string assetId, string versionId, string clearanceId)
        {
            return await this.ExecuteAPIRequest<bool>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/{assetType}/{assetId}/publish/{versionId}?clearanceId={clearanceId}",
                HttpMethod.Post,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets player-assigned ratings for an asset.
        /// </summary>
        /// <remarks>
        /// This API is actually not captured in the endpoint catalog, but it seems to return values anyway.
        /// </remarks>
        /// <include file='../APIDocsExamples/HIUGC_GetAssetRatings.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <returns>If successful, returns an instance of AuthoringAssetRating containing rating information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AuthoringAssetRating, HaloApiErrorContainer>> HIUGCGetAssetRatings(string player, string assetType, string assetId)
        {
            return await this.ExecuteAPIRequest<AuthoringAssetRating>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/ratings/{assetType}/{assetId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Rates an asset the player has access to.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_RateAnAsset.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <param name="rating">An object containing asset rating information. Rating should be set in CustomData.</param>
        /// <returns>If successful, returns an instance of AuthoringAssetRating containing the updated rating. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AuthoringAssetRating, HaloApiErrorContainer>> HIUGCRateAnAsset(string player, string assetType, string assetId, AuthoringAssetRating rating)
        {
            return await this.ExecuteAPIRequest<AuthoringAssetRating>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/ratings/{assetType}/{assetId}",
                HttpMethod.Put,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT,
                JsonSerializer.Serialize(rating));
        }

        /// <summary>
        /// Reports an asset.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_ReportAnAsset.xml' path='//example'/>
        /// <param name="player">The unique player XUID, in the format "xuid(XUID_VALUE)".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique ID for the asset. Example value is "f96f57e2-9f15-45c5-83ac-5775a48d2ba8" for "Attrition-Default-UGC".</param>
        /// <returns>If successful, returns an instance of AssetReport containing the report information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AssetReport, HaloApiErrorContainer>> HIUGCReportAnAsset(string player, string assetType, string assetId, AssetReport report)
        {
            return await this.ExecuteAPIRequest<AssetReport>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/reports/{assetType}/{assetId}",
                HttpMethod.Put,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT,
                JsonSerializer.Serialize(report));
        }

        /// <summary>
        /// API for creating new assets.
        /// </summary>
        /// <remarks>
        /// This API is used to create new assets in the user's file browser. The game generally uses Bond-encoded requests, so it's
        /// still up to discovery to figure out what the values for the POST request are.
        /// TODO: Need to figure out what the actual data model is for the POST request.
        /// </remarks>
        /// <include file='../APIDocsExamples/HIUGC_SpawnAsset.xml' path='//example'/>
        /// <param name="title">Title for the game for which the authoring session needs to be spawned. Example variant is "hi" for "Halo Infinite".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants", "Maps", or "Prefabs".</param>
        /// <param name="asset">Asset definition, containing information about the asset to be created.</param>
        /// <param name="contentType">Content type to be used for the request. Default value uses the Bond encoding.</param>
        /// <returns>If successful, returns an instance of AuthoringAsset containing asset information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AuthoringAsset, HaloApiErrorContainer>> HIUGCSpawnAsset(string title, string assetType, object? asset = null, ApiContentType contentType = ApiContentType.BondCompactBinary)
        {
            if (asset is null)
            {
                throw new ArgumentNullException(nameof(asset), "You need to provide an asset definition to create one. Make sure the `asset` object is not null or unspecified.");
            }

            return await this.ExecuteAPIRequest<AuthoringAsset>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}",
                HttpMethod.Post,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT,
                JsonSerializer.Serialize(asset),
                contentType);
        }

        /// <summary>
        /// Starts a new authoring session to edit an asset.
        /// </summary>
        /// <remarks>
        /// Was successful with a POST to https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/UgcGameVariants/9bc31094-8326-42ee-85d5-12e48ee1b129/sessions
        /// Game variant has to be local to the account
        /// POSTed content is like this:
        /// {
        ///    "PreviousVersionId": "974c6f1a-9e86-4719-8b70-d055d370bc75",
        ///    "SessionOrigin": "xuid(XUID_VALUE)"
        /// }
        /// It also seems that using `includeContainerSas` results in a 403 response, but without it a session can be created.
        /// </remarks>
        /// <include file='../APIDocsExamples/HIUGC_StartSessionAgnostic.xml' path='//example'/>
        /// <param name="title">Title for the game for which the authoring session needs to be spawned. Example variant is "hi" for "Halo Infinite".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique asset ID for the asset type specified earlier.</param>
        /// <param name="includeContainerSas">Determines whether to include the container SAS in the response or not. Setting this value to "true" will result in a 403 Forbidden error.</param>
        /// <param name="starter">Starter object that describes who is starting the session and the previous version of the asset.</param>
        /// <returns>If successful, returns an instance of AssetAuthoringSession with details about the created session. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AssetAuthoringSession, HaloApiErrorContainer>> HIUGCStartSessionAgnostic(string title, string assetType, string assetId, bool includeContainerSas, AuthoringSessionStarter starter)
        {
            return await this.ExecuteAPIRequest<AssetAuthoringSession>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}/sessions?include-container-sas={includeContainerSas}",
                HttpMethod.Post,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT,
                JsonSerializer.Serialize(starter));
        }

        /// <summary>
        /// Extends an existing authoring session.
        /// </summary>
        /// <remarks>
        /// For now, an empty JSON is passed to the PATCH request. In the future, analysis needs to be done to understand more about how the request actually
        /// can be used to modify the data, since that's what a PATCH is usually about.
        /// </remarks>
        /// <include file='../APIDocsExamples/HIUGC_ExtendSessionAgnostic.xml' path='//example'/>
        /// <param name="title">Title for the game for which the authoring session needs to be spawned. Example variant is "hi" for "Halo Infinite".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique asset ID for the asset type specified earlier.</param>
        /// <param name="includeContainerSas">Determines whether to include the container SAS in the response or not. Setting this value to "true" will result in a 403 Forbidden error.</param>
        /// <returns>If successful, returns an instance of AssetAuthoringSession with details about the created session. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<AssetAuthoringSession, HaloApiErrorContainer>> HIUGCExtendSessionAgnostic(string title, string assetType, string assetId, bool includeContainerSas)
        {
            return await this.ExecuteAPIRequest<AssetAuthoringSession>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}/sessions?include-container-sas={includeContainerSas}",
                HttpMethod.Patch,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT,
                "{}");
        }

        /// <summary>
        /// Deletes an existing authoring session.
        /// </summary>
        /// <param name="title">Title for the game for which the authoring session needs to be spawned. Example variant is "hi" for "Halo Infinite".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique asset ID for the asset type specified earlier.</param>
        /// <returns>If the request to delete the session is successful, returns true. Otherwise, returns false.</returns>
        public async Task<HaloApiResultContainer<bool, HaloApiErrorContainer>> HIUGCDeleteSessionAgnostic(string title, string assetType, string assetId)
        {
            return await this.ExecuteAPIRequest<bool>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}/sessions",
                HttpMethod.Delete,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Undeletes a previously deleted asset.
        /// </summary>
        /// <remarks>
        /// Interestingly enough, the API itself, as seen in the settings endpoint, does not contain the `/recover` suffix. I had to add it manually
        /// in this specific implementation.
        /// </remarks>
        /// <param name="title">Title for the game for which the authoring session needs to be spawned. Example variant is "hi" for "Halo Infinite".</param>
        /// <param name="assetType">Type of asset to check. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique asset ID for the asset type specified earlier.</param>
        /// <returns>If the request to undelete an asset was successful, returns true. Otherwise, returns false.</returns>
        public async Task<HaloApiResultContainer<bool, HaloApiErrorContainer>> HIUGCUndeleteAsset(string title, string assetType, string assetId)
        {
            return await this.ExecuteAPIRequest<bool>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}/recover",
                HttpMethod.Post,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Undeletes a previously deleted asset version.
        /// </summary>
        /// <param name="title">Title for the game for which the authoring session needs to be spawned. Example variant is "hi" for "Halo Infinite".</param>
        /// <param name="assetType">Type of asset to unpublish. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique asset ID for the asset type specified earlier.</param>
        /// <param name="versionId">Unique ID for the asset version to be undeleted.</param>
        /// <returns>If successful, returns true. Otherwise, returns false.</returns>
        public async Task<HaloApiResultContainer<bool, HaloApiErrorContainer>> HIUGCUndeleteVersion(string title, string assetType, string assetId, string versionId)
        {
            return await this.ExecuteAPIRequest<bool>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/{title}/{assetType}/{assetId}/versions/{versionId}/recover",
                HttpMethod.Post,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Unpublishes a previously published asset.
        /// </summary>
        /// <param name="assetType">Type of asset to unpublish. Example value is "UgcGameVariants".</param>
        /// <param name="assetId">Unique asset ID for the asset type specified earlier.</param>
        /// <returns>If successful, returns true. Otherwise, returns false.</returns>
        public async Task<HaloApiResultContainer<bool, HaloApiErrorContainer>> HIUGCUnpublishAsset(string assetType, string assetId)
        {
            return await this.ExecuteAPIRequest<bool>(
                $"https://{HaloCoreEndpoints.AuthoringOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/{assetType}/{assetId}/unpublish",
                HttpMethod.Post,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        // ================================================
        // HIUGCDiscovery
        // ================================================

        /// <summary>
        /// Returns metadata about a given engine game variant version.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetEngineGameVariant.xml' path='//example'/>
        /// <param name="assetId">Unique asset ID for the engine game variant.</param>
        /// <param name="versionId">Unique ID for the asset version for the engine game variant.</param>
        /// <returns>If successful, returns an instance of EngineGameVariant containing appropriate metadata. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<EngineGameVariant, HaloApiErrorContainer>> HIUGCDiscoveryGetEngineGameVariant(string assetId, string versionId)
        {
            return await this.ExecuteAPIRequest<EngineGameVariant>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/engineGameVariants/{assetId}/versions/{versionId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets an engine game variant without an associated version.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetEngineGameVariantWithoutVersion.xml' path='//example'/>
        /// <param name="assetId">Unique asset ID for the engine game variant.</param>
        /// <returns>If successful, returns an instance of EngineGameVariant containing appropriate metadata. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<EngineGameVariant, HaloApiErrorContainer>> HIUGCDiscoveryGetEngineGameVariantWithoutVersion(string assetId)
        {
            return await this.ExecuteAPIRequest<EngineGameVariant>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/engineGameVariants/{assetId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets a game manifest.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetManifest.xml' path='//example'/>
        /// <param name="assetId">Unique asset ID for the manifest. Example value is "6369c3a6-390e-496c-ab71-93c326347327".</param>
        /// <param name="versionId">Unique version ID for the manifest. Example value is "9a348b5b-08aa-41c2-8b3a-681870c78a76".</param>
        /// <param name="clearanceId">ID of the currently active flight.</param>
        /// <returns>If successful, an instance of <see cref="Manifest"/> representing the asset details. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<Manifest, HaloApiErrorContainer>> HIUGCDiscoveryGetManifest(string assetId, string versionId, string clearanceId)
        {
            return await this.ExecuteAPIRequest<Manifest>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/manifests/{assetId}/versions/{versionId}?clearanceId={clearanceId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the current game manifest.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetManifestByBuild.xml' path='//example'/>
        /// <param name="buildNumber">Build for which the manifest needs to be obtained. Maps to official Halo builds, such as 6.10022.10499.</param>
        /// <returns>An instance of Manifest containing game manifest information if request is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<Manifest, HaloApiErrorContainer>> HIUGCDiscoveryGetManifestByBuild(string buildNumber)
        {
            return await this.ExecuteAPIRequest<Manifest>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/manifests/builds/{buildNumber}/game",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns information about a given map at a specific release version.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetMap.xml' path='//example'/>
        /// <param name="assetId">Unique map ID. For example, the ID for the Recharge map is "8420410b-044d-44d7-80b6-98a766c8c39f".</param>
        /// <param name="versionId">Unique version ID for a map. For example, for the Recharge map a version is "068c0974-f748-41ba-b457-b8fed603576e".</param>
        /// <returns>An instance of Map containing map metadata if request is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<Map, HaloApiErrorContainer>> HIUGCDiscoveryGetMap(string assetId, string versionId)
        {
            return await this.ExecuteAPIRequest<Map>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/maps/{assetId}/versions/{versionId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns information about a given map and mode combination. For example, the Breaker map can be used in Big Team Battle (BTB).
        /// </summary>
        /// <remarks>
        /// An example fully constructed HTTP request to the API is: https://{HaloCoreEndpoints.DiscoveryOrigin}.svc.halowaypoint.com/hi/mapModePairs/9e056bcc-b9bc-4845-9fe3-6d667f018463/versions/37b8cd75-d1ce-4abf-9349-a76673503410.
        /// This request represents the BTB game mode on the Breaker map.
        /// </remarks>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetMapModePair.xml' path='//example'/>
        /// <param name="assetId">Unique ID for the map and mode combination.</param>
        /// <param name="versionId">Unique version ID for the map and mode combination.</param>
        /// <param name="clearanceId">ID of the currently active flight.</param>
        /// <returns>An instance of Map containing map metadata if request is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<MapModePair, HaloApiErrorContainer>> HIUGCDiscoveryGetMapModePair(string assetId, string versionId, string clearanceId)
        {
            return await this.ExecuteAPIRequest<MapModePair>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/mapModePairs/{assetId}/versions/{versionId}?clearanceId={clearanceId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets a map and mode combination without the version.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetMapModePairWithoutVersion.xml' path='//example'/>
        /// <param name="assetId">Unique ID for the map and mode combination. Example value is "b6aca0c7-8ba7-4066-bf91-693571374c3c" for "sgh_interlock".</param>
        /// <returns>If successful, returns an instance of <see cref="Task"/> representing the map and mode combination. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<MapModePair, HaloApiErrorContainer>> HIUGCDiscoveryGetMapModePairWithoutVersion(string assetId)
        {
            return await this.ExecuteAPIRequest<MapModePair>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/mapModePairs/{assetId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }


        /// <summary>
        /// Gets information about a given map.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetMapWithoutVersion.xml' path='//example'/>
        /// <param name="assetId">Unique map ID. For example, the ID for the Recharge map is "8420410b-044d-44d7-80b6-98a766c8c39f".</param>
        /// <returns>An instance of Map containing map metadata if request is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<Map, HaloApiErrorContainer>> HIUGCDiscoveryGetMapWithoutVersion(string assetId)
        {
            return await this.ExecuteAPIRequest<Map>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/maps/{assetId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about a specific playlist.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetPlaylist.xml' path='//example'/>
        /// <param name="assetId">Unique asset ID for the playlist.</param>
        /// <param name="versionId">Unique version ID for the playlist.</param>
        /// <param name="clearanceId">ID of the currently active flight.</param>
        /// <returns>If successful, returns an instance of Playlist containing playlist information. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<Playlist, HaloApiErrorContainer>> HIUGCDiscoveryGetPlaylist(string assetId, string versionId, string clearanceId)
        {
            return await this.ExecuteAPIRequest<Playlist>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/playlists/{assetId}/versions/{versionId}?clearanceId={clearanceId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information about a specific playlist without its version.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetPlaylistWithoutVersion.xml' path='//example'/>
        /// <param name="assetId">Unique asset ID for the playlist.</param>
        /// <returns>If successful, returns an instance of <see cref="Playlist"/> representing the targeted playlist. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<Playlist, HaloApiErrorContainer>> HIUGCDiscoveryGetPlaylistWithoutVersion(string assetId)
        {
            return await this.ExecuteAPIRequest<Playlist>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/playlists/{assetId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information abouty a specific prefab version.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetPrefab.xml' path='//example'/>
        /// <param name="assetId">Unique asset ID for the prefab.</param>
        /// <param name="versionId">Unique version ID for the prefab.</param>
        /// <returns>If successful, returns a <see cref="Prefab"/> instance representing the specific prefab. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<Prefab, HaloApiErrorContainer>> HIUGCDiscoveryGetPrefab(string assetId, string versionId)
        {
            return await this.ExecuteAPIRequest<Prefab>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/prefabs/{assetId}/versions/{versionId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets information abouty a specific prefab version.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetPrefabWithoutVersion.xml' path='//example'/>
        /// <param name="assetId">Unique asset ID for the prefab.</param>
        /// <returns>If successful, returns a <see cref="Prefab"/> instance representing the specific prefab. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<Prefab, HaloApiErrorContainer>> HIUGCDiscoveryGetPrefabWithoutVersion(string assetId)
        {
            return await this.ExecuteAPIRequest<Prefab>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/prefabs/{assetId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns the project details that are associated with a given version of a manifest. This manifest contains all the maps and modes to show in the custom game menus.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetProject.xml' path='//example'/>
        /// <param name="assetId">Unique asset ID representing the project. Example asset ID currently active is the custom game manifest ID: "a9dc0785-2a99-4fec-ba6e-0216feaaf041".</param>
        /// <param name="versionId">Version ID for the project. As an example, a version of a production manifest is "a4e68648-f994-44bb-853e-d09ee224d799".</param>
        /// <returns>An instance of Project containing current game project information if request is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<Project, HaloApiErrorContainer>> HIUGCDiscoveryGetProject(string assetId, string versionId)
        {
            return await this.ExecuteAPIRequest<Project>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/projects/{assetId}/versions/{versionId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns information on a project (collection of game modes and maps). This manifest contains all the maps and modes to show in the custom game menus.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetProjectWithoutVersion.xml' path='//example'/>
        /// <param name="assetId">Unique asset ID representing the project. Example asset ID currently active is the custom game manifest ID: "a9dc0785-2a99-4fec-ba6e-0216feaaf041".</param>
        /// <returns>An instance of Project containing current game project information if request is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<Project, HaloApiErrorContainer>> HIUGCDiscoveryGetProjectWithoutVersion(string assetId)
        {
            return await this.ExecuteAPIRequest<Project>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/projects/{assetId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns information about available tags that can be associated with game assets.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetTagsInfo.xml' path='//example'/>
        /// <returns>An instance of TagInfo containing a list of tags if the request is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<TagInfo, HaloApiErrorContainer>> HIUGCDiscoveryGetTagsInfo()
        {
            return await this.ExecuteAPIRequest<TagInfo>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/info/tags",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns information about a game asset version. This information is specific only to the version specified and does not contain general asset metadata. To get general asset metadata, use HIUGCDiscoveryGetUgcGameVariantWithoutVersion.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetUgcGameVariant.xml' path='//example'/>
        /// <param name="assetId">Unique ID for the game asset. For example, for "Fiesta - Slayer" game mode, the asset ID is "aca7bbf8-7a18-4aae-8785-1bd3f58275fd".</param>
        /// <param name="versionId">Version for the asset to obtain. Example value is "3685f6b2-2860-4e98-9d13-513087edb465".</param>
        /// <returns>An instance of UGCGameVariant containing game variant metadata if the request is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<UGCGameVariant, HaloApiErrorContainer>> HIUGCDiscoveryGetUgcGameVariant(string assetId, string versionId)
        {
            return await this.ExecuteAPIRequest<UGCGameVariant>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/ugcGameVariants/{assetId}/versions/{versionId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns general asset metadata related to a game asset.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_GetUgcGameVariantWithoutVersion.xml' path='//example'/>
        /// <param name="assetId">Unique ID for the game asset. For example, for "Fiesta - Slayer" game mode, the asset ID is "aca7bbf8-7a18-4aae-8785-1bd3f58275fd".</param>
        /// <returns>An instance of GameAssetVariant containing asset metadata if the request is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<UGCGameVariant, HaloApiErrorContainer>> HIUGCDiscoveryGetUgcGameVariantWithoutVersion(string assetId)
        {
            return await this.ExecuteAPIRequest<UGCGameVariant>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/ugcGameVariants/{assetId}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Searches for assets in the user generated content directory.
        /// </summary>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_Search.xml' path='//example'/>
        /// <param name="start">Number of results from which to start the iteration.</param>
        /// <param name="count">Count of results to return.</param>
        /// <param name="includeTimes">Include creation, modification, and deletion times in results.</param>
        /// <param name="sort">Property by which to sort the results. Example is "PlaysRecent".</param>
        /// <param name="order">Determines whether results are ordered in descending or ascending order.</param>
        /// <param name="assetKind">Type of asset to be searched.</param>
        /// <returns>If successful, returns an instance of SearchResultsContainer container assets. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<SearchResultsContainer, HaloApiErrorContainer>> HIUGCDiscoverySearch(int start, int count, bool includeTimes, string sort, ResultOrder order, AssetKind assetKind)
        {
            return await this.ExecuteAPIRequest<SearchResultsContainer>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/search?start={start}&count={count}&include-times={includeTimes}&sort={sort}&order={order}&assetKind={assetKind}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Returns information about available film chunks that are used to reconstruct the entire match.
        /// </summary>
        /// <remarks>Despite the name of this request, the data captured here is not actually a movie but rather a full re-creation of the match, using in-game assets and player positions.</remarks>
        /// <include file='../APIDocsExamples/HIUGC_Discovery_SpectateByMatchId.xml' path='//example'/>
        /// <param name="matchId">Unique ID for the match.</param>
        /// <returns>An instance of Film containing film metadata if the request is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<Film, HaloApiErrorContainer>> HIUGCDiscoverySpectateByMatchId(string matchId)
        {
            return await this.ExecuteAPIRequest<Film>(
                $"https://{HaloCoreEndpoints.DiscoveryOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/films/matches/{matchId}/spectate",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        // ================================================
        // Lobby
        // ================================================

        /// <summary>
        /// Gets a list of available lobby servers.
        /// </summary>
        /// <include file='../APIDocsExamples/Lobby_GetQosServers.xml' path='//example'/>
        /// <returns>A list of Server instances if the request is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<List<Server>, HaloApiErrorContainer>> LobbyGetQosServers()
        {
            return await this.ExecuteAPIRequest<List<Server>>(
                $"https://{HaloCoreEndpoints.HaloInfiniteLobbyOrigin}.{HaloCoreEndpoints.ServiceDomain}/titles/hi/qosservers",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the player presence status.
        /// </summary>
        /// <include file='../APIDocsExamples/Lobby_Presence.xml' path='//example'/>
        /// <param name="presenceRequest">Presence request, containing a list of Xuids representing Xbox Live players.</param>
        /// <returns>If successful, an instance of <see cref="LobbyPresenceContainer"/> representing the lobby details. Otherwise, null.</returns>
        public async Task<HaloApiResultContainer<LobbyPresenceContainer, HaloApiErrorContainer>> LobbyPresence(LobbyPresenceRequestContainer presenceRequest)
        {
            if (presenceRequest is null)
            {
                throw new ArgumentNullException(nameof(presenceRequest));
            }

            return await this.ExecuteAPIRequest<LobbyPresenceContainer>(
                $"https://{HaloCoreEndpoints.HaloInfiniteLobbyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/presence",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets a third-party join handle for a lobby.
        /// </summary>
        /// <include file='../APIDocsExamples/Lobby_ThirdPartyJoinHandle.xml' path='//example'/>
        /// <param name="lobbyId">Unique lobby ID.</param>
        /// <param name="player">Player ID in the format of "xuid(XUID_VALUE)".</param>
        /// <param name="handleAudience">Audience for the join handle. Example value is "Friends".</param>
        /// <param name="handlePlatform">Platform for the join handle. Example value is "Discord".</param>
        /// <returns>An instance of LobbyJoinHandle if the request is successful. Otherwise, returns null.</returns>
        /// <remarks>It seems that this request requires a more "broad access" Spartan token that is generated by the game, and is not open to third-party apps. Additional investigation is required.</remarks>
        public async Task<HaloApiResultContainer<LobbyJoinHandle, HaloApiErrorContainer>> LobbyThirdPartyJoinHandle(string lobbyId, string player, string handleAudience, string handlePlatform)
        {
            return await this.ExecuteAPIRequest<LobbyJoinHandle>(
                $"https://{HaloCoreEndpoints.HaloInfiniteLobbyOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/lobbies/{lobbyId}/players/{player}/thirdPartyJoinHandle?audience={handleAudience}&platform={handlePlatform}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        // ================================================
        // Setting
        // ================================================

        /// <summary>
        /// Get a list of features enables for a given flight.
        /// </summary>
        /// <include file='../APIDocsExamples/Setting_GetFlightedFeatureFlags.xml' path='//example'/>
        /// <param name="flightId">Clearance ID/flight that is being used.</param>
        /// <returns>An instance of FlightedFeatureFlags containing a list of enabled and disabled features if the request is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<FlightedFeatureFlags, HaloApiErrorContainer>> SettingGetFlightedFeatureFlags(string flightId)
        {
            return await this.ExecuteAPIRequest<FlightedFeatureFlags>(
                $"https://{HaloCoreEndpoints.SettingsOrigin}.{HaloCoreEndpoints.ServiceDomain}/featureflags/hi?flight={flightId}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_PC_USER_AGENT);
        }

        // ================================================
        // Settings
        // ================================================

        /// <summary>
        /// Gets the currently assigned clearance/flight ID.
        /// </summary>
        /// <include file='../APIDocsExamples/Settings_GetClearance.xml' path='//example'/>
        /// <param name="audience">Audience that the request is targeting. Standard value is RETAIL.</param>
        /// <param name="sandbox">Identifier associated with the sandbox. Typical value is UNUSED.</param>
        /// <param name="buildNumber">Number of the game build the data is requested for. Example value is 211755.22.01.23.0549-0.</param>
        /// <returns>An instance of PlayerClearance if the request is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<PlayerClearance, HaloApiErrorContainer>> SettingsGetClearance(string audience, string sandbox, string buildNumber)
        {
            return await this.ExecuteAPIRequest<PlayerClearance>(
                $"https://{HaloCoreEndpoints.SettingsOrigin}.{HaloCoreEndpoints.ServiceDomain}/oban/flight-configurations/titles/hi/audiences/{audience}/active?sandbox={sandbox}&build={buildNumber}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_PC_USER_AGENT);
        }

        /// <summary>
        /// Gets the the player clearance/flight ID.
        /// </summary>
        /// <include file='../APIDocsExamples/Settings_GetPlayerClearance.xml' path='//example'/>
        /// <param name="audience">Audience that the request is targeting. Standard value is RETAIL.</param>
        /// <param name="player">The player identifier in the format "xuid(000000)".</param>
        /// <param name="sandbox">Identifier associated with the sandbox. Typical value is UNUSED.</param>
        /// <param name="buildNumber">Number of the game build the data is requested for. Example value is 211755.22.01.23.0549-0.</param>
        /// <returns>An instance of PlayerClearance if the request is successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<PlayerClearance, HaloApiErrorContainer>> SettingsGetPlayerClearance(string audience, string player, string sandbox, string buildNumber)
        {
            return await this.ExecuteAPIRequest<PlayerClearance>(
                $"https://{HaloCoreEndpoints.SettingsOrigin}.{HaloCoreEndpoints.ServiceDomain}/oban/flight-configurations/titles/hi/audiences/{audience}/players/{player}/active?sandbox={sandbox}&build={buildNumber}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        // ================================================
        // Skill
        // ================================================

        /// <summary>
        /// Returns individual player stats for a given match.
        /// </summary>
        /// <include file='../APIDocsExamples/Skill_GetMatchPlayerResult.xml' path='//example'/>
        /// <param name="matchId">The unique match ID.</param>
        /// <param name="playerIds">Array of player IDs. Each ID string should be in the format of "xuid(XUID_VALUE)".</param>
        /// <returns>An instance of <see cref="PlayerSkillResultContainer"/> representing player skills if the request was successful. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<PlayerSkillResultContainer, HaloApiErrorContainer>> SkillGetMatchPlayerResult(string matchId, List<string> playerIds)
        {
            var formattedPlayerList = string.Join(",", playerIds);
            return await this.ExecuteAPIRequest<PlayerSkillResultContainer>(
                $"https://{HaloCoreEndpoints.SkillOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/matches/{matchId}/skill?players={formattedPlayerList}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_PC_USER_AGENT);
        }

        /// <summary>
        /// Gets playlist Competitive Skill Rank (CSR) for a player or a set of players.
        /// </summary>
        /// <include file='../APIDocsExamples/Skill_GetPlaylistCsr.xml' path='//example'/>
        /// <param name="playlistId">Unique ID for the playlist.</param>
        /// <param name="playerIds">Array of player IDs. Each ID string should be in the format of "xuid(XUID_VALUE)".</param>
        /// <returns>If successful, an instance of <see cref="PlaylistCsrResultContainer"/> representing player CSRs. Otherwise, returns null.</returns>
        public async Task<HaloApiResultContainer<PlaylistCsrResultContainer, HaloApiErrorContainer>> SkillGetPlaylistCsr(string playlistId, List<string> playerIds)
        {
            var formattedPlayerList = string.Join(",", playerIds);
            return await this.ExecuteAPIRequest<PlaylistCsrResultContainer>(
                $"https://{HaloCoreEndpoints.SkillOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/playlist/{playlistId}/csrs?players={formattedPlayerList}",
                HttpMethod.Get,
                true,
                true,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        // ================================================
        // Stats
        // ================================================

        /// <summary>
        /// Gets the summary information for applicable bans to players and devices.
        /// </summary>
        /// <include file='../APIDocsExamples/Stats_BanSummary.xml' path='//example'/>
        /// <param name="targetlist">A list of targets that need to be checked. Authenticated devices can be included as "Authenticated(Device)". Individual players can be specified as "xuid(XUID_VALUE)".</param>
        /// <returns>An instance of BanSummary containing applicable ban information if request was successful. Return value is null otherwise.</returns>
        /// <remarks>In some quick tests, it seems that including Authenticated(Device) in the request results in 401 Unauthorized if called outside the game. Additional work might be required to understand how to validate the device.</remarks>
        public async Task<HaloApiResultContainer<BanSummary, HaloApiErrorContainer>> StatsBanSummary(List<string> targetlist)
        {
            var formattedTargetList = string.Join(",", targetlist);
            return await this.ExecuteAPIRequest<BanSummary>(
                $"https://{HaloCoreEndpoints.BanProcessorOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/bansummary?auth=st&targets={formattedTargetList}",
                HttpMethod.Get,
                false,
                false,
                GlobalConstants.HALO_PC_USER_AGENT);
        }

        /// <summary>
        /// Gets challenge decks that are available for a player.
        /// </summary>
        /// <include file='../APIDocsExamples/Stats_GetChallengeDecks.xml' path='//example'/>
        /// <param name="player">The player identifier in the format "xuid(000000)"</param>
        /// <returns>An instance of PlayerDecks containing deck information if request was successful. Return value is null otherwise.</returns>
        public async Task<HaloApiResultContainer<PlayerDecks, HaloApiErrorContainer>> StatsGetChallengeDecks(string player)
        {
            return await this.ExecuteAPIRequest<PlayerDecks>(
                $"https://{HaloCoreEndpoints.StatsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/decks",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets the summary on number of played matches.
        /// </summary>
        /// <include file='../APIDocsExamples/Stats_GetMatchCount.xml' path='//example'/>
        /// <param name="player">The player identifier in the format "xuid(000000)"</param>
        /// <returns>An instance of PlayerMatchCount containing match counts if request was successful. Return value is null otherwise.</returns>
        public async Task<HaloApiResultContainer<PlayerMatchCount, HaloApiErrorContainer>> StatsGetMatchCount(string player)
        {
            return await this.ExecuteAPIRequest<PlayerMatchCount>(
                $"https://{HaloCoreEndpoints.StatsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/matches/count",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets match history for a player.
        /// </summary>
        /// <include file='../APIDocsExamples/Stats_GetMatchHistory.xml' path='//example'/>
        /// <param name="player">The player identifier in the format "xuid(000000)"</param>
        /// <param name="start">Start value for the counter, from which data should be returned.</param>
        /// <param name="count">Number of matches to return. Maximum is 25. Going beyond 25 will result in only 25 values being returned.</param>
        /// <param name="type">Type of matches to query.</param>
        /// <returns>An instance of MatchContainer containing match metadata if request was successful. Return value is null otherwise.</returns>
        public async Task<HaloApiResultContainer<MatchHistoryResponse, HaloApiErrorContainer>> StatsGetMatchHistory(string player, int start, int count, Models.HaloInfinite.MatchType type)
        {
            return await this.ExecuteAPIRequest<MatchHistoryResponse>(
                $"https://{HaloCoreEndpoints.StatsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/matches?start={start}&count={count}&type={type}",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets stats for a specific match.
        /// </summary>
        /// <include file='../APIDocsExamples/Stats_GetMatchStats.xml' path='//example'/>
        /// <param name="matchId">Match ID in GUID format.</param>
        /// <returns>An instance of MatchStats containing match metadata if request was successful. Return value is null otherwise.</returns>
        public async Task<HaloApiResultContainer<MatchStats, HaloApiErrorContainer>> StatsGetMatchStats(string matchId)
        {
            return await this.ExecuteAPIRequest<MatchStats>(
                $"https://{HaloCoreEndpoints.StatsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/matches/{matchId}/stats",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_PC_USER_AGENT);
        }

        /// <summary>
        /// Get challenge progression associated with a given match.
        /// </summary>
        /// <include file='../APIDocsExamples/Stats_GetPlayerMatchProgression.xml' path='//example'/>
        /// <param name="player">The player identifier in the format "xuid(000000)"</param>
        /// <param name="matchId">Match ID in GUID format.</param>
        /// <returns>An instance of MatchProgression containing match challenge progression metadata if request was successful. Return value is null otherwise.</returns>
        public async Task<HaloApiResultContainer<MatchProgression, HaloApiErrorContainer>> StatsGetPlayerMatchProgression(string player, string matchId)
        {
            return await this.ExecuteAPIRequest<MatchProgression>(
                $"https://{HaloCoreEndpoints.StatsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/matches/{matchId}/progression",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        /// <summary>
        /// Gets match privacy settings for a given player.
        /// </summary>
        /// <include file='../APIDocsExamples/Stats_MatchPrivacy.xml' path='//example'/>
        /// <param name="player">The player identifier in the format "xuid(000000)"</param>
        /// <returns>An instance of MatchesPrivacy containing match privacy metadata if request was successful. Return value is null otherwise.</returns>
        public async Task<HaloApiResultContainer<MatchesPrivacy, HaloApiErrorContainer>?> StatsMatchPrivacy(string player)
        {
            return await this.ExecuteAPIRequest<MatchesPrivacy>(
                $"https://{HaloCoreEndpoints.StatsOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/players/{player}/matches-privacy",
                HttpMethod.Get,
                true,
                false,
                GlobalConstants.HALO_WAYPOINT_USER_AGENT);
        }

        // ================================================
        // TextModeration
        // ================================================

        /// <summary>
        /// Gets a specific moderation proof signing key.
        /// </summary>
        /// <include file='../APIDocsExamples/TextModeration_GetSigningKey.xml' path='//example'/>
        /// <param name="keyId">Key ID. Full list can be obtained by a call to TextModerationGetSigningKeys.</param>
        /// <returns>An instance of Key containing a single signing key data if request was successful. Return value is null otherwise.</returns>
        public async Task<HaloApiResultContainer<Key, HaloApiErrorContainer>> TextModerationGetSigningKey(string keyId)
        {
            return await this.ExecuteAPIRequest<Key>(
                $"https://{HaloCoreEndpoints.TextOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/moderation-proof-keys/{keyId}",
                HttpMethod.Get,
                false,
                false,
                GlobalConstants.HALO_PC_USER_AGENT);
        }

        /// <summary>
        /// Gets a list of available moderation proof signing keys.
        /// </summary>
        /// <include file='../APIDocsExamples/TextModeration_GetSigningKeys.xml' path='//example'/>
        /// <returns>An instance of ModerationProofKeys containing signing key data if request was successful. Return value is null otherwise.</returns>
        public async Task<HaloApiResultContainer<ModerationProofKeys, HaloApiErrorContainer>> TextModerationGetSigningKeys()
        {
            return await this.ExecuteAPIRequest<ModerationProofKeys>(
                $"https://{HaloCoreEndpoints.TextOrigin}.{HaloCoreEndpoints.ServiceDomain}/hi/moderation-proof-keys",
                HttpMethod.Get,
                false,
                false,
                GlobalConstants.HALO_PC_USER_AGENT);
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
        /// <param name="contentType">Content type for POST requests. By default it's `application/json`.</param>
        /// <returns>Response string in case of a successful request. Null if request failed.</returns>
        private async Task<HaloApiResultContainer<T, HaloApiErrorContainer>> ExecuteAPIRequest<T>(string endpoint, HttpMethod method, bool useSpartanToken, bool useClearance, string userAgent, string content = "", ApiContentType contentType = ApiContentType.Json)
        {
            var client = new HttpClient(new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli,
            });

            HaloApiResultContainer<T, HaloApiErrorContainer> resultContainer = new(default, new HaloApiErrorContainer());

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(endpoint),
                Method = method,
            };

            if (request.Method == HttpMethod.Post)
            {
                var contentTypeAttribute = contentType.GetHeaderValue();
                request.Headers.Add("Content-Type", contentTypeAttribute);
            }

            if (!string.IsNullOrEmpty(content))
            {
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            }

            if (useSpartanToken)
            {
                request.Headers.Add("x-343-authorization-spartan", this.SpartanToken);
            }

            if (useClearance)
            {
                request.Headers.Add("343-clearance", this.ClearanceToken);
            }

            request.Headers.Add("User-Agent", userAgent);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");

            var response = await client.SendAsync(request);

            resultContainer.Error.Code = Convert.ToInt32(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                if (typeof(T) == typeof(string))
                {
                    resultContainer.Result = (T)Convert.ChangeType(await response.Content.ReadAsStringAsync(), typeof(T));
                }
                else if (typeof(T) == typeof(byte[]))
                {
                    using (MemoryStream dataStream = new())
                    {
                        response.Content.ReadAsStreamAsync().Result.CopyTo(dataStream);
                        resultContainer.Result = (T)Convert.ChangeType(dataStream.ToArray(), typeof(T));
                    }
                }
                else if (typeof(T) == typeof(bool))
                {
                    resultContainer.Result = (T)(object)response.IsSuccessStatusCode;
                }
                else
                {
                    if (Attribute.GetCustomAttribute(typeof(T), typeof(IsAutomaticallySerializableAttribute)) != null)
                    {
                        resultContainer.Result = JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), this.serializerOptions);
                    }
                    else
                    {
                        throw new NotSupportedException("The specified type is not supported. You can onlty get results in string or byte array formats.");
                    }
                }
            }

            if (response.Content != null)
            {
                resultContainer.Error.Message = await response.Content.ReadAsStringAsync();
            }

            return resultContainer;
        }
    }
}
