// <copyright file="HaloCoreEndpoints.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace Grunt.Endpoints
{
    /// <summary>
    /// Container for Halo API endpoints.
    /// </summary>
    internal class HaloCoreEndpoints
    {
        /// <summary>
        /// Relying party for use with the Xbox Live authentication flow, associated with the Halo Waypoint service.
        /// </summary>
        internal static readonly string HaloWaypointXstsRelyingParty = "https://prod.xsts.halowaypoint.com/";

        // ====================
        // Origins
        // ====================

        /// <summary>
        /// Game CMS origin.
        /// </summary>
        internal static readonly string GameCmsOrigin = "gamecms-hacs";

        /// <summary>
        /// Economy origin.
        /// </summary>
        internal static readonly string EconomyOrigin = "economy";

        /// <summary>
        /// Authoring origin.
        /// </summary>
        internal static readonly string AuthoringOrigin = "authoring-infiniteugc";

        /// <summary>
        /// Discovery origin.
        /// </summary>
        internal static readonly string DiscoveryOrigin = "discovery-infiniteugc";

        /// <summary>
        /// Halo Infinite lobby origin.
        /// </summary>
        internal static readonly string HaloInfiniteLobbyOrigin = "lobby-hi";

        /// <summary>
        /// Settings origin.
        /// </summary>
        internal static readonly string SettingsOrigin = "settings";

        /// <summary>
        /// Skill origin.
        /// </summary>
        internal static readonly string SkillOrigin = "skill";

        /// <summary>
        /// Ban processor origin.
        /// </summary>
        internal static readonly string BanProcessorOrigin = "banprocessor";

        /// <summary>
        /// Stats origin.
        /// </summary>
        internal static readonly string StatsOrigin = "halostats";

        /// <summary>
        /// Text origin.
        /// </summary>
        internal static readonly string TextOrigin = "text";

        // ====================
        // Service domains
        // ====================

        /// <summary>
        /// Halo Waypoint service domain used for all Halo API calls.
        /// </summary>
        internal static readonly string ServiceDomain = "svc.halowaypoint.com:443";

        // ====================
        // Service endpoints
        // ====================

        /// <summary>
        /// Endpoint used to produce the Spartan token.
        /// </summary>
        internal static readonly string SpartanTokenEndpoint = "https://settings.svc.halowaypoint.com/spartan-token";

        /// <summary>
        /// Endpoint used to obtain the Halo Infinite endpoints.
        /// </summary>
        internal static readonly string HaloInfiniteEndpointsEndpoint = "https://settings.svc.halowaypoint.com/settings/hipc/e2a0a7c6-6efe-42af-9283-c2ab73250c48";
    }
}
