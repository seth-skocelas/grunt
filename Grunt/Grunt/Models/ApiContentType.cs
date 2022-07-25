// <copyright file="ApiContentType.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models
{
    /// <summary>
    /// Type of content to return for the Halo API.
    /// </summary>
    public enum ApiContentType
    {
        /// <summary>
        /// JSON data format.
        /// </summary>
        [ContentType(HeaderValue = "application/json")]
        Json,

        /// <summary>
        /// <see href="https://microsoft.github.io/bond/manual/bond_cs.html#compact-binary">Microsoft Bond Compact Binary</see> data format.
        /// </summary>
        [ContentType(HeaderValue = "application/x-bond-compact-binary")]
        BondCompactBinary,
    }
}
