using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//  Project 
using NickScotney.SeratoNowPlaying.Logic.Helpers;
using NickScotney.SeratoNowPlaying.Logic.Models;

namespace NickScotney.SeratoNowPlaying.Logic.Controllers
{
    public class SettingController
    {
        public static List<Setting> LoadSettings()
            => FileHelper.LoadSettings();

        public static int SaveSettings(List<Setting> settingList)
            => FileHelper.SaveSettingsFile(settingList);


    }
}