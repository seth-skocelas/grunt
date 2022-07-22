namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Price
    {
        public int Cost { get; set; }
        public string CurrencyPath { get; set; }
    }

}
