using Grunt.Models.HaloInfinite.Foundation;
using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AuthoringFavoritesContainer : AuthoringResultContainer
    {
        public List<FavoriteAsset> Results { get; set; }
    }
}
