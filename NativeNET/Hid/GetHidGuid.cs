using System;
using System.Runtime.InteropServices;

namespace NativeNET.Hid
{
    /// <summary>
    /// The HidD_GetHidGuid routine returns the device interfaceGUID for HIDClass devices.
    /// <seealso cref="https://msdn.microsoft.com/en-us/library/windows/hardware/ff538924(v=vs.85).aspx"/>
    /// </summary>
    public static class GetHidGuid
    {
        [DllImport("hid.dll", EntryPoint = "HidD_GetHidGuid")]
        static internal extern void HidD_GetHidGuidMethod(ref Guid hidGuid);

        private static Guid _hidClassGuid = Guid.Empty;

        public static Guid Run(bool refresh = false)
        {
            if (_hidClassGuid.Equals(Guid.Empty) || refresh)
                HidD_GetHidGuidMethod(ref _hidClassGuid);
            return _hidClassGuid;
        }
    }
}