// <copyright file="CPUPreset.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class CPUPreset
    {
        public int PhysicalCores { get; set; }
        public int LogicalCores { get; set; }
        public int L3CacheSizeMB { get; set; }
        public int RAMSizeGB { get; set; }
        public int BaseFreqMHz { get; set; }
    }
}
