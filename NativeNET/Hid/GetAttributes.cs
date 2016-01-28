using System;
using System.Runtime.InteropServices;

namespace NativeNET.Hid
{
    /// <summary>
    /// The HidD_GetAttributes routine returns the attributes of a specified top-level collection.
    /// <seealso cref="https://msdn.microsoft.com/en-us/library/windows/hardware/ff538900(v=vs.85).aspx"/>
    /// </summary>
    public static class GetAttributes
    {
        [DllImport("hid.dll", EntryPoint = "HidD_GetAttributes")]
        static internal extern bool HidD_GetAttributes(IntPtr hidDeviceObject, ref Attributes attributes);

        public static Attributes? Get(IntPtr handle)
        {
            var deviceAttributes = new Attributes();
            deviceAttributes.Size = Marshal.SizeOf(deviceAttributes);
            if (HidD_GetAttributes(handle, ref deviceAttributes))
                return deviceAttributes;
            else
                return null;
        }
    }
}