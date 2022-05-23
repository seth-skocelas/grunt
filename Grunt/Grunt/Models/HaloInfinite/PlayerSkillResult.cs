using Newtonsoft.Json;

namespace Grunt.Models.HaloInfinite
{
    public class PlayerSkillResult
    {
        [JsonProperty("Id")]
        public string PlayerId { get; set; }
        public int ResultCode { get; set; }
        public Result Result { get; set; }
    }
}
