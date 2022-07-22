using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;
using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class FavoriteAsset : Asset
    {
        //TODO: Figure out what the type is here.
        public object Links { get; set; }
        public string Name { get; set; }
        //TODO: Figure out what the type is here.
        public object CustomData { get; set; }
        public List<VersionRating> VersionRatings { get; set; }
    }
}
