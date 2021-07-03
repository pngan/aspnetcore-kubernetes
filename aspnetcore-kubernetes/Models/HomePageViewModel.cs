using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace aspnetcore_kubernetes.Models
{
    public sealed class HomePageViewModel
    {
        public string IpAddress
        {
            get
            {
                return GetLocalIPAddress();
            }
        }
        public string HostName
        {
            get
            {
                return GetLocalHostname();
            }
        }

        public string Application
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Name;
            }
        }
        public string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private static string GetLocalHostname()
        {
            return Dns.GetHostName();
        }
    }
}
