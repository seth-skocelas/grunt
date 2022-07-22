using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenSpartan.Grunt.Librarian.Models
{
    internal class ExportableFunction
    {
        internal string Name { get; set; }
        internal string EndpointId { get; set; }
        internal string Class { get; set; }
        internal string AuthorityHost { get; set; }
        internal int? AuthorityPort { get; set; }
        internal string EndpointPath { get; set; }
        internal string QueryString { get; set; }
        internal bool RequiresSpartanToken { get; set; }
        internal bool RequiresClearance { get; set; }
        internal HttpMethod Method { get; set; }
        internal bool NeedsIntervention { get; set; }
        internal string FunctionCode { get; set; }
    }
}
