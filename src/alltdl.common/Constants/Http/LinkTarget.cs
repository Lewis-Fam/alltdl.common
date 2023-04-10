using System;

namespace alltdl.Constants.Http
{
    /// <summary>
    /// Html Link Target
    /// </summary>
    [Serializable]
    public enum LinkTarget
    {
        _Blank = 1,

        _Parent,

        _Self,

        _Top,

        _FrameName
    }
}