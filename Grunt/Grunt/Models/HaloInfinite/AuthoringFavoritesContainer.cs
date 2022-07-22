using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;
using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AuthoringFavoritesContainer : AuthoringResultContainer
    {
        public List<FavoriteAsset> Results { get; set; }
    }
}
