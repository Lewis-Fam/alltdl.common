using System;

namespace alltdl.Constants
{
    [Serializable]
    public enum FilePointerType
    {
        File,

        Version,

        Shortcut
    }

    [Serializable]
    public enum FileToUpdateType
    {
        None,

        ConstantValue,

        RegistryValue,

        EnvironmentVariable,

        INIFile
    }

    [Serializable]
    public enum ItemPatternType
    {
        None,

        WildcardFiles,

        FolderExpressions
    }

    [Serializable]
    public enum ShortcutType
    {
        File,

        Internet
    }

    [Serializable]
    public enum VersionComparison
    {
        Any,

        AllowNewer,

        AllowOlder,

        Exact
    }

    [Serializable]
    public enum ItemToCopyType
    {
        None,

        Directory,

        FileOrDirectory,

        ZipFile
    }
}