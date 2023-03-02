/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

using alltdl.Interfaces;

namespace alltdl.Operations.Response;

/// <summary>Internal use only.</summary>
/// <seealso cref="IResponse"/>
public abstract class Response : IResponse
{
    /// <summary>Initializes a new instance of the <see cref="Response"/> class.</summary>
    public Response()
    {
        //Id = Guid.Empty;
    }

    /// <summary>Initializes a new instance of the <see cref="Response"/> class.</summary>
    /// <param name="id">The identifier.</param>
    protected Response(Guid id)
    {
        Id = id;
    }

    /// <summary>Gets or sets the identifier.</summary>
    /// <value>The identifier.</value>
    public virtual Guid Id { get; protected set; }

    /// <summary>Returns true if MetaData is valid.</summary>
    /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
    public virtual bool IsValid => MetaData != null;

    /// <summary>Meta Data</summary>
    protected virtual object[] MetaData { get; set; }

    /// <summary>Sets the identifier.</summary>
    /// <param name="id">The identifier.</param>
    protected void SetId(Guid id)
    {
        Id = id;
    }
}

/// <summary>The response.</summary>
public abstract class Response<T> : Response, IResponse<T> where T : new()
{
    /// <summary>Initializes a new instance of the <see cref="Response{T}"/> class.</summary>
    public Response() : base()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Response{T}"/> class.</summary>
    /// <param name="id">The identifier.</param>
    protected Response(Guid id) : base(id)
    {
        Id = id;
    }

    public T Result { get; }

    /// <summary>Returns true if MetaData is valid.</summary>
    /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
    public virtual new bool IsValid => MetaData != null && MetaData.Any();

    //T[] IResponse<T>.MetaData { get; }

    /// <summary>Meta Data</summary>
    //public override T[] MetaData { get; set; }

    //T IResponse<T>.MetaData => throw new NotImplementedException();
    public virtual new T[] MetaData { get; set; }
}