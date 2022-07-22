// <copyright file="Extensions.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System;
using System.Reflection;
using OpenSpartan.Grunt.Models;

namespace OpenSpartan.Grunt.Util
{
    internal static class Extensions
    {
        public static string? GetHeaderValue(this ApiContentType value)
        {
            Type type = value.GetType();
            FieldInfo? fieldInfo = type.GetField(name: value.ToString());

            if (fieldInfo != null)
            {
                ContentTypeAttribute[]? attributes = fieldInfo.GetCustomAttributes(typeof(ContentTypeAttribute), false) as ContentTypeAttribute[];

                if (attributes != null)
                {
                    return attributes.Length > 0 ? attributes[0].HeaderValue : null;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
