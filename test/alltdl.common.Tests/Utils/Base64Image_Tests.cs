using System.Drawing.Drawing2D;
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
            const string testImage = @"D:\daddy\.life\.storage\.assets\images\road-sign-361513_960_720.jpg";
            if (File.Exists(testImage))
            {
                var base64Img = new Base64Helper.Base64Image(testImage, Base64Helper.Base64Image.ImageType.jpg);
                
                
                Assert.IsNotNull(base64Img.ImageString);

                Console.WriteLine(base64Img.ImageString);

                var test = Base64Helper.Base64Image.ImageFileToBase64(testImage);
                Assert.AreEqual(base64Img.ImageString, test);
                Console.WriteLine();
            }
            else
                Assert.Inconclusive("Test image not found.");
        }

        [TestMethod()]
        public void Base64Image_Load_ImageType_Test()
        {
            const string testImage = @"D:\daddy\.life\.storage\.assets\images\a.png";

            if (File.Exists(testImage))
            {
                var base64Img = new Base64Helper.Base64Image(testImage);
                //Console.WriteLine(base64Img.ImageString);
                Console.WriteLine(base64Img);
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
                var base64Image = new Base64Helper.Base64Image(@"D:\daddy\dev\.alltdl\assets\fileNotFound.txt");
            });

            if (File.Exists(@"D:\daddy\dev\.alltdl\assets\favicon.ico"))
                Assert.ThrowsException<FileLoadException>(() =>
                {
                    var base64Image = new Base64Helper.Base64Image(@"D:\daddy\dev\.alltdl\assets\favicon.ico");
                });
        }

        [TestMethod()]
        public void Base64Image_Encode_Test()
        {
            var base64 = Base64Helper.Base64Image.Encode("");
        }

        [TestMethod()]
        public void Base64Image_Decode_Test()
        {
            const string testImage = @"D:\daddy\.life\.storage\.assets\images\road-sign-361513_960_720.jpg";
            var img = Base64Helper.Base64Image.Decode(Base64Helper.Base64Image.ImageFileToBase64(testImage));
            Console.WriteLine(img.Height);
            Console.WriteLine(img.Width);
        }
    }
}