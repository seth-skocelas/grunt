using Grunt.Models.HaloInfinite.Foundation;
using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AuthoringAssetVersionContainer : AuthoringResultContainer
    {
        public List<AuthoringAssetVersion> Results { get; set; }
    }
}
