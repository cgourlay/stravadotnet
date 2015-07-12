using System;
using System.Configuration;

using Nancy.Hosting.Self;

namespace SwimBikeRun.Strive.Modules
{
    public class Program
    {
        static void Main()
        {
            var uri = ConfigurationManager.AppSettings["HostUri"];

            using (var host = new NancyHost(new Uri(uri)))
            {
                host.Start();

                Console.WriteLine("Your application is running on {0}", uri);
                Console.WriteLine("Press any key to close the host.");
                Console.ReadLine();
            }
        }
    }
}
