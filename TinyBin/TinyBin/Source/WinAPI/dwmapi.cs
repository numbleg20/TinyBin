using System;
using System.Runtime.InteropServices;

namespace TinyBin.Source.WinAPI
{

    internal class dwmapi
    {
        private const uint DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        static extern void DwmSetWindowAttribute(IntPtr hwnd,
                                                uint attribute,
                                                ref int pvAttribute,
                                                uint cbAttribute);
        public static void SetTitleBarTheme(IntPtr handle)
        {
            var preference = Convert.ToInt32(true);
            DwmSetWindowAttribute(handle,
                                  DWMWA_USE_IMMERSIVE_DARK_MODE,
                                  ref preference, sizeof(uint));
        }
    }
}
