/***
   Copyright (C) 2023. LewisFam. All Rights Reserved.
   Version: 1.0.0
***/

using System;

namespace alltdl.Abstractions
{
    /// <summary>The LewisFamObject base class.</summary>
    public abstract partial class LewisFamObject : ILewisFamObject
    {
        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="LewisFamObject"/> class with the specified value indicating whether this instance is disposable.</summary>
        /// <param name="isEnabledDispose">true if this instance is disposable; otherwise, false.</param>
        protected LewisFamObject(bool isEnabledDispose = true)
        {
            IsEnableDispose = isEnabledDispose;
        }

        #endregion Constructors

        #region Properties

        /// <summary>Gets a value indicating whether this instance has been disposed.</summary>
        /// <returns>true if this instance has been disposed; otherwise, false.</returns>
        public bool IsDisposed
        {
            get;
            private set;
        }

        /// <summary>Gets a value indicating whether this instance is disposable.</summary>
        /// <returns>true if this instance is disposable; otherwise, false.</returns>
        public bool IsEnableDispose
        {
            get;
        }

        /// <summary>Gets a pointer of native structure.</summary>
        /// &gt;
        public IntPtr NativePtr
        {
            get;
            private set;
        }

        #endregion Properties

        #region Methods

        /// <summary>Releases all resources used by this <see cref="LewisFamObject"/>.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ILewisFamObject)obj);

            //return Equals((LewisFamObject) obj);
        }

        public override int GetHashCode()
        {
            return NativePtr.GetHashCode();
        }

        /// <summary>If this object is disposed, then <see cref="System.ObjectDisposedException"/> is thrown.</summary>
        /// <exception cref="ObjectDisposedException"></exception>
        public void ThrowIfDisposed()
        {
            if (IsDisposed)
                throw new ObjectDisposedException(GetType().FullName);
        }

        /// <summary>ThrowIfDisposed</summary>
        /// <param name="objectName"></param>
        /// <exception cref="ObjectDisposedException"></exception>
        public void ThrowIfDisposed(string objectName)
        {
            if (IsDisposed)
                throw new ObjectDisposedException(objectName);
        }

        #region Overrides

        /// <summary>Releases all managed resources.</summary>
        protected virtual void DisposeManaged()
        {
        }

        /// <summary>Releases all unmanaged resources.</summary>
        protected virtual void DisposeUnmanaged()
        {
        }

        protected virtual void DisposingManaged()
        {
        }

        protected virtual void DisposingUnmanaged()
        {
        }

        /// <summary>Releases all resources used by this <see cref="LewisFamObject"/>.</summary>
        /// <param name="disposing">Indicate value whether <see cref="IDisposable.Dispose"/> method was called.</param>
        private void Dispose(bool disposing)
        {
            if (IsDisposed)
            {
                return;
            }

            // pre-disposing
            {
                if (disposing)
                {
                    if (IsEnableDispose)
                        DisposingManaged();
                }

                if (IsEnableDispose)
                    DisposingUnmanaged();
            }

            IsDisposed = true;

            //if (disposing)
            //{
            //    if (IsEnableDispose)
            //        DisposeManaged();
            //}

            //if (IsEnableDispose)
            //    DisposeUnmanaged();

            NativePtr = IntPtr.Zero;
        }

        private bool Equals(ILewisFamObject other)
        {
            return NativePtr.Equals(other.NativePtr);
        }

        #endregion Overrides

        #endregion Methods
    }
}