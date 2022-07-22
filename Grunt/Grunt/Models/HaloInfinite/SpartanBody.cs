// <copyright file="SpartanBody.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class SpartanBody
    {
        public APIFormattedDate? LastModifiedDateUtc { get; set; }
        public string LeftArm { get; set; }
        public string RightArm { get; set; }
        public string LeftLeg { get; set; }
        public string RightLeg { get; set; }
        public string BodyType { get; set; }
        public int Voice { get; set; }
    }
}
