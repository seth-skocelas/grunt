namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Currency
    {
        public string CurrencyId { get; set; }
        public DisplayString Title { get; set; }
        public DisplayString Description { get; set; }
        public string Image { get; set; }
        public string IconType { get; set; }
    }
}
