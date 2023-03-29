using System;

namespace alltdl.Constants
{
    [Serializable]
    public enum StringType
    {
        Unknown = 0,

        Plain,

        Base64,

        Byte,

        Char,

        Hex,

        Encrypted,

        EncryptedBase64,
    }

    [Serializable]
    public enum StringEncodedType
    {
        Unknown = 0,

        Ascii,

        Ut8,

        Unicode,

        Base64,

        Url,

        Html
    }
}