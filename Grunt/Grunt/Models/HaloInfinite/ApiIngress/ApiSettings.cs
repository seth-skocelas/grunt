// <copyright file="ApiSettings.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System.Text.Json.Serialization;

namespace OpenSpartan.Grunt.Models.HaloInfinite.ApiIngress
{
    public class ApiSettings
    {
        public string CELLConfig { get; set; }

        public string ClientQoSTimeoutMs { get; set; }

        public string ClearanceAudience { get; set; }

        [JsonPropertyName("GameCMS_GuideEndpoints")]
        public string GameCMSGuideEndpoints { get; set; }

        [JsonPropertyName("HttpEvent_ExcludedStatusCodes")]
        public string HttpEventExcludedStatusCodes { get; set; }

        [JsonPropertyName("HttpEvent_RequestHeaders")]
        public string HttpEventRequestHeaders { get; set; }

        [JsonPropertyName("HttpEvent_ResponseHeaders")]
        public string HttpEventResponseHeaders { get; set; }

        [JsonPropertyName("HttpEvent_UsersLoggingEnabled")]
        public string HttpEventUsersLoggingEnabled { get; set; }

        [JsonPropertyName("HttpEvent_UsersPercentageUpload")]
        public string HttpEventUsersPercentageUpload { get; set; }

        public string PlayfabTitleId { get; set; }

        public string PurchasePollFrequencyInSeconds { get; set; }

        public string TitleIdList { get; set; }

        public string UploadFullHeapInInternalBuilds { get; set; }

        public string UploadFullHeapInReleaseBuilds { get; set; }
    }
}
