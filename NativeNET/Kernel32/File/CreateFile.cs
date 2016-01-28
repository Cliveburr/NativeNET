using System;
using System.Runtime.InteropServices;

namespace NativeNET.Kernel32.File
{
    /// <summary>
    /// Creates or opens a file or I/O device.
    /// <see cref="https://msdn.microsoft.com/en-us/library/windows/desktop/aa363858(v=vs.85).aspx"/>
    /// </summary>
    public static class CreateFile
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "CreateFile")]
        static internal extern IntPtr CreateFileMethod(string lpFileName, uint dwDesiredAccess, uint dwShareMode, ref SecurityAttributes lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        public static IntPtr Run(string fileName, DesiredAccessFlags desiredAccess, ShareModeFlags shareMode, CreationDispositionEnum creationDisposition, FlagsAndAttributes flagsAndAttributes, IntPtr templateFile)
        {
            //var buffer = IntPtr.Zero;
            var handle = IntPtr.Zero;

            var securityAttributes = new SecurityAttributes
            {
                lpSecurityDescriptor = IntPtr.Zero, //TODO: create other methods to use this
                bInheritHandle = true
            };
            securityAttributes.nLength = Marshal.SizeOf(securityAttributes);

            try
            {
                //buffer = Marshal.AllocHGlobal(securityAttributes.nLength);
                //Marshal.StructureToPtr(securityAttributes, buffer, true);

                handle = CreateFileMethod(fileName, (uint)desiredAccess, (uint)shareMode, ref securityAttributes, (uint)creationDisposition, (uint)flagsAndAttributes, templateFile);
            }
            finally
            {
                //Marshal.FreeHGlobal(buffer);
            }

            return handle;
        }
    }
}