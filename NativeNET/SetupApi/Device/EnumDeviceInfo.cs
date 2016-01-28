using System;
using System.Runtime.InteropServices;

namespace NativeNET.SetupApi.Device
{
    /// <summary>
    /// The SetupDiEnumDeviceInfo function returns a SP_DEVINFO_DATA structure that specifies a device information element in a device information set.
    /// <seealso cref="https://msdn.microsoft.com/en-us/library/windows/hardware/ff551010(v=vs.85).aspx"/>
    /// </summary>
    public static class EnumDeviceInfo
    {
        [DllImport("setupapi.dll", EntryPoint = "SetupDiEnumDeviceInfo")]
        static internal extern bool SetupDiEnumDeviceInfo(IntPtr deviceInfoSet, uint memberIndex, ref DeviceInfoData deviceInfoData);

        [DllImport("setupapi.dll", EntryPoint = "SetupDiEnumDeviceInterfaces")]
        static internal extern bool SetupDiEnumDeviceInterfaces(IntPtr deviceInfoSet, ref DeviceInfoData deviceInfoData, ref Guid interfaceClassGuid, uint memberIndex, ref DeviceInterfaceData deviceInterfaceData);

        public static void ForEach(IntPtr deviceInfoSet, Guid hidClass, Action<DeviceInfoData, DeviceInterfaceData> action)
        {
            var deviceInfoData = new DeviceInfoData
            {
                DevInst = 0,
                ClassGuid = Guid.Empty,
                Reserved = IntPtr.Zero
            };
            deviceInfoData.cbSize = Marshal.SizeOf(deviceInfoData);

            uint deviceIndex = 0;
            while (SetupDiEnumDeviceInfo(deviceInfoSet, deviceIndex, ref deviceInfoData))
            {
                deviceIndex += 1;

                var deviceInterfaceData = new DeviceInterfaceData
                {
                    Flags = 0,
                    InterfaceClassGuid = Guid.Empty,
                    Reserved = IntPtr.Zero
                };
                deviceInterfaceData.cbSize = Marshal.SizeOf(deviceInterfaceData);

                uint deviceInterfaceIndex = 0;
                while (SetupDiEnumDeviceInterfaces(deviceInfoSet, ref deviceInfoData, ref hidClass, deviceInterfaceIndex, ref deviceInterfaceData))
                {
                    deviceInterfaceIndex++;

                    action(deviceInfoData, deviceInterfaceData);
                }
            }
        }
    }
}