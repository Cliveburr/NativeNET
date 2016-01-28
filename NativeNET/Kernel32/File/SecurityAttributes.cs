using System;
using System.Runtime.InteropServices;

namespace NativeNET.Kernel32.File
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SecurityAttributes
    {
        public int nLength;
        public IntPtr lpSecurityDescriptor;
        public bool bInheritHandle;
    }
}