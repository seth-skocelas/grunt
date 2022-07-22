// <copyright file="WeaponCoreTheme.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class WeaponCoreTheme : Foundation.Theme
    {
        public string CoatingPath { get; set; }
        public List<Emblem> Emblems { get; set; }
        public Emblem BigEmblem { get; set; }
        public string DeathFxPath { get; set; }
        public string AmmoCounterColorPath { get; set; }
        public string StatTrackerPath { get; set; }
        public string WeaponCharmPath { get; set; }
        public string AlternateGeometryRegionPath { get; set; }
        public string AmmoCounterPath { get; set; }
    }
}
