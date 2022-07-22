namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class CurrencyDefinition
    {
        public string Id { get; set; }
        public int InitialBalanceAmount { get; set; }
        public StoreProduct[] MSStoreProducts { get; set; }
        public StoreProduct[] SteamStoreProducts { get; set; }
        public MicrosoftStoreInventory MicrosoftStore { get; set; }
        public SteamStoreInventory SteamInventory { get; set; }
    }
}
