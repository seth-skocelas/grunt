namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class TransactionSnapshot
    {
        public Transaction[] Transactions { get; set; }
        public string ContinuationToken { get; set; }
        public MarketplaceRecord[] MarketplaceLastSuccessfulDates { get; set; }
    }
}
