using System;
using System.Runtime.InteropServices;

namespace NativeNET.Hid
{
    public static class GetCapabilities
    {
        [DllImport("hid.dll")]
        static internal extern bool HidD_GetPreparsedData(IntPtr hidDeviceObject, ref IntPtr preparsedData);

        [DllImport("hid.dll")]
        static internal extern int HidP_GetCaps(IntPtr preparsedData, ref Capabilities capabilities);

        [DllImport("hid.dll")]
        static internal extern bool HidD_FreePreparsedData(IntPtr preparsedData);

        public static Capabilities? Get(IntPtr handle)
        {
            var capabilities = new Capabilities();
            var preparsedDataPointer = IntPtr.Zero;

            if (HidD_GetPreparsedData(handle, ref preparsedDataPointer))
            {
                HidP_GetCaps(preparsedDataPointer, ref capabilities);
                HidD_FreePreparsedData(preparsedDataPointer);
                return capabilities;
            }
            else
                return null;
        }
    }
}