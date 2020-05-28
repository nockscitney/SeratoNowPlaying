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

            //  Parse Time
            LoadSetting(NudPareTime, "ParseTime", "10");

            //  Check here to see if we're usng Seconds or milliseconds.  If the latter, divide the total by 1000
            if (NudPareTime.Value > 900)
                NudPareTime.Value = NudPareTime.Value / 1000;

            //  Parse Address
            LoadSetting(TxtBxFeedLocation, "ParseAddress");

            //  Current Track Location
            LoadSetting(TxtBxCurrentTrack, "CurrentTrackLabelFile");
            //  Current Track Prefix Enabled
            LoadSetting(ChkBxCurrentPrefix, "CurrentTrackPrefixEnabled", "False");
            //  Current Track Prefix
            LoadSetting(TxtBxCurrentPrefix, "CurrentTrackPrefixValue");
            //  Current Track Suffix Enabled
            LoadSetting(ChkBxCurrentSuffix, "CurrentTrackSuffixEnabled", "False");
            //  Current Track Suffix
            LoadSetting(TxtBxCurrentSuffix, "CurrentTrackSuffixValue");

            //  Previous Track Enabled
            LoadSetting(ChkBxPreviousTrack, "EnablePreviousTrackLabel", "False");

            //  Previous Track Location
            LoadSetting(TxtBxPreviousTrack, "PreviousTrackLabelFile");

            //  Previous Track Prefix Enabled
            LoadSetting(ChkBxPreviousPrefix, "PreviousTrackPrefixEnabled", "False");
            //  Previous Track Prefix
            LoadSetting(TxtBxPreviousPrefix, "PreviousTrackPrefixValue");
            //  Previous Track Suffix Enabled
            LoadSetting(ChkBxPreviousSuffix, "PreviousTrackSuffixEnabled", "False");
            //  Previous Track Suffix
            LoadSetting(TxtBxPreviousSuffix, "PreviousTrackSuffixValue");
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
            SaveSetting(NudPareTime, "ParseTime");

            //  Parse Address
            SaveSetting(TxtBxFeedLocation, "ParseAddress");

            //  Current Track
            SaveSetting(TxtBxCurrentTrack, "CurrentTrackLabelFile");

            //  Current Track Prefix Enabled
            SaveSetting(ChkBxCurrentPrefix, "CurrentTrackPrefixEnabled");
            //  Current Track Prefix
            SaveSetting(TxtBxCurrentPrefix, "CurrentTrackPrefixValue");
            //  Current Track Suffix Enabled
            SaveSetting(ChkBxCurrentSuffix, "CurrentTrackSuffixEnabled");
            //  Current Track Suffix
            SaveSetting(TxtBxCurrentSuffix, "CurrentTrackSuffixValue");

            //  Previous Track Enabled
            Setting setting = settingsList.First(set => set.SettingName == "EnablePreviousTrackLabel");

            if(setting != null)
                setting.SettingValue = ChkBxPreviousTrack.Checked.ToString();

            //   Previous Track
            SaveSetting(TxtBxPreviousTrack, "PreviousTrackLabelFile");

            //  Previous Track Prefix Enabled
            SaveSetting(ChkBxPreviousPrefix, "PreviousTrackPrefixEnabled");
            //  Previous Track Prefix
            SaveSetting(TxtBxPreviousPrefix, "PreviousTrackPrefixValue");
            //  Previous Track Suffix Enabled
            SaveSetting(ChkBxPreviousSuffix, "PreviousTrackSuffixEnabled");
            //  Previous Track Suffix
            SaveSetting(TxtBxPreviousSuffix, "PreviousTrackSuffixValue");

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
                    MessageBox.Show("An error occured while saving the settings file - Are you running as Administrator?");
                    break;
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                GrpBxCurrentTrack.Enabled = false;                
                GrpBxLocation.Enabled = false;
                GrpBxParseTime.Enabled = false;
                GrpBxPreviousTrack.Enabled = false;

                FileController.ClearFiles(TxtBxCurrentTrack.Text, TxtBxPreviousTrack.Text);
                FileController.SetParseAddress(TxtBxFeedLocation.Text);

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

        private void ChkBxCurrentPrefix_CheckedChanged(object sender, EventArgs e)
            => TxtBxCurrentPrefix.Enabled = ChkBxCurrentPrefix.Checked;

        private void ChkBxCurrentSuffix_CheckedChanged(object sender, EventArgs e)
            => TxtBxCurrentSuffix.Enabled = ChkBxCurrentSuffix.Checked;

        private void ChkBxPreviousPrefix_CheckedChanged(object sender, EventArgs e)
            => TxtBxPreviousPrefix.Enabled = ChkBxPreviousPrefix.Checked;  

        private void ChkBxPreviousSuffix_CheckedChanged(object sender, EventArgs e)
            => TxtBxPreviousSuffix.Enabled = ChkBxPreviousSuffix.Checked;        

        private void ChkBxPreviousTrack_CheckedChanged(object sender, EventArgs e)
        {
            BtnBrowsePrevious.Enabled = ChkBxPreviousTrack.Checked;
            ChkBxPreviousPrefix.Enabled = ChkBxPreviousTrack.Checked;
            ChkBxPreviousSuffix.Enabled = ChkBxPreviousTrack.Checked;

            TxtBxPreviousPrefix.Enabled = (ChkBxPreviousPrefix.Checked) && ChkBxPreviousPrefix.Enabled;
            TxtBxPreviousSuffix.Enabled = (ChkBxPreviousSuffix.Checked) && ChkBxPreviousSuffix.Enabled;
        }

        private void TxtBxParseTime_KeyPress(object sender, KeyPressEventArgs e)
            => e.Handled = (!Char.IsNumber(e.KeyChar)) && !Char.IsControl(e.KeyChar);


        void LoadSetting(Control formControl, string settingName, string settingValue = "")
        {
            var setting = settingsList.FirstOrDefault(set => set.SettingName == settingName);

            if (setting == null)
                settingsList.Add(new Setting { SettingName = settingName, SettingValue = settingValue });
            else
            {
                var controlType = formControl.GetType();

                if (controlType == typeof(CheckBox))
                    ((CheckBox)formControl).Checked = Boolean.Parse(setting.SettingValue);
                else if (controlType == typeof(NumericUpDown))
                    if (Decimal.Parse(setting.SettingValue) > ((NumericUpDown)formControl).Maximum)
                        ((NumericUpDown)formControl).Value = ((NumericUpDown)formControl).Maximum;
                    else
                        ((NumericUpDown)formControl).Value = Decimal.Parse(setting.SettingValue);
                else if (controlType == typeof(TextBox))
                    ((TextBox)formControl).Text = setting.SettingValue;
            }
        }

        void SaveSetting(Control formControl, string settingName)
        {
            var setting = settingsList.FirstOrDefault(set => set.SettingName == settingName);

            if (setting == null)
            {
                settingsList.Add(new Setting { SettingName = settingName });
                SaveSetting(formControl, settingName);
                return;
            }

            var controlType = formControl.GetType();

            if (controlType == typeof(CheckBox))
                setting.SettingValue = ((CheckBox)formControl).Checked.ToString();
            else if (controlType == typeof(NumericUpDown))
                setting.SettingValue = ((NumericUpDown)formControl).Value.ToString();
            else if (controlType == typeof(TextBox))
                setting.SettingValue = ((TextBox)formControl).Text;               
        }

        void WorkerThreadMethod()
        {
            //  Build the track objects here
            TrackLabel currentTrack = new TrackLabel
            {
                LabelLocation = TxtBxCurrentTrack.Text,
                LabelPrefix = ChkBxCurrentPrefix.Checked
                    ? !String.IsNullOrEmpty(TxtBxCurrentPrefix.Text)
                        ? TxtBxCurrentPrefix.Text
                        : String.Empty
                    : String.Empty,
                LabelSuffix = ChkBxCurrentSuffix.Checked
                    ? !String.IsNullOrEmpty(TxtBxCurrentSuffix.Text)
                        ? TxtBxCurrentSuffix.Text
                        : String.Empty
                    : String.Empty
            };

            TrackLabel previousTrack = null;

            if (ChkBxPreviousTrack.Checked)
                previousTrack = new TrackLabel
                {
                    LabelLocation = TxtBxPreviousTrack.Text,
                    LabelPrefix = ChkBxPreviousPrefix.Checked 
                    ? !String.IsNullOrEmpty(TxtBxPreviousPrefix.Text)
                        ? TxtBxPreviousPrefix.Text
                        : String.Empty
                    : String.Empty,
                    LabelSuffix = ChkBxPreviousSuffix.Checked 
                    ? !String.IsNullOrEmpty(TxtBxPreviousSuffix.Text)
                        ? TxtBxPreviousSuffix.Text
                        : String.Empty
                    : String.Empty
                };

            while (true)
            {
                FileController.ReadHtml(currentTrack, previousTrack);
                Thread.Sleep((int)NudPareTime.Value * 1000);
            }
        }
    }
}