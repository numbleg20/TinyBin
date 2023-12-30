using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TinyBin.Source.Data
{
    internal class Startup
    {
        public static void AddToStartup()
        {
            string appPath = Application.ExecutablePath;

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue(Constants.APPLICATION_NAME, appPath);
            registryKey.Close();
        }

        public static void RemoveFromStartup()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (registryKey != null)
            {
                registryKey.DeleteValue(Constants.APPLICATION_NAME, false);
                registryKey.Close();
            }
        }
        public static bool AddedToStartup()
        {
            return (Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",
                    true).GetValueNames().Contains(Constants.APPLICATION_NAME));
        }
    }
}
