using System;
using System.IO;
using System.Text;

namespace alltdl.Utils
{
    public static class Base64Helper
    {
        public class Image
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
            public Image(string imagePath, ImageType imageType)
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
            public Image(string imagePath)
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

            public string ImageString => $"data:{ContentType};base64,{Convert.ToBase64String(_fileContents)}";

            //public ContentType _imageType { get; set; }
            public static Image Parse(string base64Content)
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
                    if (!FilePath.EndsWith(supportedType.ToString()))
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
        }

        public static string DecodeFromBase64String(string encodedData)
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(encodedData);
            return Encoding.ASCII.GetString(encodedDataAsBytes);
        }

        public static string EncodeToBase64String(string toEncode)
        {
            byte[] toEncodeAsBytes = Encoding.ASCII.GetBytes(toEncode);
            return Convert.ToBase64String(toEncodeAsBytes);
        }
    }
}