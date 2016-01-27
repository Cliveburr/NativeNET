using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeNET.User32.Notification
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct DevBroadcastDeviceInterfaceStruct
    {
        public int Size;
        public uint DeviceType;
        public uint Reserved;
        public Guid ClassGuid;
        public short Name;
    }
}