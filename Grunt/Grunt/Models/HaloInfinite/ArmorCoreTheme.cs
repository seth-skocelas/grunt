namespace Grunt.Models.HaloInfinite
{
    public class ArmoreCoreTheme
    {
        public SpartanDate FirstModifiedDateUtc { get; set; }
        public SpartanDate LastModifiedDateUtc { get; set; }
        public bool IsEquipped { get; set; }
        public bool IsDefault { get; set; }
        public string ThemePath { get; set; }
        public string CoatingPath { get; set; }
        public string GlovePath { get; set; }
        public string HelmetPath { get; set; }
        public string HelmetAttachmentPath { get; set; }
        public string ChestAttachmentPath { get; set; }
        public string KneePadPath { get; set; }
        public string LeftShoulderPadPath { get; set; }
        public string RightShoulderPadPath { get; set; }
        public Emblem[] Emblems { get; set; }
        public string ArmorFxPath { get; set; }
        public string MythicFxPath { get; set; }
        public string VisorPath { get; set; }
        public string HipAttachmentPath { get; set; }
        public string WristAttachmentPath { get; set; }
    }
}
