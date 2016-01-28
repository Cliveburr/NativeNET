using System;
using System.Runtime.InteropServices;

namespace NativeNET.Kernel32.File
{
    /// <summary>
    /// Marks any outstanding I/O operations for the specified file handle.
    /// <seealso cref="https://msdn.microsoft.com/pt-br/library/windows/desktop/aa363792(v=vs.85).aspx"/>
    /// </summary>
    public static class CancelIoEx
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto, EntryPoint = "CancelIoEx")]
        static internal extern bool CancelIoExMethod(IntPtr hFile, IntPtr lpOverlapped);


        public static bool Run(IntPtr file, IntPtr overlapped)
        {
            return CancelIoExMethod(file, overlapped);
        }
    }
}