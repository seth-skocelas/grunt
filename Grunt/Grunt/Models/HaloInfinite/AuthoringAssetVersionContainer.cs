using Grunt.Models.HaloInfinite.Foundation;
using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AuthoringAssetVersionContainer : AuthoringResultContainer
    {
        public List<AuthoringAssetVersion> Results { get; set; }
    }
}
