using System;
using System.Runtime.InteropServices;

namespace NativeNET.SetupApi.Device
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceInfoData
    {
        public int cbSize;
        public Guid ClassGuid;
        public uint DevInst;
        public IntPtr Reserved;
    }
}