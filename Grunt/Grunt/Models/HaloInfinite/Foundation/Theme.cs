namespace Grunt.Models.HaloInfinite.Foundation
{
    public abstract class Theme
    {
        public APIFormattedDate? FirstModifiedDateUtc { get; set; }
        public APIFormattedDate? LastModifiedDateUtc { get; set; }
        public bool IsEquipped { get; set; }
        public bool IsDefault { get; set; }
        public string ThemePath { get; set; }
    }
}
