using System;
using System.Runtime.InteropServices;

namespace NativeNET.Kernel32.Handle
{
    /// <summary>
    /// Closes an open object handle.
    /// <seealso cref="https://msdn.microsoft.com/pt-br/library/windows/desktop/ms724211(v=vs.85).aspx"/>
    /// </summary>
    public static class CloseHandle
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto, EntryPoint = "CloseHandle")]
        static internal extern bool CloseHandleMethod(IntPtr hObject);

        public static bool Run(IntPtr handle)
        {
            return CloseHandleMethod(handle);
        }
    }
}