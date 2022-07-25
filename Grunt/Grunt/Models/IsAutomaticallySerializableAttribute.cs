// <copyright file="IsAutomaticallySerializableAttribute.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System;

namespace OpenSpartan.Grunt.Models
{
    /// <summary>
    /// Determines whether an object can be automatically serialized by a Halo API client.
    /// </summary>
    public class IsAutomaticallySerializableAttribute : Attribute
    {
    }
}
