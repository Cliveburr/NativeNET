using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeNET.User32.Notification
{
    internal enum Dbch_DeviceType : uint
    {
        DBT_DEVTYP_OEM = 0x00000000,
        DBT_DEVTYP_VOLUME = 0x00000002,
        DBT_DEVTYP_PORT = 0x00000003,
        DBT_DEVTYP_DEVICEINTERFACE = 0x00000005,
        DBT_DEVTYP_HANDLE = 0x00000006
    }
}