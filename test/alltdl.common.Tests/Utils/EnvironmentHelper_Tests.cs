using Microsoft.VisualStudio.TestTools.UnitTesting;
using alltdl.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alltdl.Utils.Tests
{
    [TestClass()]
    public class EnvironmentHelper_Tests
    {
        [TestMethod()]
        public void GetAllNetworkInterfaces_Test()
        {
            foreach (var allNetworkInterface in EnvironmentHelper.GetAllNetworkInterfaces())
            {
                Console.WriteLine(allNetworkInterface.Name);
            }
        }

        [TestMethod()]
        public void GetDnsHostName_Test()
        {
            var hostname = EnvironmentHelper.GetDnsHostName();
            var expected = "iLewis";
            Assert.IsTrue(hostname == expected);
        }

        [TestMethod()]
        public void GetHostAddresses_Test()
        {
            foreach (var hostAddress in EnvironmentHelper.GetHostAddresses())
            {
                Console.WriteLine(hostAddress.ToString() + " / " + hostAddress.GetSubnetMask());
            }
        }

        [TestMethod()]
        public void GetLogicalDrives_Test()
        {
            foreach (var logicalDrive in EnvironmentHelper.GetLogicalDrives())
            {
                Console.WriteLine(logicalDrive);
            }
        }
    }
}