using Grunt.Models.HaloInfinite.Foundation;
using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AuthoringAssetContainer : AuthoringResultContainer
    {
        public List<AuthoringAsset> Results { get; set; }
    }
}
