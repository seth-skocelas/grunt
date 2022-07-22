using Grunt.Models.HaloInfinite.Foundation;
using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ArmorCoreTheme : Theme
    {
        public string CoatingPath { get; set; }
        public string GlovePath { get; set; }
        public string HelmetPath { get; set; }
        public string HelmetAttachmentPath { get; set; }
        public string ChestAttachmentPath { get; set; }
        public string KneePadPath { get; set; }
        public string LeftShoulderPadPath { get; set; }
        public string RightShoulderPadPath { get; set; }
        public List<Emblem> Emblems { get; set; }
        public string ArmorFxPath { get; set; }
        public string MythicFxPath { get; set; }
        public string VisorPath { get; set; }
        public string HipAttachmentPath { get; set; }
        public string WristAttachmentPath { get; set; }
        public Emblem BigEmblem { get; set; }
    }
}
