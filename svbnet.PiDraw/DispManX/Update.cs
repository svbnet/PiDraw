using System;
using System.Collections.Generic;
using System.Text;
using svbnet.PiDraw.BcmHost;

namespace svbnet.PiDraw.DispManX
{
    public class Update
    {
        internal uint Handle { get; }

        public Update(int priority)
        {
            Handle = BcmHostNativeMethods.VcDispmanxUpdateStart(priority);
            if (Handle == 0)
            {
                throw new BcmHostException("Invalid handle returned while trying to start update", 0);
            }
        }

        public void SubmitSync()
        {
            var result = BcmHostNativeMethods.VcDispmanxUpdateSubmitSync(Handle);
            if (result != 0)
            {
                throw new BcmHostException("Could not submit update", result);
            }
        }


    }
}
