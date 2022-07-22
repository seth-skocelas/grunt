// <copyright file="Appearance.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Appearance
    {
        public APIFormattedDate? LastModifiedDateUtc { get; set; }
        public string ServiceTag { get; set; }
        public string ActionPosePath { get; set; }
        public string StancePath { get; set; }
        public string BackdropImagePath { get; set; }
        public Emblem Emblem { get; set; }
        public string IntroEmotePath { get; set; }
    }
}
