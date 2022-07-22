namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class StoreProductMapping
    {
        public string ItemDef { get; set; }
        public string ProductId { get; set; }
        public string Sku { get; set; }
        public int VCQuantity { get; set; }
    }
}
