using System;

namespace alltdl.Constants.Http
{
    /// <summary>
    /// Http Method
    /// </summary>
    [Serializable]
    public enum HttpMethod
    {
        Get = 1,

        Post,

        Put,

        Head,

        Delete,

        Patch,

        Options,

        Connect,

        Trace
    }
}