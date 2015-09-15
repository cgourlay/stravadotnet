using System;
using System.Configuration;

using Nancy.Hosting.Self;

namespace SwimBikeRun.Strive.Modules
{
    public static class Program
    {
        private static readonly Uri Endpoint = new Uri(ConfigurationManager.AppSettings["HostUri"]);

        static void Main()
        {   
            using (var host = new NancyHost(Endpoint))
            {
                host.Start();
                Console.WriteLine("Service running on: {0}", Endpoint.AbsoluteUri);
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
            }
        }
    }
}
