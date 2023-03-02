/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

namespace alltdl.Interfaces;

public interface IRequest<out TResponse>
{
    public IResponse<TResponse> Response { get; }
}

public interface IResponse : IResult
{
}

public interface IResponse<out T> : IResponse
{
    //T[] MetaData { get; }
    /// <summary>The result.</summary>
    T Result { get; }
}