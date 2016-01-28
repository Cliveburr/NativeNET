using System;
using System.Runtime.InteropServices;

namespace NativeNET.SetupApi.Device
{
    /// <summary>
    /// The SetupDiGetDeviceRegistryProperty function retrieves a specified Plug and Play device property.
    /// <seealso cref="https://msdn.microsoft.com/en-us/library/windows/hardware/ff551967(v=vs.85).aspx"/>
    /// </summary>
    public static class GetDeviceRegistryProperty
    {
        [DllImport("setupapi.dll", EntryPoint = "SetupDiGetDeviceRegistryProperty")]
        static internal extern bool SetupDiGetDeviceRegistryPropertyMethod(IntPtr deviceInfoSet, ref DeviceInfoData deviceInfoData, int propertyVal, ref int propertyRegDataType, byte[] propertyBuffer, int propertyBufferSize, ref int requiredSize);

        public static string Description(IntPtr deviceInfoSet, DeviceInfoData deviceInfoData)
        {
            var descriptionBuffer = new byte[1024];

            var requiredSize = 0;
            var type = 0;

            SetupDiGetDeviceRegistryPropertyMethod(deviceInfoSet,
                                                   ref deviceInfoData,
                                                   0,
                                                   ref type,
                                                   descriptionBuffer,
                                                   descriptionBuffer.Length,
                                                   ref requiredSize);

            return descriptionBuffer.ToUTF8String();
        }
    }
}