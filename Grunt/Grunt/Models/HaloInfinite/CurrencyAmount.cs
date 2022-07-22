namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class CurrencyAmount
    {
        public int Amount { get; set; }
        public string CurrencyPath { get; set; }
    }
}
