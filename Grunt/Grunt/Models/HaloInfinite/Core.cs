namespace Grunt.Models.HaloInfinite
{
    public class Core
    {
        public string CorePath { get; set; }
        public bool IsEquipped { get; set; }
        public CoreTheme[] Themes { get; set; }
        public string CoreId { get; set; }
        public string CoreType { get; set; }
        public SpartanDate FirstAcquiredDate { get; set; }
    }
}
