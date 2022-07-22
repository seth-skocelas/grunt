using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class TestAcademyClientManifest
    {
        public TestAcademyTutorial Tutorial { get; set; }
        public TestDrillCategory[] Categories { get; set; }
    }
}
