namespace Grunt.Models.HaloInfinite
{
    public class CoreTheme
    {
        public APIFormattedDate FirstModifiedDateUtc { get; set; }
        public APIFormattedDate LastModifiedDateUtc { get; set; }
        public bool IsEquipped { get; set; }
        public bool IsDefault { get; set; }
        public string ThemePath { get; set; }
        public string ModelPath { get; set; }
        public string ColorPath { get; set; }
    }
}
