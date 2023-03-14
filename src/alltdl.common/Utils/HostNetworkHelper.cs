using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace alltdl.Utils
{
    public static class HostNetworkHelper
    {
        //private HostEnviromentInfo()
        //{
        //    LogicalDrives = Environment.GetLogicalDrives();
        //    HostName = Dns.GetHostName();
        //    IpAddresses = Dns.GetHostAddresses(HostName);
        //}

        public static string[] GetLogicalDrives() => Environment.GetLogicalDrives();

        public static string GetDnsHostName() => Dns.GetHostName();

        public static IPAddress[] GetAllIpAddresses() => Dns.GetHostAddresses(Dns.GetHostName());

        public static NetworkInterface[] GetAllNetworkInterfaces() => NetworkInterface.GetAllNetworkInterfaces();

        /// <summary>
        /// Gets the subnet mask for the given IpAddress.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>An IPAddress.</returns>
        public static IPAddress? GetSubnetMask(this IPAddress address)
        {
            foreach (var adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (var unicastInfo in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (address.Equals(unicastInfo.Address))
                        {
                            var ipAddress = unicastInfo.IPv4Mask;
                            return ipAddress;
                        }
                    }
                }
            }
            return null;

            //throw new ArgumentException($"Can't find subnet mask for IP address '{address}'");;
        }
    }
}