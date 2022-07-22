// <copyright file="ApiRetryOptions.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite.ApiIngress
{
    public class ApiRetryOptions
    {
        public int MaxRetryCount { get; set; }
        public int RetryDelayMs { get; set; }
        public float RetryGrowth { get; set; }
        public int RetryJitterMs { get; set; }
        public bool RetryIfNotFound { get; set; }
    }
}
