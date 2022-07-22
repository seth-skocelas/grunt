// <copyright file="ManifestCustomData.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ManifestCustomData
    {
        public string BranchName { get; set; }
        public string BuildNumber { get; set; }
        public int Kind { get; set; }
        public string ContentVersion { get; set; }
        public string BuildGuid { get; set; }
        public int Visibility { get; set; }
    }
}
