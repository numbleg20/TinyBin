using System;
using TinyBin.Source.WinAPI;

namespace TinyBin.Source.Data
{
    internal class AltTabHider
    {
        public static void HideFromAltTab(IntPtr windowHandle)
        {
            user32.SetWindowLong(windowHandle, user32.GWL_EXSTYLE, 
                user32.GetWindowLong(windowHandle,user32.GWL_EXSTYLE) |
                user32.WS_EX_TOOLWINDOW);
        }
    }
}
