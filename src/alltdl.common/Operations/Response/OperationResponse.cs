/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using alltdl.Interfaces;

using System;

namespace alltdl.Operations.Response
{
    public class OperationResponse : Response, IResponse
    {
        public OperationResponse() : base()
        {
        }

        public OperationResponse(Guid id) : base(id)
        {
        }
    }

    public class OperationResponse<TResponse> : Response<TResponse>, IResponse<TResponse> where TResponse : new()
    {
        public OperationResponse() : base()
        {
        }

        public OperationResponse(Guid id) : base(id)
        {
        }
    }
}