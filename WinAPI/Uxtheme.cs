using System.Runtime.InteropServices;

namespace WinAPI
{
    public class Uxtheme
    {
        [DllImport("uxtheme.dll", EntryPoint = "#135", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int SetPreferredAppMode(int preferredAppMode);

        [DllImport("uxtheme.dll", EntryPoint = "#136", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern void FlushMenuThemes();

        [DllImport("uxtheme.dll", EntryPoint = "#138", SetLastError = true)]
        public static extern bool ShouldSystemUseDarkMode();
    }
}
