using System.Runtime.InteropServices;

namespace NativeNET.Hid
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Attributes
    {
        public int Size;
        public ushort VendorID;
        public ushort ProductID;
        public short VersionNumber;
    }
}