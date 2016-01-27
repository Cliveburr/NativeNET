using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeNET.User32.Notification
{
    [Flags]
    public enum RegisterDeviceNotificationFlags : uint
    {
        DEVICE_NOTIFY_WINDOW_HANDLE = 0x00000000,
        DEVICE_NOTIFY_SERVICE_HANDLE = 0x00000001
    }
}