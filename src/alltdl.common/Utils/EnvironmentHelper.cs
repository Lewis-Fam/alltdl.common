using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace alltdl.Utils
{
    /// <summary>
    /// Environment helper.
    /// </summary>
    public static class EnvironmentHelper
    {
        //private HostEnviromentInfo()
        //{
        //    LogicalDrives = Environment.GetLogicalDrives();
        //    HostName = Dns.GetHostName();
        //    IpAddresses = Dns.GetHostAddresses(HostName);
        //}

        /// <inheritdoc cref="NetworkInterface.GetAllNetworkInterfaces"/>
        public static IEnumerable<NetworkInterface> GetAllNetworkInterfaces() => NetworkInterface.GetAllNetworkInterfaces();

        /// <inheritdoc cref="Dns.GetHostName"/>
        public static string GetDnsHostName() => Dns.GetHostName();

        /// <inheritdoc cref="Dns.GetHostAddresses(string)"/>
        public static IEnumerable<IPAddress> GetHostAddresses() => Dns.GetHostAddresses(Dns.GetHostName());

        /// <inheritdoc cref="Environment.GetLogicalDrives"/>
        public static IEnumerable<string> GetLogicalDrives() => Environment.GetLogicalDrives();

        /// <summary>
        /// Gets the subnet mask for the given IpAddress.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>An IPAddress.</returns>
        public static IPAddress? GetSubnetMask(this IPAddress address)
        {
            return (from adapter
                    in GetAllNetworkInterfaces()
                    from unicastInfo
                    in adapter.GetIPProperties().UnicastAddresses
                    where unicastInfo.Address.AddressFamily == AddressFamily.InterNetwork
                    where address.Equals(unicastInfo.Address)
                    select unicastInfo.IPv4Mask).FirstOrDefault();

            //throw new ArgumentException($"Can't find subnet mask for IP address '{address}'");;
        }
    }
}