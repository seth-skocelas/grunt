namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class TransactionSnapshot
    {
        public Transaction[] Transactions { get; set; }
        public string ContinuationToken { get; set; }
        public MarketplaceRecord[] MarketplaceLastSuccessfulDates { get; set; }
    }
}
