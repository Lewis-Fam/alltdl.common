using System;

namespace alltdl.Abstractions
{
    public abstract class DisposableBaseClass : IDisposable
    {
        ~DisposableBaseClass()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose ...
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Release unmanaged resources.
        /// </summary>
        protected virtual void ReleaseUnmanagedResources()
        {
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();

            if (disposing)
            {
            }
        }
    }
}