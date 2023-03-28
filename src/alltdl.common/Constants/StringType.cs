using System;

namespace alltdl.Constants
{
    [Serializable]
    public enum StringType
    {
        Unknown = 0,

        Plain,

        Base64,

        Encrypted,

        EncryptedBase64,

        Byte,

        Char,

        Hex,
    }

    [Serializable]
    public enum StringEncodedType
    {
        Unknown = 0,

        Ut8,

        Unicode,

        EncodedBase64,

        EncodedUrl,

        Html
    }
}