// <copyright file="XboxEndpoints.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace Grunt.Endpoints
{
    internal class XboxEndpoints
    {
        internal static readonly string XboxLiveAuthorize = "https://login.live.com/oauth20_authorize.srf";
        internal static readonly string XboxLiveToken = "https://login.live.com/oauth20_token.srf";
        internal static readonly string XboxLiveAuthRelyingParty = "http://auth.xboxlive.com";
        internal static readonly string XboxLiveUserAuthenticate = "https://user.auth.xboxlive.com/user/authenticate";
        internal static readonly string XboxLiveRelyingParty = "http://xboxlive.com";
        internal static readonly string XboxLiveXstsAuthorize = "https://xsts.auth.xboxlive.com/xsts/authorize";
    }
}
