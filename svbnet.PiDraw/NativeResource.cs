using System;
using System.Collections.Generic;
using System.Text;

namespace svbnet.PiDraw
{
    /// <summary>
    /// Represents a class that maps to a single unmanaged resource.
    /// </summary>
    public abstract class NativeResource : IDisposable
    {
        private readonly string name;

        protected NativeResource()
        {
            name = GetType().Name;
        }

        /// <summary>
        /// The handle to the unmanaged pointer.
        /// </summary>
        internal IntPtr Handle { get; set; }

        internal IntPtr HandleOrThrow()
        {
            ThrowIfDisposed();
            return Handle;
        }

        public bool Disposed => Handle == IntPtr.Zero;

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

        ~NativeResource()
        {
            ReleaseUnmanagedResources();
        }
    }
}
