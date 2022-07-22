// <copyright file="ArmorCoreTheme.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System.Collections.Generic;
using OpenSpartan.Grunt.Models.HaloInfinite.Foundation;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ArmorCoreTheme : Theme
    {
        public string CoatingPath { get; set; }
        public string GlovePath { get; set; }
        public string HelmetPath { get; set; }
        public string HelmetAttachmentPath { get; set; }
        public string ChestAttachmentPath { get; set; }
        public string KneePadPath { get; set; }
        public string LeftShoulderPadPath { get; set; }
        public string RightShoulderPadPath { get; set; }
        public List<Emblem> Emblems { get; set; }
        public string ArmorFxPath { get; set; }
        public string MythicFxPath { get; set; }
        public string VisorPath { get; set; }
        public string HipAttachmentPath { get; set; }
        public string WristAttachmentPath { get; set; }
        public Emblem BigEmblem { get; set; }
    }
}
