// <copyright file="AcademySeries.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AcademySeries
    {
        public string GameAssetID { get; set; }
        public string MapAssetID { get; set; }
        public bool Available { get; set; }
        public DisplayString Title { get; set; }
        public DisplayString Description { get; set; }
    }
}
