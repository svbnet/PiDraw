using System;
using System.Collections.Generic;
using System.Text;

namespace svbnet.PiDraw.DispManX
{
    public abstract class HandleResource : IDisposable
    {
        private readonly string name;

        protected HandleResource()
        {
            name = GetType().Name;
        }

        /// <summary>
        /// The handle to the unmanaged pointer.
        /// </summary>
        internal uint Handle { get; set; }

        internal uint HandleOrThrow()
        {
            ThrowIfDisposed();
            return Handle;
        }

        public bool Disposed => Handle == 0;

        protected void ThrowIfDisposed()
        {
            if (Disposed) throw new ObjectDisposedException(name);
        }

        /// <summary>
        /// Frees all unmanaged resources associated with this object. Will only be called if <see cref="Handle"/> is not null.
        /// </summary>
        protected abstract void Free();

        private void ReleaseUnmanagedResources()
        {
            if (Disposed) return;
            Free();
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~HandleResource()
        {
            ReleaseUnmanagedResources();
        }
    }
}
