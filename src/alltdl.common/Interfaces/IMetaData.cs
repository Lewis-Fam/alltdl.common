/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

namespace alltdl.Interfaces
{
    public interface IDescribable : INameable
    {
        string Description { get; set; }

        string Name { get; set; }
    }

    public interface IMessage
    {
        bool HasMessage { get; }

        string Message { get; }
    }

    /// <summary>The meta data.</summary>
    public interface IMetaData<out TEntity> where TEntity : new()
    {
        /// <summary>Gets the data.</summary>
        TEntity[] Data { get; }
    }

    public interface INameable
    {
        string Name { get; }
    }
}