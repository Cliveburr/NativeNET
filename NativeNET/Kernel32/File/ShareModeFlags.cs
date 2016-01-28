using System;

namespace NativeNET.Kernel32.File
{
    [Flags]
    public enum ShareModeFlags : uint
    {
        O = 0x00000000,
        FILE_SHARE_READ = 0x00000001,
        FILE_SHARE_WRITE = 0x00000002,
        FILE_SHARE_DELETE = 0x00000004
    }
}