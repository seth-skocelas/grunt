// <copyright file="XboxEndpoints.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace Grunt.Endpoints
{
    /// <summary>
    /// Container for all Xbox Live API authentication endpoints.
    /// </summary>
    internal class XboxEndpoints
    {
        /// <summary>
        /// Endpoint for OAuth 2.0 authorization against a Microsoft account.
        /// </summary>
        internal static readonly string XboxLiveAuthorize = "https://login.live.com/oauth20_authorize.srf";

        /// <summary>
        /// Endpoint for OAuth 2.0 token acquisition for a Microsoft account.
        /// </summary>
        internal static readonly string XboxLiveToken = "https://login.live.com/oauth20_token.srf";

        /// <summary>
        /// Relying party specified in Xbox Live API authentication requests.
        /// </summary>
        internal static readonly string XboxLiveAuthRelyingParty = "http://auth.xboxlive.com";

        /// <summary>
        /// Xbox Live user authentication endpoint.
        /// </summary>
        internal static readonly string XboxLiveUserAuthenticate = "https://user.auth.xboxlive.com/user/authenticate";

        /// <summary>
        /// Relying party specified in Xbox Live API requests.
        /// </summary>
        internal static readonly string XboxLiveRelyingParty = "http://xboxlive.com";

        /// <summary>
        /// Xbox Live authorization endpoint.
        /// </summary>
        internal static readonly string XboxLiveXstsAuthorize = "https://xsts.auth.xboxlive.com/xsts/authorize";
    }
}
