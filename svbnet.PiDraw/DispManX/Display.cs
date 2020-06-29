using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using svbnet.PiDraw.BcmHost;
using svbnet.PiDraw.VcTypes;

namespace svbnet.PiDraw.DispManX
{
    public class Display : HandleResource
    {
        private readonly VcRect rect = new VcRect();
        private readonly ModeInfo modeInfo = new ModeInfo();

        /// <summary>
        /// Creates a new Display instance.
        /// </summary>
        /// <param name="device">The display device to open.</param>
        public Display(uint device)
        {
            Handle = BcmHostNativeMethods.VcDispmanxDisplayOpen(device);
            if (Handle == 0)
            {
                throw new InvalidHandleException("Could not open display");
            }

            int error;
            if ((error = BcmHostNativeMethods.VcDispmanxDisplayGetInfo(Handle, ref modeInfo)) != 0)
            {
                throw new BcmHostException("Could not get display info", error);
            }
            rect.Width = modeInfo.Width;
            rect.Height = modeInfo.Height;
        }

        /// <summary>
        /// Creates a new Display instance using a known display ID.
        /// </summary>
        /// <param name="device">The display device to open.</param>
        public Display(DefaultDisplayId device) : this((uint)device)
        {
        }

        /// <summary>
        /// The rectangle for this display.
        /// </summary>
        public VcRect Rectangle => new VcRect(0, 0, rect.Width, rect.Height);

        /// <summary>
        /// The current transform for this display.
        /// </summary>
        public Transform Transform => modeInfo.Transform;

        /// <summary>
        /// Takes a snapshot of this display and stores it in a resource.
        /// </summary>
        /// <param name="snapshotResource">The resource to save to.</param>
        public void TakeSnapshot(Resource snapshotResource)
        {
            // See https://github.com/AndrewFromMelbourne/raspi2png/blob/master/raspi2png.c
            // Transform parameter should always be NO_ROTATE for some reason...
            var result = BcmHostNativeMethods.VcDispmanxSnapshot(Handle, snapshotResource.Handle, Transform.NoRotate);
            if (result != 0)
            {
                throw new BcmHostException("Could not take snapshot", result);
            }
        }

        /// <summary>
        /// Sets the background color of this display.
        /// </summary>
        /// <param name="update">The update to use.</param>
        /// <param name="color">The color to set the background to. The alpha component is ignored.</param>
        public void SetBackgroundColor(Update update, Color color)
        {
            var result =
                BcmHostNativeMethods.VcDispmanxDisplaySetBackground(update.Handle, Handle, color.R, color.G, color.B);
            if (result != 0)
            {
                throw new BcmHostException("Could not set background color", result);
            }
        }

        protected override void Free()
        {
            BcmHostNativeMethods.VcDispmanxDisplayClose(Handle);
            Handle = 0;
        }
    }
}
