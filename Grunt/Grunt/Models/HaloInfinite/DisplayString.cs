using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class DisplayString
    {
        public string Status { get; set; }
        public string Value { get; set; }
        public Dictionary<string,string> Translations { get; set; }
    }

}
