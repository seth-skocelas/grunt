namespace Grunt.Models.HaloInfinite.Foundation
{
    public abstract class AuthoringResultContainer
    {
        public int EstimatedTotal { get; set; }
        public int Start { get; set; }
        public int Count { get; set; }
        public int ResultCount { get; set; }
        //TODO: Figure out what the object here is.
        public object Links { get; set; }
    }
}
