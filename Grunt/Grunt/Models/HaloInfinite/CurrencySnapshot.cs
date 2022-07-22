namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class CurrencySnapshot
    {
        public CurrencyAmount[] Currencies { get; set; }
    }
}
