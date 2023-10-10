using alltdl.Utils;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace alltdl.common.Tests.Utils;

[TestClass]
public class JsonHelper_Tests
{
    [TestMethod]
    public void Serialize_JsonDocument_Test()
    {
        const string testFile = @"D:\daddy\dev\.alltdl\src\apps\web\terrelllewis.com\public\App_Data\data\recommend_sites.json";

        if (File.Exists(testFile))
        {
            var data = File.ReadAllText(testFile).ToJsonDocument(JsonHelper.JsonSerializerOptions);
            Console.WriteLine(data.RootElement.ToString());
            Assert.IsNotNull(data, "data != null");
        }
        else
            Assert.Inconclusive("The test file is not found.");
    }
}