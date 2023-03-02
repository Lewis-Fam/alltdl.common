/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using System.Runtime.Serialization.Json;

namespace alltdl.Core;

/// <summary></summary>
public static class Serializer
{
    /// <summary></summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static DataContractJsonSerializer Json<T>()
    {
        return new DataContractJsonSerializer(typeof(T));
    }
}