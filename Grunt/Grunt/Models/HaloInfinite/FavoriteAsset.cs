using Grunt.Models.HaloInfinite.Foundation;

namespace Grunt.Models.HaloInfinite
{
    public class FavoriteAsset : Asset
    {
        //TODO: Figure out what the type is here.
        public object Links { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //TODO: Figure out what the type is here.
        public object CustomData { get; set; }
        //TODO: Figure out what the type is here.
        public object VersionRatings { get; set; }
    }
}
