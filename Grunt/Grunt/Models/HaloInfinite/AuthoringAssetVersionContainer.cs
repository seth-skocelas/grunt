using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;
using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AuthoringAssetVersionContainer : AuthoringResultContainer
    {
        public List<AuthoringAssetVersion> Results { get; set; }
    }
}
