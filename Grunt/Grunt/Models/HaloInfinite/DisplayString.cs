using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class DisplayString
    {
        public string Status { get; set; }
        public string Value { get; set; }
        public Dictionary<string,string> Translations { get; set; }
    }

}
