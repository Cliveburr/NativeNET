using System;
using System.Runtime.InteropServices;

namespace NativeNET.SetupApi.Device
{
    /// <summary>
    /// The SetupDiGetDeviceInterfaceDetail function returns details about a device interface.
    /// <seealso cref="https://msdn.microsoft.com/en-us/library/windows/hardware/ff551120(v=vs.85).aspx"/>
    /// </summary>
    public static class GetDeviceInterfaceDetail
    {
        [DllImport("setupapi.dll", CharSet = CharSet.Auto, EntryPoint = "SetupDiGetDeviceInterfaceDetail")]
        static internal extern bool SetupDiGetDeviceInterfaceDetailBuffer(IntPtr deviceInfoSet, ref DeviceInterfaceData deviceInterfaceData, IntPtr deviceInterfaceDetailData, int deviceInterfaceDetailDataSize, ref int requiredSize, IntPtr deviceInfoData);

        [DllImport("setupapi.dll", CharSet = CharSet.Auto, EntryPoint = "SetupDiGetDeviceInterfaceDetail")]
        static internal extern bool SetupDiGetDeviceInterfaceDetailMethod(IntPtr deviceInfoSet, ref DeviceInterfaceData deviceInterfaceData, ref DeviceInterfaceDetailData deviceInterfaceDetailData, int deviceInterfaceDetailDataSize, ref int requiredSize, IntPtr deviceInfoData);

        public static DeviceInterfaceDetailData? Run(IntPtr deviceInfoSet, DeviceInterfaceData deviceInterfaceData)
        {
            var bufferSize = 0;
            var interfaceDetail = new DeviceInterfaceDetailData
            {
                Size = IntPtr.Size == 4 ? 4 + Marshal.SystemDefaultCharSize : 8
            };

            SetupDiGetDeviceInterfaceDetailBuffer(deviceInfoSet, ref deviceInterfaceData, IntPtr.Zero, 0, ref bufferSize, IntPtr.Zero);

            if (SetupDiGetDeviceInterfaceDetailMethod(
                deviceInfoSet,
                ref deviceInterfaceData,
                ref interfaceDetail,
                bufferSize,
                ref bufferSize, IntPtr.Zero))
                return interfaceDetail;
            else
                return null;
        }
    }
}