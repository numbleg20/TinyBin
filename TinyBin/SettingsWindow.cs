using MaterialSkin.Controls;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyBin.Source.Data;
using TinyBin.Source.Localization;
using WinAPI;

namespace TinyBin
{
    public partial class SettingsWindow : MaterialForm
    {
        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            //Hide window
            ShowInTaskbar = false;
            Hide();
            ApplicationHider.HideFromAltTab(this.Handle);
        }

        static MenuItem EmptyItem;
        static MenuItem OpenFolderItem;
        static string currentBinType;

        public SettingsWindow()
        {
            InitializeComponent();

            Text = Constants.SETTINGS_WINDOW_NAME;

            //Load UI
            LoadUIElements.Load(this);

            //Buttons change state
            materialButton1.Click += (sender, e) =>
            {
                Source.Data.ButtonState.ChangeState(materialButton1);
            };
            materialButton2.Click += (sender, e) =>
            {
                Source.Data.ButtonState.ChangeState(materialButton2);
            };
            materialButton4.Click += (sender, e) =>
            {
                materialButton4.Text = StartupLogic.Logic(materialButton4);
            };
            materialButton5.Click += (sender, e) =>
            {
                Source.Data.ButtonState.ChangeState(materialButton5);
            };
            materialButton6.Click += (sender, e) =>
            {
                Source.Data.ButtonState.ChangeState(materialButton6);
            };

            //Add notification and icon to tray
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ContextMenu = contextMenu1;
            notifyIcon1.BalloonTipText = "Made by @spliffjapan ";
            notifyIcon1.BalloonTipTitle = Constants.APPLICATION_NAME;
            notifyIcon1.ShowBalloonTip(6);
            notifyIcon1.DoubleClick += (sender, e) =>
            {
                if (materialRadioButton1.Checked) Bin.Empty();
                else if (materialRadioButton2.Checked) Bin.OpenFolder();
                else if (materialRadioButton3.Checked) OpenSettings();
                else if (materialRadioButton4.Checked) Application.Exit();
            };

            EmptyItem = contextMenu1.MenuItems.Add("Empty", (sender, e) => Bin.Empty());
            OpenFolderItem = contextMenu1.MenuItems.Add("Open Folder", (sender, e) => Bin.OpenFolder());

            contextMenu1.MenuItems.Add("-");
            contextMenu1.MenuItems.Add("Settings", (sender, e) => OpenSettings());
            contextMenu1.MenuItems.Add("Exit", (sender, e) => { Application.Exit(); });

            //Read settings and Load values form bin file
            BinaryDataReader.SettingsRead();
            materialTextBox1.Text = BinaryDataReader.updateTimeValue.ToString();
            Source.Data.ButtonState.ChangeStateByBool(materialButton1, BinaryDataReader.showEmptyBool);
            Source.Data.ButtonState.ChangeStateByBool(materialButton2, BinaryDataReader.showOpenBool);
            Source.Data.ButtonState.ChangeStateByBool(materialButton6, BinaryDataReader.noConfirmation);
            Source.Data.ButtonState.ChangeStateByBool(materialButton5, BinaryDataReader.noProgressUI);
            materialRadioButton1.Checked = BinaryDataReader.DBLCLICKemptyBin;
            materialRadioButton2.Checked = BinaryDataReader.DBLCLICKopenFolder;
            materialRadioButton3.Checked = BinaryDataReader.DBLCLICKopenSettings;
            materialRadioButton4.Checked = BinaryDataReader.DBLCLICKexit;
            materialComboBox1.Text = BinaryDataReader.LocalizationValue;

            //Apply localization
            LocalizationManager.ChangeLanguage(this, materialComboBox1.Text);

            materialComboBox1.SelectedValueChanged += (sender, e) =>
            {
                LocalizationManager.ChangeLanguage(this, materialComboBox1.Text);
                Startup();
            };

            Startup();

            //Background thread start
            Thread thread = new Thread(BackgroundWork);
            thread.IsBackground = true;
            thread.Start();
        }

        private void OpenSettings()
        {
            CenterToScreen();
            Show();
            TopMost = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            TopMost = true;

            //Write settings
            BinaryDataWriter.WriteToFile(Convert.ToInt32(materialTextBox1.Text),
                Source.Data.ButtonState.ButtonIsActive(materialButton1),
                Source.Data.ButtonState.ButtonIsActive(materialButton2),
                Source.Data.ButtonState.ButtonIsActive(materialButton5),
                Source.Data.ButtonState.ButtonIsActive(materialButton6),
                materialRadioButton1.Checked, materialRadioButton2.Checked,
                materialRadioButton3.Checked, materialRadioButton4.Checked,
                materialComboBox1.Text);

            //Read settings
            BinaryDataReader.SettingsRead();
            Hide();
        }

        void Startup()
        {
            //Startup
            if (!StartupLogic.AddedToStartup())
            {
                materialButton4.Text = LocalizationManager.addToStartup;
                Source.Data.ButtonState.Active(materialButton4);
            }
            else
            {
                materialButton4.Text = LocalizationManager.removeFromStartup;
                Source.Data.ButtonState.Inactive(materialButton4);
            }
        }

        async void BackgroundWork()
        {
            while (true)
            {

                //Change color theme for context menu
                if (Uxtheme.ShouldSystemUseDarkMode()) Uxtheme.SetPreferredAppMode(2);
                else Uxtheme.SetPreferredAppMode(0);
                Uxtheme.FlushMenuThemes();

                //Menu items showing
                if (Source.Data.ButtonState.ButtonIsActive(materialButton1))
                    EmptyItem.Visible = true;
                else EmptyItem.Visible = false;
                if (Source.Data.ButtonState.ButtonIsActive(materialButton2))
                    OpenFolderItem.Visible = true;
                else OpenFolderItem.Visible = false;

                //Change icon and bin type text
                if (Bin.GetCount() == 0)
                {
                    if (Uxtheme.ShouldSystemUseDarkMode())
                        notifyIcon1.Icon =
                            Properties.Resources.emptyWHITE;
                    else if (!Uxtheme.ShouldSystemUseDarkMode())
                        notifyIcon1.Icon =
                            Properties.Resources.emptyDARK;
                    currentBinType = "Empty";
                }
                else
                {
                    if (Uxtheme.ShouldSystemUseDarkMode())
                        notifyIcon1.Icon =
                            Properties.Resources.filledWHITE;
                    else if (!Uxtheme.ShouldSystemUseDarkMode())
                        notifyIcon1.Icon =
                            Properties.Resources.filledDARK;
                    currentBinType = "Filled";
                }

                notifyIcon1.Text = $"{currentBinType}";
                await Task.Delay(BinaryDataReader.updateTimeValue);
            }
        }
    }
}
