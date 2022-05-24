namespace Grunt.Models.HaloInfinite
{
    public class CoreTheme
    {
        public SpartanDate FirstModifiedDateUtc { get; set; }
        public SpartanDate LastModifiedDateUtc { get; set; }
        public bool IsEquipped { get; set; }
        public bool IsDefault { get; set; }
        public string ThemePath { get; set; }
        public string ModelPath { get; set; }
        public string ColorPath { get; set; }
    }
}
