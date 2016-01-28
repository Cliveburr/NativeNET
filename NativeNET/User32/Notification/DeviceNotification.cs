using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NativeNET.User32.Notification
{
    public static class DeviceNotification
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, EntryPoint = "RegisterDeviceNotification")]
        static internal extern IntPtr RegisterDeviceNotificationMethod(IntPtr recipient, IntPtr notificationFilter, uint flags);

        [DllImport("user32.dll", EntryPoint = "UnregisterDeviceNotification")]
        static internal extern bool UnregisterDeviceNotificationMethod(IntPtr handle);

        public static IntPtr Register(IntPtr hRecipient, Guid classGuid, RegisterDeviceNotificationFlags flags)
        {
            var buffer = IntPtr.Zero;
            var handle = IntPtr.Zero;

            var notificationFilter = new DevBroadcastDeviceInterfaceStruct
            {
                DeviceType = (uint)Dbch_DeviceType.DBT_DEVTYP_DEVICEINTERFACE,
                Reserved = 0,
                ClassGuid = classGuid,
                Name = 0 //TODO: pass from arguments
            };
            notificationFilter.Size = Marshal.SizeOf(notificationFilter);

            try
            {
                buffer = Marshal.AllocHGlobal(notificationFilter.Size);
                Marshal.StructureToPtr(notificationFilter, buffer, true);

                handle = RegisterDeviceNotificationMethod(hRecipient, buffer, (uint)flags);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }

            return handle;
        }

        public static bool Unregister(IntPtr handle)
        {
            return UnregisterDeviceNotificationMethod(handle);
        }
    }
}