namespace Grunt.Models.HaloInfinite
{
    public class Query
    {
        public string Key { get; set; }
        public string Op { get; set; }

        /// <summary>
        /// Value used for the query. Can be a string or an array of strings, and needs to be unfurled directly by the developer at runtime.
        /// </summary>
        public object Value { get; set; }
    }


}
