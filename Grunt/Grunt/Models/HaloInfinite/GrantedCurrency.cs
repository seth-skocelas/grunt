namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class GrantedCurrency
    {
        public string CurrencyPath { get; set; }
        public int Amount { get; set; }
        public string Source { get; set; }
    }

}
