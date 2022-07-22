using System;

namespace Grunt.Models
{
    public class IsAutomaticallySerializableAttribute : Attribute
    {
        public bool IsReady { get; set; }
    }
}
