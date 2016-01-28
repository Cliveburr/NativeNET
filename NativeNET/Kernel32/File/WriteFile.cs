using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace NativeNET.Kernel32.File
{
    public static class WriteFile
    {
        [DllImport("kernel32.dll", EntryPoint = "WriteFile")]
        static internal extern bool WriteFileMethod(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, [In] ref NativeOverlapped lpOverlapped);

        public static bool Write(IntPtr file, byte[] buffer, uint numberOfBytesToWrite, out uint numberOfBytesWritten, ref NativeOverlapped overlapped)
        {
            return WriteFileMethod(file, buffer, numberOfBytesToWrite, out numberOfBytesWritten, ref overlapped);
        }
    }
}