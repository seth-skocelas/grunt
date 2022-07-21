using System;
using System.Reflection;
using Grunt.Models;

namespace Grunt.Util
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
