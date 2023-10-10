using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace alltdl.Utils
{
    /// <summary>
    /// A Base64 Helper class.
    /// </summary>
    public static class Base64Helper
    {
        /// <summary>Initializes a new instance of the <see cref="Base64Image"/> class.</summary>
        public class Base64Image
        {
            public enum ImageType
            {
                jpg,

                jpeg,

                png,

                gif,

                bmp
            }

            /// <summary>Initializes a new instance of the <see cref="Image"/> class.</summary>
            /// <param name="imagePath">The image path.</param>
            /// <param name="imageType">The image type.</param>
            /// <exception cref="FileNotFoundException"></exception>
            /// <exception cref="FileLoadException"></exception>
            public Base64Image(string imagePath, ImageType imageType)
            {
                FilePath = imagePath;
                _imageType = imageType;
                if (File.Exists(FilePath))
                    _fileContents = LoadFile();
                else
                {
                    throw new FileNotFoundException($"{_fileContents} does not exists!");
                }
            }

            /// <summary>Initializes a new instance of the <see cref="Image"/> class.</summary>
            /// <param name="imagePath">The image path.</param>
            /// <exception cref="FileNotFoundException"></exception>
            /// <exception cref="FileLoadException"></exception>
            public Base64Image(string imagePath)
            {
                FilePath = imagePath;
                if (File.Exists(FilePath))
                    _fileContents = LoadFile();
                else
                {
                    throw new FileNotFoundException($"{_fileContents} does not exists!");
                }
            }

            private readonly byte[] _fileContents;

            private readonly string FilePath;

            private ImageType _imageType;

            public string ContentType => $"image/{_imageType}";

            public string DataType => $"data:{ContentType};base64,";

            public string ImageFullString => $"data:{ContentType};base64,{Convert.ToBase64String(_fileContents)}";

            public string ImageString => Convert.ToBase64String(_fileContents);

            //public ContentType _imageType { get; set; }
            public static Base64Image? Parse(string base64Content)
            {
                //if (string.IsNullOrEmpty(base64Content))
                //{
                //    throw new ArgumentNullException(nameof(base64Content));
                //}

                //int indexOfSemiColon = base64Content.IndexOf(";", StringComparison.OrdinalIgnoreCase);

                //string dataLabel = base64Content.Substring(0, indexOfSemiColon);

                //string contentType = dataLabel.Split(':').Last();

                //var startIndex = base64Content.IndexOf("base64,", StringComparison.OrdinalIgnoreCase) + 7;

                //var fileContents = base64Content.Substring(startIndex);

                //var bytes = Convert.FromBase64String(fileContents);

                //return new Base64Image
                //{
                //    //ContentType = contentType,
                //    FileContents = bytes
                //};
                return null;
            }

            //public string ContentTypeHeader => $"data:{ContentType};base64,";
            public override string ToString()
            {
                return ImageString;
            }

            private byte[] LoadFile()
            {
                var supportedTypes = Enum.GetValues(typeof(ImageType));
                foreach (var supportedType in supportedTypes)
                {
                    if (!FilePath.EndsWith(supportedType.ToString()!))
                        continue;

                    _imageType = (ImageType)supportedType;
                    return File.ReadAllBytes(FilePath);
                }
                throw new FileLoadException("Unable to load file. File {0} is not a supported image type.", FilePath);
            }

            private void Usage()
            {
                //var base64Img = new Base64Image
                //{
                //    FileContents = File.ReadAllBytes("Path to image"),
                //    _imageType = ImageType.png
                //};

                //string base64EncodedImg = base64Img.ToString();
            }

            public static string ImageFileToBase64(string imagePath)
            {
                //var supportedTypes = Enum.GetValues(typeof(ImageType));
                //foreach (var supportedType in supportedTypes)
                //{
                //    //if (!imagePath.EndsWith(supportedType.ToString()!))
                //    //    continue;

                //    //_imageType = (ImageType)supportedType;
                //    var bytes =  File.ReadAllBytes(imagePath);
                //    return Convert.ToBase64String(bytes);
                //}
                //throw new FileLoadException("Unable to load file. File {0} is not a supported image type.", imagePath);

                var bytes =  File.ReadAllBytes(imagePath);
                return Convert.ToBase64String(bytes);
            }
            
            public static Image Base64ToImage(string base64String)
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                var memStream = new MemoryStream(imageBytes, 0, imageBytes.Length);

                memStream.Write(imageBytes, 0, imageBytes.Length);
                var image = System.Drawing.Image.FromStream(memStream);
                return image;
            }
        }

        /// <summary>
        /// Converts a Base64 string into plain text.
        /// </summary>
        /// <param name="encodedData">The encoded string.</param>
        /// <returns>A plain text string.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        public static string DecodeFromBase64String(string encodedData)
        {
            var encodedDataAsBytes = Convert.FromBase64String(encodedData);
            return Encoding.ASCII.GetString(encodedDataAsBytes);
        }

        /// <summary>
        /// Coverts a plain text string into base64.
        /// </summary>
        /// <param name="toEncode"></param>
        /// <returns>A string encoded in base64</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="EncoderFallbackException"></exception>
        public static string EncodeToBase64String(string toEncode)
        {
            var toEncodeAsBytes = Encoding.ASCII.GetBytes(toEncode);
            return Convert.ToBase64String(toEncodeAsBytes);
        }
    }
}