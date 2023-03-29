using System;

namespace alltdl.Constants.Software
{
    [Serializable]
    public enum InstallMode
    {
        None,

        Prerequisites,

        Install,

        Uninstall,

        Recovery
    }

    [Flags]
    [Serializable]
    public enum InstallTypeFlags
    {
        None = 0,

        Fresh = 1,

        Upgrade = 2,

        Patch = 4,

        ValidateOnly = 8
    }
}