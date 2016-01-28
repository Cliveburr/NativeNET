using System;
using System.Runtime.InteropServices;

namespace NativeNET.SetupApi.Device
{
    /// <summary>
    /// The SetupDiGetClassDevs function returns a handle to a device information set that contains requested device information elements for a local computer.
    /// <seealso cref="https://msdn.microsoft.com/en-us/library/windows/hardware/ff551069(v=vs.85).aspx"/>
    /// </summary>
    public static class GetClassDevs
    {
        [DllImport("setupapi.dll", CharSet = CharSet.Auto, EntryPoint = "SetupDiGetClassDevs")]
        static internal extern IntPtr SetupDiGetClassDevs(ref Guid classGuid, string enumerator, IntPtr hwndParent, uint flags);

        [DllImport("setupapi.dll", EntryPoint = "SetupDiDestroyDeviceInfoList")]
        static internal extern int SetupDiDestroyDeviceInfoList(IntPtr deviceInfoSet);

        public static IntPtr GetDeviceInterfacePresentAndEnabled(Guid classGuid, string enumerator, IntPtr handleParent)
        {
            return SetupDiGetClassDevs(ref classGuid, enumerator, handleParent,
                (uint)(GetClassDevsFlags.DIGCF_PRESENT | GetClassDevsFlags.DIGCF_DEVICEINTERFACE));
        }

        public static int Destroy(IntPtr deviceInfoSet)
        {
            return SetupDiDestroyDeviceInfoList(deviceInfoSet);
        }
    }
}