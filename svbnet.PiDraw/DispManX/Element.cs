using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using svbnet.PiDraw.BcmHost;
using svbnet.PiDraw.VcTypes;

namespace svbnet.PiDraw.DispManX
{
    public class Element
    {
        internal uint Handle { get; }

        public Element(Update update, Display display, int layer, VcRect destRect, Resource src, VcRect srcRect,
            Protection protection, VcAlpha alpha, Clamp clamp, Transform transform)
        {
            Handle = BcmHostNativeMethods.VcDispmanxElementAdd(update.Handle, display.Handle, layer, ref destRect,
                src.Handle, ref srcRect, protection, alpha, clamp, transform);
            if (Handle == 0)
            {
                throw new InvalidHandleException("Could not create new element");
            }
        }

        public void Remove(Update update)
        {
            var result = BcmHostNativeMethods.VcDispmanxElementRemove(update.Handle, Handle);
            if (result != 0)
            {
                throw new BcmHostException("Could not remove element", result);
            }
        }
        
    }
}
