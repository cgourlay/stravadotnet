using System;
using System.Configuration;

using Nancy.Hosting.Self;

namespace SwimBikeRun.Strive.Modules
{
    public static class Program
    {
        static void Main()
        {   
            using (var host = new NancyHost(new Uri(ConfigurationManager.AppSettings["HostUri"])))
            {
                host.Start();
                Console.ReadLine();
            }
        }
    }
}
