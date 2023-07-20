namespace alltdl.Constants
{
    /// <summary>
    /// MIME Content-Type file header field.
    /// </summary>
    /// <remarks>This header field indicates the media type of the message content, consisting of a type and subtype, for example <code>Content-Type: text/plain</code></remarks>
    public static class MIME
    {
        /// <summary>
        /// MIME Content-Type: application/{x}
        /// </summary>
        public static class Application
        {
            /// <summary>
            /// application/ecmascript
            /// </summary>
            public const string Ecmascript = "application/ecmascript";

            /// <summary>
            /// application/vnd.github.v3+json
            /// </summary>
            public const string GithubV3Json = "application/vnd.github.v3+json";

            /// <summary>
            /// application/javascript
            /// </summary>
            public const string Javascript = "application/javascript";

            /// <summary>
            /// application/json
            /// </summary>
            public const string Json = "application/json";

            /// <summary>
            /// application/mp4
            /// </summary>
            public const string Mp4 = "application/mp4";

            public const string Torrent = "application/x-bittorrent";

            public const string Msi = "application/msword";

            public const string Exe = "application/vnd.microsoft.portable-executable";

            /// <inheritdoc cref="MIME.DEFAULT_FILE"/>
            public const string OctetStream = MIME.DEFAULT_FILE;

            public const string Pdf = "application/pdf";

            public const string Pkcs10 = "application/pkcs10";

            public const string Pkcs7Mime = "application/pkcs7-mime";

            public const string Pkcs7Signature = "application/pkcs7-signature";

            public const string Pkcs8 = "application/pkcs8";

            public const string Postscript = "application/postscript";

            public const string RdfXml = "application/rdf+xml";

            public const string RssXml = "application/rss+xml";

            public const string Rtf = "application/rtf";

            public const string SmilXml = "application/smil+xml";

            public const string XFontOtf = "application/x-font-otf";

            public const string XFontTtf = "application/x-font-ttf";

            public const string XFontWoff = "application/x-font-woff";

            public const string XhtmlXml = "application/xhtml+xml";

            public const string Xml = "application/xml";

            public const string XmlDtd = "application/xml-dtd";

            public const string XPkcs12 = "application/x-pkcs12";

            public const string XShockwaveFlash = "application/x-shockwave-flash";

            public const string XSilverlightApp = "application/x-silverlight-app";

            public const string XsltXml = "application/xslt+xml";

            public const string XWwwForm = "application/x-www-form-urlencoded";

            public const string Zip = "application/zip";
        }

        public static class Audio
        {
            public const string Midi = "audio/midi";

            public const string Mp4 = "audio/mp4";

            public const string Mpeg = "audio/mpeg";

            public const string Ogg = "audio/ogg";

            public const string Webm = "audio/webm";

            public const string XAac = "audio/x-aac";

            public const string XAiff = "audio/x-aiff";

            public const string XMpegurl = "audio/x-mpegurl";

            public const string XMsWma = "audio/x-ms-wma";

            public const string XWav = "audio/x-wav";
        }

        public static class Image
        {
            public const string Bmp = "image/bmp";

            public const string Gif = "image/gif";

            public const string Jpeg = "image/jpeg";

            public const string Png = "image/png";

            public const string SvgXml = "image/svg+xml";

            public const string Tiff = "image/tiff";

            public const string Webp = "image/webp";
        }

        public static class Text
        {
            public const string Css = "text/css";

            public const string Csv = "text/csv";

            public const string Html = "text/html";

            public const string Plain = "text/plain";

            public const string RichText = "text/richtext";

            public const string Sgml = "text/sgml";

            public const string Yaml = "text/yaml";
        }

        public static class Video
        {
            public const string H264 = "video/h264";

            public const string H265 = "video/h265";

            public const string Mp4 = "video/mp4";

            public const string Mpeg = "video/mpeg";

            public const string Ogg = "video/ogg";

            public const string Quicktime = "video/quicktime";

            /// <summary>
            /// MPEG transport stream see <see cref="FileExtension.Video.Ts"/> or seealso: <seealso cref="FileExtension.Video.Ts"/>
            /// </summary>
            /// <autogeneratedoc />
            public const string TransportStream = "video/mp2t";

            /// <summary>
            /// video/3gpp
            /// </summary>
            /// <autogeneratedoc />
            public const string Threegpp = "video/3gpp";

            public const string Webm = "video/webm";
        }

        /// <summary>
        /// text/plain is the default value for textual files. A textual file should be human-readable and must not contain binary data.
        /// </summary>
        public const string DEFAULT_TEXT = "text/plain";

        /// <summary>
        /// application/octet-stream is the default value for all other cases. An unknown file type should use this type. Browsers are particularly careful when manipulating these files to protect users from software vulnerabilities and possible dangerous behavior.
        /// </summary>
        public const string DEFAULT_FILE = "application/octet-stream";
    }
}