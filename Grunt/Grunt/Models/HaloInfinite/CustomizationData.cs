// <copyright file="CustomizationData.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class CustomizationData
    {
        public SpartanBody SpartanBody { get; set; }
        public Appearance Appearance { get; set; }
        public ArmorCoreCollection ArmorCores { get; set; }
        public WeaponCoreCollection WeaponCores { get; set; }
        public AiCoreCollection AiCores { get; set; }
        public VehicleCoreCollection VehicleCores { get; set; }
    }
}
