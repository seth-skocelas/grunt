// <copyright file="Media.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using OpenSpartan.Grunt.Models.HaloInfinite.ApiIngress;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Media
    {
        public ApiEndpoint MediaUrl { get; set; }
        public string MimeType { get; set; }
        public DisplayString Caption { get; set; }
        public DisplayString AlternateText { get; set; }
        public string FolderPath { get; set; }
        public string FileName { get; set; }
    }

}
