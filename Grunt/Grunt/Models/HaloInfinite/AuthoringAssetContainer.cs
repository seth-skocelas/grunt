using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;
using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AuthoringAssetContainer : AuthoringResultContainer
    {
        public List<AuthoringAsset> Results { get; set; }
    }
}
