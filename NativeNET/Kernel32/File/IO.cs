using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace NativeNET.Kernel32.File
{
    public static class IO
    {
        [DllImport("kernel32.dll", EntryPoint = "WriteFile", SetLastError = true)]
        static internal extern bool WriteFileMethod(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, [In] ref NativeOverlapped lpOverlapped);

        [DllImport("kernel32.dll", EntryPoint = "ReadFile", SetLastError = true)]
        static internal extern bool ReadFileMethod(IntPtr hFile, [Out] byte[] lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, [In] ref NativeOverlapped lpOverlapped);

        public static bool Write(IntPtr file, byte[] buffer, uint numberOfBytesToWrite, out uint numberOfBytesWritten, ref NativeOverlapped overlapped)
        {
            return WriteFileMethod(file, buffer, numberOfBytesToWrite, out numberOfBytesWritten, ref overlapped);
        }

        public static bool Read(IntPtr file, byte[] buffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, ref NativeOverlapped overlapped)
        {
            return ReadFileMethod(file, buffer, nNumberOfBytesToRead, out lpNumberOfBytesRead, ref overlapped);
        }
    }
}