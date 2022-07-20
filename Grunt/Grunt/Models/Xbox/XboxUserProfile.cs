using System.Collections.Generic;

namespace Grunt.Models.Xbox
{
    public class XboxUserProfile
    {
        public string Id { get; set; }
        public string HostId { get; set; }
        public List<XboxSetting> Settings { get; set; }
        public bool IsSponsoredUser { get; set; }
    }

}
