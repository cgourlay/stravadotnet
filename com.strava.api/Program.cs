using System;
using System.Configuration;

using Nancy.Hosting.Self;

namespace com.Strava.Api
{
    internal static class Program
    {
        public static void Main()
        {
            //var serviceUri = new Uri(ConfigurationManager.AppSettings["ServiceUri"]);
            //var configuration = new HostConfiguration
            //{
            //    AllowChunkedEncoding = false,
            //    RewriteLocalhost = false,
            //    UrlReservations = new UrlReservations {CreateAutomatically = true}
            //};

            //using (var host = new NancyHost(configuration, serviceUri))
            //{
            //    host.Start();
            //    Console.ReadLine();
            //}
        }
    }
}
