using Slipspace.Authentication;
using Slipspace.Util;
using System;

namespace Slipspace.Zeta
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientConfigurationReader clientConfigReader = new();
            var config = clientConfigReader.ReadClientConfiguration();

            XboxAuthenticationManager manager = new();
            var url = manager.GenerateAuthUrl(config.ClientId, "https://localhost");

            Console.WriteLine("Provide account authorization and grab the code from the URL:");
            Console.WriteLine(url);
            Console.ReadLine();
        }
    }
}
