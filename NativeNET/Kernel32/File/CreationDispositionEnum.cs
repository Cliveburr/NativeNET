﻿namespace NativeNET.Kernel32.File
{
    public enum CreationDispositionEnum : uint
    {
        CREATE_NEW = 1,
        CREATE_ALWAYS = 2,
        OPEN_EXISTING = 3,
        OPEN_ALWAYS = 4,
        TRUNCATE_EXISTING = 5
    }
}