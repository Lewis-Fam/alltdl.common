﻿/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

namespace alltdl.Interfaces
{
    public interface IRequest<out TResponse>
    {
        IResponse<TResponse> Response { get; }
    }

    public interface IResponse : IResult
    {
    }

    public interface IResponse<out TResponse> : IResponse
    {
        //T[] MetaData { get; }
        /// <summary>The result.</summary>
        TResponse Result { get; }
    }
}