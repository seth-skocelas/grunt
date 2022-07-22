using Grunt.Models.HaloInfinite.Foundation;
using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AuthoringAssetContainer : AuthoringResultContainer
    {
        public List<AuthoringAsset> Results { get; set; }
    }
}
