using System;
using System.Runtime.InteropServices;

namespace NativeNET.SetupApi.Device
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceInterfaceData
    {
        public int cbSize;
        public Guid InterfaceClassGuid;
        public uint Flags;
        public IntPtr Reserved;
    }
}