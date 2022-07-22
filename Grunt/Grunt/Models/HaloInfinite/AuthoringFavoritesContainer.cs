using Grunt.Models.HaloInfinite.Foundation;
using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AuthoringFavoritesContainer : AuthoringResultContainer
    {
        public List<FavoriteAsset> Results { get; set; }
    }
}
