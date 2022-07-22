namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class MarketplaceRecord
    {
        public string MarketplaceSource { get; set; }
        public APIFormattedDate ProductsLastCheckedDate { get; set; }
        public APIFormattedDate WorkflowEntitiesLastCreatedDate { get; set; }
        public APIFormattedDate ProductsLastConsumedDate { get; set; }
    }

}
