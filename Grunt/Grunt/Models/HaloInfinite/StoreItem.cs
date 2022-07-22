namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class StoreItem
    {
        public string StoreId { get; set; }
        public APIFormattedDate StorefrontExpirationDate { get; set; }
        public string StorefrontDisplayPath { get; set; }
        public Offering[] Offerings { get; set; }
    }
}
