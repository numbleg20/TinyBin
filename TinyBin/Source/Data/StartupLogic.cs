using MaterialSkin.Controls;
using Microsoft.Win32;
using System.Linq;
using System.Windows.Forms;
using TinyBin.Source.Localization;

namespace TinyBin.Source.Data
{
    internal class StartupLogic
    {

        public static string Logic(MaterialButton materialForm)
        {
            string sx = null;
            if (AddedToStartup())
            {
                sx = LocalizationManager.addToStartup;
                ButtonState.Active(materialForm);
                RemoveFromStartup();
            }
            else {
                sx = LocalizationManager.removeFromStartup;
                ButtonState.Inactive(materialForm);
                AddToStartup(); 
            }
            return sx;
        }

        static void AddToStartup()
        {
            string appPath = Application.ExecutablePath;

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue(Constants.APPLICATION_NAME, appPath);
            registryKey.Close();
        }

        static void RemoveFromStartup()
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
