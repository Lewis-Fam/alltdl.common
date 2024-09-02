//using alltdl.Utils;

//using Microsoft.VisualStudio.TestTools.UnitTesting;

//using System.Web;
//using alltdl.Extensions;

//namespace alltdl.common.Tests.Utils;

//[TestClass()]
//public class Cypher_Tests
//{
//    [TestMethod()]
//    public void Encrypt_Test()
//    {

//        var encrypt = "TerrellLewis.com".Encrypt();


//        var encoded = HttpUtility.UrlEncode(encrypt);

//        Console.WriteLine(encoded);
//        Console.WriteLine();
//        Console.WriteLine(encrypt.Decrypt());

//        var decoded = HttpUtility.UrlDecode(encoded);

//        Console.WriteLine(decoded);
//        Console.WriteLine();
//        Console.WriteLine(decoded.Decrypt());

//        //Console.WriteLine();
//        //var test = "%48%6F%4C%69%53%77%6F%32%4E%2F%42%6D%4A%75%51%67%39%4F%5A%32%6F%4D%4B%4F%34%58%35%55%58%6E%6B%38%30%64%6E%79%5A%2F%6A%58%43%6E%74%70%6F%5A%70%69%32%55%57%2B%35%55%52%31%6C%45%56%4E%31%4C%78%70";

//        //Console.WriteLine(urle.Encode(encoded));
//    }
//}