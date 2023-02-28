namespace alltdl.Constants
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