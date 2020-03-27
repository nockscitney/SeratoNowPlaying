//  System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
//  Logic
using NickScotney.SeratoNowPlaying.Logic.Controllers;
using NickScotney.SeratoNowPlaying.Logic.Models;

namespace NickScotney.SeratoNowPlaying.UI
{
    public partial class FrmMain : Form
    {
        bool isRunning;
        List<Setting> settingsList;
        Thread workerThread;

        public FrmMain()
        {
            InitializeComponent();

            settingsList = null;

            BtnBrowseCurrent.Click += (sender, EventArgs) => { BtnBrowse_Click(sender, EventArgs, TxtBxCurrentTrack); };
            BtnBrowsePrevious.Click += (sender, EventArgs) => { BtnBrowse_Click(sender, EventArgs, TxtBxPreviousTrack); };
            TxtBxCurrentTrack.Click += (sender, EventArgs) => { BtnBrowse_Click(sender, EventArgs, TxtBxCurrentTrack); };
            TxtBxPreviousTrack.Click += (sender, EventArgs) => { BtnBrowse_Click(sender, EventArgs, TxtBxPreviousTrack); };
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            isRunning = false;
            settingsList = SettingController.LoadSettings();

            if ((settingsList == null) || settingsList.Count == 0)
            {
                MessageBox.Show("There was an error loading the settings file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            //  Let's check the settings and set the values here
            //  Parse Time
            var setting = settingsList.First(set => set.SettingName == "ParseTime");

            if (setting != null)
                TxtBxParseTime.Text = setting.SettingValue;
            else
                settingsList.Add(new Setting { SettingName = "ParseTime", SettingValue = "10000" });

            //  Parse Address
            setting = settingsList.First(set => set.SettingName == "ParseAddress");

            if (setting != null)
            {
                TxtBxFeedLocation.Text = setting.SettingValue;
                FileController.SetParseAddress(setting.SettingValue);
            }
            else
                settingsList.Add(new Setting { SettingName = "ParseAddress", SettingValue = "" });

            //  Current Track
            setting = settingsList.First(set => set.SettingName == "CurrentTrackLabelFile");

            if (setting != null)
                TxtBxCurrentTrack.Text = setting.SettingValue;
            else
                settingsList.Add(new Setting { SettingName = "CurrentTrackLabelFile", SettingValue = "" });

            //  Enable Previous Track
            setting = settingsList.First(set => set.SettingName == "EnablePreviousTrackLabel");

            if (setting != null)
                ChkBxPreviousTrack.Checked = Boolean.Parse(setting.SettingValue);
            
            else
                settingsList.Add(new Setting { SettingName = "EnablePreviousTrackLabel", SettingValue = "False" });

            //  Previous Track
            setting = settingsList.First(set => set.SettingName == "PreviousTrackLabelFile");

            if ((setting != null) && ChkBxPreviousTrack.Checked)
                TxtBxPreviousTrack.Text = setting.SettingValue;
            else if (setting == null)
                settingsList.Add(new Setting { SettingName = "PreviousTrackLabelFile", SettingValue = "" });
        }

        private void BtnBrowse_Click(object sender, EventArgs e, TextBox textBox)
        {
            var ofd = new OpenFileDialog {
                Filter = "txt files(*.txt) | *.txt",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (ofd.ShowDialog() == DialogResult.OK)
                textBox.Text = ofd.FileName;

            ofd.Dispose();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                if (MessageBox.Show("Parser is currenly running.  Are you sure you want to quit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                workerThread.Abort();
            }
            
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //  Parse Time
            var setting = settingsList.First(set => set.SettingName == "ParseTime");
            setting.SettingValue = TxtBxParseTime.Text;

            //  Parse Address
            setting = settingsList.First(set => set.SettingName == "ParseAddress");
            setting.SettingValue = TxtBxFeedLocation.Text;

            //  Current Track
            setting = settingsList.First(set => set.SettingName == "CurrentTrackLabelFile");
            setting.SettingValue = TxtBxCurrentTrack.Text;

            //  Previous Track Enabled
            setting = settingsList.First(set => set.SettingName == "EnablePreviousTrackLabel");
            setting.SettingValue = ChkBxPreviousTrack.Checked.ToString();

            //   Previous Track
            setting = settingsList.First(set => set.SettingName == "PreviousTrackLabelFile");
            setting.SettingValue = TxtBxPreviousTrack.Text;

            switch (SettingController.SaveSettings(settingsList))
            {
                case 0:
                    MessageBox.Show("Settings Saved");
                    FileController.SetParseAddress(TxtBxFeedLocation.Text);
                    break;
                case 1:
                    MessageBox.Show("Unable to save - No Folder Path defined");
                    break;
                case 2:
                    MessageBox.Show("Unable to save - No settings file found");
                    break;
                case 3:
                    MessageBox.Show("An error occured while saving the settings file");
                    break;
            }
        }

        private void ChkBxPreviousTrack_CheckedChanged(object sender, EventArgs e)
        {
            BtnBrowsePrevious.Enabled = ChkBxPreviousTrack.Checked;

            if (!ChkBxPreviousTrack.Checked)
                TxtBxPreviousTrack.Text = String.Empty;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                GrpBxCurrentTrack.Enabled = false;
                GrpBxLocation.Enabled = false;
                GrpBxParseTime.Enabled = false;
                GrpBxPreviousTrack.Enabled = false;

                BtnStart.Text = "Stop";
                BtnSave.Enabled = false;

                isRunning = true;

                workerThread = new Thread(new ThreadStart(WorkerThreadMethod));
                workerThread.Start();
            }
            else
            {
                GrpBxCurrentTrack.Enabled = true;
                GrpBxLocation.Enabled = true;
                GrpBxParseTime.Enabled = true;
                GrpBxPreviousTrack.Enabled = true;

                BtnStart.Text = "Start";
                BtnSave.Enabled = true;

                workerThread.Abort();
                isRunning = false;
            }
        }

        private void TxtBxParseTime_KeyPress(object sender, KeyPressEventArgs e)
            => e.Handled = (!Char.IsNumber(e.KeyChar)) && !Char.IsControl(e.KeyChar);


        void WorkerThreadMethod()
        {
            while (true)
            {
                FileController.ReadHtml(TxtBxCurrentTrack.Text, ChkBxPreviousTrack.Checked ? TxtBxPreviousTrack.Text : String.Empty);
                Thread.Sleep(int.Parse(TxtBxParseTime.Text));
            }
        }
    }
}