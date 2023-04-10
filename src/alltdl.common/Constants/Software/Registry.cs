using System;

namespace alltdl.Constants.Software
{
    [Serializable]
    public enum RegistryAction
    {
        Unknown,

        Key,

        InstalledProduct,

        KeyVersion,

        ProductVersion
    }

    [Serializable]
    public enum RegistryCommandType
    {
        None,

        Add
    }
}