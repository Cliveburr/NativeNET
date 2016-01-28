using System;
using System.Runtime.InteropServices;

namespace NativeNET.SetupApi.Device
{
    /// <summary>
    /// The SetupDiGetDeviceProperty function retrieves a device instance property.
    /// <seealso cref="https://msdn.microsoft.com/en-us/library/windows/hardware/ff551963(v=vs.85).aspx"/>
    /// </summary>
    public static class GetDeviceProperty
    {
        [DllImport("setupapi.dll", EntryPoint = "SetupDiGetDevicePropertyW", SetLastError = true)]
        static internal extern bool SetupDiGetDevicePropertyW(IntPtr deviceInfo, ref DeviceInfoData deviceInfoData, ref DevicePropertyKey propkey, ref ulong propertyDataType, byte[] propertyBuffer, int propertyBufferSize, ref int requiredSize, uint flags);

        internal static DevicePropertyKey DevicePropertyKeyDeviceDescription =
            new DevicePropertyKey { fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2), pid = 4 };

        public static string Description(IntPtr deviceInfoSet, DeviceInfoData devInfoData)
        {
            if (Environment.OSVersion.Version.Major > 5)
            {
                var descriptionBuffer = new byte[1024];
                ulong propertyType = 0;
                var requiredSize = 0;

                var has = SetupDiGetDevicePropertyW(deviceInfoSet,
                                                    ref devInfoData,
                                                    ref DevicePropertyKeyDeviceDescription,
                                                    ref propertyType,
                                                    descriptionBuffer,
                                                    descriptionBuffer.Length,
                                                    ref requiredSize,
                                                    0);

                if (has)
                    return descriptionBuffer.ToUTF16String();
                else
                    return null;
            }
            else
                return null;
        }
    }
}