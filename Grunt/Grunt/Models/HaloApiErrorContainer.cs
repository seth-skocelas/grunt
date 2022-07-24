// <copyright file="HaloApiErrorContainer.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models
{
    /// <summary>
    /// Container class used to encapsulate any API errors.
    /// </summary>
    public class HaloApiErrorContainer
    {
        /// <summary>
        /// Gets or sets the HTTP error code produced by the API.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the error message returned by the API.
        /// </summary>
        public string? Message { get; set; }
    }
}
