using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using alltdl.Constants;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace alltdl.common.Tests.Constants
{
    [TestClass()]
    public class RegexPattern_Tests
    {
        private string testInput = @"
192.168.1.1/32 //valid
0.0.0.0/8 //valid
255.255.255.255 //valid
256.256.256.256
999.999.999.999
1.2.3
1.2.3.4 //valid
127.0.0.1/24 //valid
127.0.0.1/7 //valid ip - invalid notation";

        [TestMethod()]
        public void Ip4_Test()
        {
            var matches = Regex.Matches(testInput, RegexPattern.Ip4);

            if (matches.Any())
            {
                foreach (var match in matches)
                {
                    System.Console.WriteLine(match);
                }
            }
            else
            {
                Console.WriteLine("No match.");
            }
        }

        [TestMethod()]
        public void Ip4WithNetworkNotation_Test()
        {
            var matches = Regex.Matches(testInput, RegexPattern.Ip4Notation);

            if (matches.Any())
            {
                foreach (var match in matches)
                {
                    System.Console.WriteLine(match);
                }
            }
            else
            {
                Console.WriteLine("No match.");
            }
        }
    }
}