using System;
using System.Configuration;

using Nancy.Hosting.Self;

namespace SwimBikeRun.Strive.Modules
{
    public static class Program
    {
        static void Main()
        {
            var uri = ConfigurationManager.AppSettings["HostUri"];

            using (var host = new NancyHost(new Uri(uri)))
            {
                host.Start();
                Console.ReadLine();
            }
        }
    }
}
