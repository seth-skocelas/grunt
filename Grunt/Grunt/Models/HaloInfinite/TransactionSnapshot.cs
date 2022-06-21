namespace Grunt.Models.HaloInfinite
{

    public class TransactionSnapshot
    {
        public Transaction[] Transactions { get; set; }
        public string ContinuationToken { get; set; }
        public MarketplaceRecord[] MarketplaceLastSuccessfulDates { get; set; }
    }
}
