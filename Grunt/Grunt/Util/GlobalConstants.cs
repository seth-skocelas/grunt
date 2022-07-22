// <copyright file="GlobalConstants.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Util
{
    internal class GlobalConstants
    {
        internal static readonly string HALO_WAYPOINT_USER_AGENT = "HaloWaypoint/2021112313511900 CFNetwork/1327.0.4 Darwin/21.2.0";
        internal static readonly string HALO_PC_USER_AGENT = "SHIVA-2043073184/6.10021.18539.0 (release; PC)";
        internal static readonly string[] DEFAULT_AUTH_SCOPES = new string[] { "Xboxlive.signin", "Xboxlive.offline_access" };
    }
}