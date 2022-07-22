namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class StoreProduct
    {
        public int ItemDef { get; set; }
        public string ProductId { get; set; }
        public string Path { get; set; }
    }
}
