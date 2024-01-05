namespace TinyBin.Source.Localization
{
    internal class LocalizationManager
    {
        public static string addToStartup;
        public static string removeFromStartup;

        public static void ChangeLanguage(SettingsWindow settingsWindow, string value)
        {
            switch(value)
            {
                case "Chinese":
                    zh(settingsWindow);
                    break;

                case "English":
                    en(settingsWindow);
                    break;

                case "Italian":
                    it(settingsWindow);
                    break;

                case "French":
                    fr(settingsWindow);
                    break;

                case "Ukrainian":
                    ua(settingsWindow);
                    break;
            }
        }

        static void zh(SettingsWindow settingsWindow)
        {
            settingsWindow.materialLabel2.Text = zh_ZH.PERFORMANCE;
            settingsWindow.materialLabel1.Text = zh_ZH.UPD_TIME;
            settingsWindow.materialLabel6.Text = zh_ZH.TIDCE;
            settingsWindow.materialRadioButton1.Text = zh_ZH.EMPTY;
            settingsWindow.materialRadioButton2.Text = zh_ZH.OPEN_FOLDER;
            settingsWindow.materialRadioButton3.Text = zh_ZH.OPEN_SETTINGS;
            settingsWindow.materialRadioButton4.Text = zh_ZH.EXIT;
            settingsWindow.materialLabel3.Text = zh_ZH.MENU_ITEMS;
            settingsWindow.materialButton1.Text = zh_ZH.EMPTY;
            settingsWindow.materialButton2.Text = zh_ZH.OPEN_FOLDER;
            settingsWindow.materialButton3.Text = zh_ZH.SAVE;
            addToStartup = zh_ZH.ADD_TO_STARTUP;
            removeFromStartup = zh_ZH.REMOVE_FROM_STARTUP;
            settingsWindow.materialLabel4.Text = zh_ZH.STARTUP;
            settingsWindow.materialLabel5.Text = zh_ZH.DELETION_PROCESS;
            settingsWindow.materialButton5.Text = zh_ZH.NOCONFIRMATION;
            settingsWindow.materialButton6.Text = zh_ZH.NOPROGRESSUI;
            settingsWindow.contextMenu1.MenuItems[0].Text = zh_ZH.EMPTY;
            settingsWindow.contextMenu1.MenuItems[1].Text = zh_ZH.OPEN_FOLDER;
            settingsWindow.contextMenu1.MenuItems[3].Text = zh_ZH.SETTINGS;
            settingsWindow.contextMenu1.MenuItems[4].Text = zh_ZH.EXIT;
        }

        static void en(SettingsWindow settingsWindow)
        { 
            settingsWindow.materialLabel2.Text = en_EN.PERFORMANCE;
            settingsWindow.materialLabel1.Text = en_EN.UPD_TIME;
            settingsWindow.materialLabel6.Text = en_EN.TIDCE;
            settingsWindow.materialRadioButton1.Text = en_EN.EMPTY;
            settingsWindow.materialRadioButton2.Text = en_EN.OPEN_FOLDER;
            settingsWindow.materialRadioButton3.Text = en_EN.OPEN_SETTINGS;
            settingsWindow.materialRadioButton4.Text = en_EN.EXIT;
            settingsWindow.materialLabel3.Text = en_EN.MENU_ITEMS;
            settingsWindow.materialButton1.Text = en_EN.EMPTY;
            settingsWindow.materialButton2.Text = en_EN.OPEN_FOLDER;
            settingsWindow.materialButton3.Text = en_EN.SAVE;
            addToStartup = en_EN.ADD_TO_STARTUP;
            removeFromStartup = en_EN.REMOVE_FROM_STARTUP;
            settingsWindow.materialLabel4.Text = en_EN.STARTUP;
            settingsWindow.materialLabel5.Text = en_EN.DELETION_PROCESS;
            settingsWindow.materialButton5.Text = en_EN.NOCONFIRMATION;
            settingsWindow.materialButton6.Text = en_EN.NOPROGRESSUI;
            settingsWindow.contextMenu1.MenuItems[0].Text = en_EN.EMPTY;
            settingsWindow.contextMenu1.MenuItems[1].Text = en_EN.OPEN_FOLDER;
            settingsWindow.contextMenu1.MenuItems[3].Text = en_EN.SETTINGS;
            settingsWindow.contextMenu1.MenuItems[4].Text = en_EN.EXIT;
        }

        static void ua(SettingsWindow settingsWindow)
        {
            settingsWindow.materialLabel2.Text = ua_UA.PERFORMANCE;
            settingsWindow.materialLabel1.Text = ua_UA.UPD_TIME;
            settingsWindow.materialLabel6.Text = ua_UA.TIDCE;
            settingsWindow.materialRadioButton1.Text = ua_UA.EMPTY;
            settingsWindow.materialRadioButton2.Text = ua_UA.OPEN_FOLDER;
            settingsWindow.materialRadioButton3.Text = ua_UA.OPEN_SETTINGS;
            settingsWindow.materialRadioButton4.Text = ua_UA.EXIT;
            settingsWindow.materialLabel3.Text = ua_UA.MENU_ITEMS;
            settingsWindow.materialButton1.Text = ua_UA.EMPTY;
            settingsWindow.materialButton2.Text = ua_UA.OPEN_FOLDER;
            settingsWindow.materialButton3.Text = ua_UA.SAVE;
            addToStartup = ua_UA.ADD_TO_STARTUP;
            removeFromStartup = ua_UA.REMOVE_FROM_STARTUP;
            settingsWindow.materialLabel4.Text = ua_UA.STARTUP;
            settingsWindow.materialLabel5.Text = ua_UA.DELETION_PROCESS;
            settingsWindow.materialButton5.Text = ua_UA.NOCONFIRMATION;
            settingsWindow.materialButton6.Text = ua_UA.NOPROGRESSUI;
            settingsWindow.contextMenu1.MenuItems[0].Text = ua_UA.EMPTY;
            settingsWindow.contextMenu1.MenuItems[1].Text = ua_UA.OPEN_FOLDER;
            settingsWindow.contextMenu1.MenuItems[3].Text = ua_UA.SETTINGS;
            settingsWindow.contextMenu1.MenuItems[4].Text = ua_UA.EXIT;
        }
        static void fr(SettingsWindow settingsWindow)
        {
            settingsWindow.materialLabel2.Text = fr_FR.PERFORMANCE;
            settingsWindow.materialLabel1.Text = fr_FR.UPD_TIME;
            settingsWindow.materialLabel6.Text = fr_FR.TIDCE;
            settingsWindow.materialRadioButton1.Text = fr_FR.EMPTY;
            settingsWindow.materialRadioButton2.Text = fr_FR.OPEN_FOLDER;
            settingsWindow.materialRadioButton3.Text = fr_FR.OPEN_SETTINGS;
            settingsWindow.materialRadioButton4.Text = fr_FR.EXIT;
            settingsWindow.materialLabel3.Text = fr_FR.MENU_ITEMS;
            settingsWindow.materialButton1.Text = fr_FR.EMPTY;
            settingsWindow.materialButton2.Text = fr_FR.OPEN_FOLDER;
            settingsWindow.materialButton3.Text = fr_FR.SAVE;
            addToStartup = fr_FR.ADD_TO_STARTUP;
            removeFromStartup = fr_FR.REMOVE_FROM_STARTUP;
            settingsWindow.materialLabel4.Text = fr_FR.STARTUP;
            settingsWindow.materialLabel5.Text = fr_FR.DELETION_PROCESS;
            settingsWindow.materialButton5.Text = fr_FR.NOCONFIRMATION;
            settingsWindow.materialButton6.Text = fr_FR.NOPROGRESSUI;
            settingsWindow.contextMenu1.MenuItems[0].Text = fr_FR.EMPTY;
            settingsWindow.contextMenu1.MenuItems[1].Text = fr_FR.OPEN_FOLDER;
            settingsWindow.contextMenu1.MenuItems[3].Text = fr_FR.SETTINGS;
            settingsWindow.contextMenu1.MenuItems[4].Text = fr_FR.EXIT;
        }
        static void it(SettingsWindow settingsWindow)
        {
            settingsWindow.materialLabel2.Text = it_IT.PERFORMANCE;
            settingsWindow.materialLabel1.Text = it_IT.UPD_TIME;
            settingsWindow.materialLabel6.Text = it_IT.TIDCE;
            settingsWindow.materialRadioButton1.Text = it_IT.EMPTY;
            settingsWindow.materialRadioButton2.Text = it_IT.OPEN_FOLDER;
            settingsWindow.materialRadioButton3.Text = it_IT.OPEN_SETTINGS;
            settingsWindow.materialRadioButton4.Text = it_IT.EXIT;
            settingsWindow.materialLabel3.Text = it_IT.MENU_ITEMS;
            settingsWindow.materialButton1.Text = it_IT.EMPTY;
            settingsWindow.materialButton2.Text = it_IT.OPEN_FOLDER;
            settingsWindow.materialButton3.Text = it_IT.SAVE;
            addToStartup = it_IT.ADD_TO_STARTUP;
            removeFromStartup = it_IT.REMOVE_FROM_STARTUP;
            settingsWindow.materialLabel4.Text = it_IT.STARTUP;
            settingsWindow.materialLabel5.Text = it_IT.DELETION_PROCESS;
            settingsWindow.materialButton5.Text = it_IT.NOCONFIRMATION;
            settingsWindow.materialButton6.Text = it_IT.NOPROGRESSUI;
            settingsWindow.contextMenu1.MenuItems[0].Text = fr_FR.EMPTY;
            settingsWindow.contextMenu1.MenuItems[1].Text = fr_FR.OPEN_FOLDER;
            settingsWindow.contextMenu1.MenuItems[3].Text = fr_FR.SETTINGS;
            settingsWindow.contextMenu1.MenuItems[4].Text = fr_FR.EXIT;
        }
    }
}
