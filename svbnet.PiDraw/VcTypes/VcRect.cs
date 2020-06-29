using System.Drawing;
using System.Runtime.InteropServices;

namespace svbnet.PiDraw.VcTypes
{
    // interface/vctypes/vc_image_types.h
    /// <summary>
    /// Represents a VideoCore rectangle. This type is used across DispManX and other VideoCore APIs.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VcRect
    {
        /// <summary>
        /// Creates a new instance from a <see cref="System.Drawing.Rectangle"/>.
        /// </summary>
        /// <param name="frameworkRectangle">The existing rectangle.</param>
        public VcRect(Rectangle frameworkRectangle)
        {
            X = frameworkRectangle.X;
            Y = frameworkRectangle.Y;
            Width = frameworkRectangle.Width;
            Height = frameworkRectangle.Height;
        }

        /// <summary>
        /// Creates a new instance from the specified X, Y, width and height.
        /// </summary>
        /// <param name="x">The X value</param>
        /// <param name="y">The Y value</param>
        /// <param name="width">The width value</param>
        /// <param name="height">The height value</param>
        public VcRect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int X;

        public int Y;

        public int Width;

        public int Height;

        /// <summary>
        /// Returns a new <see cref="System.Drawing.Rectangle"/> based on this rectangle.
        /// </summary>
        /// <returns></returns>
        public Rectangle ToFrameworkRectangle()
        {
            return new Rectangle(X, Y, Width, Height);
        }
    }
}