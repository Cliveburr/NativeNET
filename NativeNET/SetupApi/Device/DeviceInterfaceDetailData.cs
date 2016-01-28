using System.Runtime.InteropServices;

namespace NativeNET.SetupApi.Device
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DeviceInterfaceDetailData
    {
        public int Size;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string DevicePath;
    }
}