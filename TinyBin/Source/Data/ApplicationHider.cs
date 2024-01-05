using System;
using WinAPI;

namespace TinyBin.Source.Data
{
    internal class ApplicationHider
    {
        public static void HideFromAltTab(IntPtr windowHandle)
        {
            User32.SetWindowLong(windowHandle, User32.GWL_EXSTYLE,
                User32.GetWindowLong(windowHandle, User32.GWL_EXSTYLE) |
                User32.WS_EX_TOOLWINDOW);
        }
    }
}
