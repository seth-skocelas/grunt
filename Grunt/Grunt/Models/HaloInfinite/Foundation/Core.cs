namespace Grunt.Models.HaloInfinite.Foundation
{
    public abstract class Core
    {
        public string CorePath { get; set; }
        public bool IsEquipped { get; set; }
        public string CoreId { get; set; }
        public string CoreType { get; set; }
        public APIFormattedDate? FirstAcquiredDate { get; set; }
    }
}
