using Grunt.Core;
using Grunt.Librarian.Models;
using Grunt.Models.HaloInfinite.ApiIngress;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Grunt.Librarian
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Grunt Librarian - Halo Infinite API Indexer");
            Console.WriteLine("Developed by Den Delimarsky in 2022. Part of https://gruntapi.com");

            HaloInfiniteClient client = new(string.Empty, string.Empty);

            ApiSettingsContainer container = new();
            // Get the API endpoint data.
            Task.Run(async () =>
            {
                container = await client.GetApiSettingsContainer();
            }).GetAwaiter().GetResult();

            if (container != null)
            {
                foreach(var endpoint in container.Endpoints)
                {
                    ApiAuthority endpointAuthority = (from c in container.Authorities where string.Equals(c.Key, endpoint.Value.AuthorityId, StringComparison.InvariantCultureIgnoreCase) select c).First().Value;
                    var endpointNamePieces = endpoint.Key.Split('_');

                    ExportableFunction func = new();
                    func.Name = endpointNamePieces.Last();
                    func.AuthorityHost = endpoint.Value.AuthorityId;
                    func.AuthorityPort = endpointAuthority.Port;
                    func.QueryString = endpoint.Value.QueryString;
                    func.RequiresClearance = endpoint.Value.ClearanceAware;
                    func.RequiresSpartanToken = endpointAuthority.AuthenticationMethods.Contains(15);
                    
                    switch(func.Name)
                    {
                        case string s when s.StartsWith("Get", StringComparison.InvariantCultureIgnoreCase):
                            func.Method = HttpMethod.Get;
                            break;
                        case string s when s.StartsWith("Post", StringComparison.InvariantCultureIgnoreCase):
                            func.Method = HttpMethod.Post;
                            break;
                        case string s when s.StartsWith("Delete", StringComparison.InvariantCultureIgnoreCase):
                            func.Method = HttpMethod.Delete;
                            break;
                        case string s when s.StartsWith("Upload", StringComparison.InvariantCultureIgnoreCase):
                            func.Method = HttpMethod.Post;
                            break;
                        case string s when s.StartsWith("Put", StringComparison.InvariantCultureIgnoreCase):
                            func.Method = HttpMethod.Put;
                            break;
                        default:
                            func.Method = HttpMethod.Get;
                            func.NeedsIntervention = true;
                            break;
                    }
                }
            }
        }
    }
}
