// <copyright file="DevicePresetOverrides.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class DevicePresetOverrides
    {
        public int Version { get; set; }
        public NvidiaPreset Nvidia { get; set; }
        public AMDPreset AMD { get; set; }
        public IntelPreset Intel { get; set; }
    }
}
