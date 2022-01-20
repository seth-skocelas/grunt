using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grunt.Models.HaloInfinite.ApiIngress
{
    public class ApiSettings
    {
        public string CELLConfig { get; set; }
        public string ClientQoSTimeoutMs { get; set; }
        public string ClearanceAudience { get; set; }
        public string GameCMS_GuideEndpoints { get; set; }
        public string HttpEvent_ExcludedStatusCodes { get; set; }
        public string HttpEvent_RequestHeaders { get; set; }
        public string HttpEvent_ResponseHeaders { get; set; }
        public string HttpEvent_UsersLoggingEnabled { get; set; }
        public string HttpEvent_UsersPercentageUpload { get; set; }
        public string PlayfabTitleId { get; set; }
        public string PurchasePollFrequencyInSeconds { get; set; }
        public string TitleIdList { get; set; }
        public string UploadFullHeapInInternalBuilds { get; set; }
        public string UploadFullHeapInReleaseBuilds { get; set; }
    }
}
