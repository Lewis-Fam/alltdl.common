/***
   Copyright (C) 2023. LewisFam. All Rights Reserved.
   Version: 1.0.0
***/

namespace alltdl;

/// <summary>The lewis fam object.</summary>
public interface ILewisFamObject : IDisposable
{
    /// <summary>Gets a value indicating whether this instance has been disposed.</summary>
    /// <returns>true if this instance has been disposed; otherwise, false.</returns>
    bool IsDisposed { get; }

    /// <summary>Gets a value indicating whether this instance is disposable.</summary>
    /// <returns>true if this instance is disposable; otherwise, false.</returns>

    bool IsEnableDispose { get; }

    /// <summary>Gets a pointer of native structure.</summary>
    /// &gt;
    IntPtr NativePtr { get; }

    /// <summary>If this object is disposed, then <see cref="System.ObjectDisposedException"/> is thrown.</summary>
    /// <exception cref="ObjectDisposedException"></exception>
    void ThrowIfDisposed();

    /// <summary>If this object is disposed, then <see cref="System.ObjectDisposedException"/> is thrown.</summary>
    /// <exception cref="ObjectDisposedException"></exception>
    void ThrowIfDisposed(string objectName);
}