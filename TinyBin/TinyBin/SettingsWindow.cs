using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyBin.Source.Data;
using TinyBin.Source.WinAPI;

namespace TinyBin
{
    public partial class SettingsWindow : Form
    {
        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            //Hide window
            ShowInTaskbar = false;
            Hide();
            AltTabHider.HideFromAltTab(this.Handle);

            //Dark Theme for title bar 
            dwmapi.SetTitleBarTheme(this.Handle);
        }

        static MenuItem EmptyItem;
        static MenuItem OpenFolderItem;
        static string currentBinType;

        public SettingsWindow()
        {
            InitializeComponent();

            //Load Fonts
            FontsManager.AddFontFile(Properties.Resources.Rubik_VariableFont_wght);
            label1.Font = new Font(FontsManager.pfc.Families[0], 8);
            SaveButton.Font = new Font(FontsManager.pfc.Families[0], 8);
            textBox1.Font = new Font(FontsManager.pfc.Families[0], 8);
            groupBox1.Font = new Font(FontsManager.pfc.Families[0], 8);
            groupBox2.Font = new Font(FontsManager.pfc.Families[0], 8);
            checkBox1.Font = new Font(FontsManager.pfc.Families[0], 8);
            checkBox2.Font = new Font(FontsManager.pfc.Families[0], 8);
            button1.Font = new Font(FontsManager.pfc.Families[0], 8);

            //Add notification and icon to tray
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ContextMenu = contextMenu;
            notifyIcon1.BalloonTipText = "Made by @swirlz ";
            notifyIcon1.BalloonTipTitle = Constants.APPLICATION_NAME;
            notifyIcon1.ShowBalloonTip(5);
            notifyIcon1.DoubleClick += (sender, e) => { Bin.Empty(); };

            EmptyItem = contextMenu.MenuItems.Add("Empty", (sender, e) => Bin.Empty());
            OpenFolderItem = contextMenu.MenuItems.Add("Open Folder", (sender, e) => Bin.OpenFolder());

            contextMenu.MenuItems.Add("-");
            contextMenu.MenuItems.Add("Settings", (sender, e) => { Show(); TopMost = true; });
            contextMenu.MenuItems.Add("Exit", (sender,e) => { Application.Exit(); });

            //background thread start
            Thread thread = new Thread(BackgroundWork);
            thread.IsBackground = true;
            thread.Start();

            //Startup logic
            button1.Click += (sender, e) =>
            {
                if (button1.Text.Contains("Add to startup")) Startup.AddToStartup();
                else if (button1.Text.Contains("Remove from startup"))
                    Startup.RemoveFromStartup();
            };

            //Read settings and Load values form bin file
            BinaryDataReader.SettingsRead();
            textBox1.Text = BinaryDataReader.updateTimeValue.ToString();
            checkBox1.Checked = BinaryDataReader.showEmptyBool;
            checkBox2.Checked = BinaryDataReader.showOpenBool;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            TopMost = true;

            //Write settings
            BinaryDataWriter.WriteToFile(Convert.ToInt32(textBox1.Text), 
                checkBox1.Checked, checkBox2.Checked, 
                checkBox3.Checked, checkBox4.Checked);

            //Read settings
            BinaryDataReader.SettingsRead();
            Hide();
        }

        async void BackgroundWork()
        {
            while (true)
            {
                //Change color theme for context menu
                if (uxtheme.ShouldSystemUseDarkMode()) uxtheme.SetPreferredAppMode(2);
                else uxtheme.SetPreferredAppMode(0);
                uxtheme.FlushMenuThemes();

                //Menu items showing
                if (checkBox1.Checked) EmptyItem.Visible = true;
                else EmptyItem.Visible = false;
                if (checkBox2.Checked) OpenFolderItem.Visible = true;
                else OpenFolderItem.Visible = false;

                //Startup
                if (!Startup.AddedToStartup()) button1.Text = "Add to startup";
                else button1.Text = "Remove from startup";

                //Change icon and bin type text
                if (Bin.GetCount() == 0)
                {
                    if (uxtheme.ShouldSystemUseDarkMode()) notifyIcon1.Icon = 
                            Properties.Resources.emptyWHITE;
                    else if (!uxtheme.ShouldSystemUseDarkMode()) notifyIcon1.Icon = 
                            Properties.Resources.emptyDARK;
                    currentBinType = "Empty";
                }
                else
                {
                    if (uxtheme.ShouldSystemUseDarkMode()) notifyIcon1.Icon = 
                            Properties.Resources.filledWHITE;
                    else if (!uxtheme.ShouldSystemUseDarkMode()) notifyIcon1.Icon = 
                            Properties.Resources.filledDARK;
                    currentBinType = "Filled";
                }
                notifyIcon1.Text = $"{currentBinType}";
                
                await Task.Delay(BinaryDataReader.updateTimeValue);
            }
        }
    }
}
