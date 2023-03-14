using alltdl.Utils;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace alltdl.common.Tests.Utils
{
    [TestClass()]
    public class Base64Image_Tests
    {
        [TestMethod()]
        public void Base64Image_Image_Test()
        {
            const string testImage = @"D:\daddy\dev\.alltdl\assets\images\road-sign-361513_960_720.jpg";
            if (File.Exists(testImage))
            {
                var base64Img = new Base64Helper.Image(testImage, Base64Helper.Image.ImageType.jpg);

                Assert.IsNotNull(base64Img.ImageString);
            }
            else
                Assert.Inconclusive("Test image not found.");
        }

        [TestMethod()]
        public void Base64Image_Load_ImageType_Test()
        {
            const string testImage = @"D:\daddy\dev\.alltdl\assets\images\a.png";

            if (File.Exists(testImage))
            {
                var base64Img = new Base64Helper.Image(testImage);

                Assert.IsNotNull(base64Img, "base64Img != null");
            }
            else
                Assert.Inconclusive("Test image not found.");
        }

        [TestMethod()]
        public void Base64Image_FileLoad_FileNotFound_Exception_Test()
        {
            Assert.ThrowsException<FileNotFoundException>(() =>
            {
                var base64Image = new Base64Helper.Image(@"D:\daddy\dev\.alltdl\assets\fileNotFound.txt");
            });

            if (File.Exists(@"D:\daddy\dev\.alltdl\assets\favicon.ico"))
                Assert.ThrowsException<FileLoadException>(() =>
                {
                    var base64Image = new Base64Helper.Image(@"D:\daddy\dev\.alltdl\assets\favicon.ico");
                });
        }
    }
}