namespace Grunt.Models.HaloInfinite
{
    public class ArmorCore
    {
        public string CorePath { get; set; }
        public bool IsEquipped { get; set; }
        public ArmoreCoreTheme[] Themes { get; set; }
        public string CoreId { get; set; }
        public string CoreType { get; set; }
    }
}
