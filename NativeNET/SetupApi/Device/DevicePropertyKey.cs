using System;
using System.Runtime.InteropServices;

namespace NativeNET.SetupApi.Device
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DevicePropertyKey
    {
        public Guid fmtid;
        public ulong pid;
    }
}