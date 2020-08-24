//  System
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
//  Logic
using NickScotney.SeratoNowPlaying.Logic.Controllers;
using NickScotney.SeratoNowPlaying.Logic.Models;

namespace NickScotney.SeratoNowPlaying.Lite
{
    class Program
    {
        static int parseTime;
        static List<Setting> settingsList;
        static string parseAddress, currentTrackLabel;
        static Thread workerThread;

        static void Main(string[] args)
        {
            ClearConsole();

            Thread.Sleep(2000);

            //  Load the value in the file
            FileController.SetFolderPath(AppDomain.CurrentDomain.BaseDirectory);
            
            //  Load the setting list here
            settingsList = SettingController.LoadSettings();

            //  Check to see if the current parse time is ok
            Console.WriteLine($"Current Parse Time (Seconds): {(parseTime = LoadSetting<int>("ParseTime", "0")) / 1000}");
            Console.WriteLine("Would you like to change the Parse Time? (Y/N)");

            //  The user asked to change the parse time
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine();

                var incorrectEntry = true;

                //  Loop while the entry can't be parsed as a number
                while (incorrectEntry)
                {
                    Console.WriteLine("Please Enter New Parse Time (in Seconds, Minimum 10)");

                    //  The user entered a number
                    if (int.TryParse(Console.ReadLine(), out parseTime))
                    {
                        //  The number was greater than 10
                        if (parseTime > 10)
                        {
                            parseTime *= 1000;
                            SaveSetting("ParseTime", parseTime.ToString());
                            incorrectEntry = false;
                        }
                        //  The number was less than 10
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Parse Time must be greater than 10 Seconds");
                            Console.WriteLine();
                        }
                    }
                }
            }

            ClearConsole();

            //  Check to see if the current parse address is ok
            Console.WriteLine($"Current Parse Address: {parseAddress = LoadSetting<string>("ParseAddress")}");
            Console.WriteLine("Would you like to change the Parse Address? (Y/N)");
            
            //  The user asked to change the parse location
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                Console.WriteLine("Please Enter New Parse Address");
                parseAddress = Console.ReadLine();
                SaveSetting("ParseAddress", parseAddress);
            }

            ClearConsole();

            //  Check to see if the current track is ok
            Console.WriteLine($"Current Track File: {currentTrackLabel = LoadSetting<string>("CurrentTrackLabelFile")}");
            Console.WriteLine("Would you like to change the Current Track File? (Y/N)");
            
            //  The user asked to change the current track location
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine();
                Console.WriteLine("Please Enter New Current Track File");
                currentTrackLabel = Console.ReadLine();
                SaveSetting("CurrentTrackLabelFile", currentTrackLabel);
            }

            Console.WriteLine();

            //  Save the settings list here
            SettingController.SaveSettings(settingsList);

            //  Start the listening here
            Console.WriteLine("Starting Application . . . . ");
            Console.Clear();
            
            //  Clear the files and set the parse address
            FileController.ClearFiles(currentTrackLabel, string.Empty);
            FileController.SetParseAddress(parseAddress);

            //  Start the worker thread
            workerThread = new Thread(new ThreadStart(WorkerThreadMethod));
            workerThread.Start();
        }

        static void ClearConsole()
        {
            Console.Clear();

            Console.WriteLine("Welcome to Serato Now Playing .NET Core Edition");
            Console.WriteLine();
        }

        static T LoadSetting<T>(string settingName, string settingValue = "")
        {
            var setting = settingsList.FirstOrDefault(set => set.SettingName == settingName);

            if (setting == null)
            {
                setting = new Setting { SettingName = settingName, SettingValue = settingValue };
                settingsList.Add(setting);
            }

            return (T)Convert.ChangeType(setting.SettingValue, typeof(T));
        }

        static void SaveSetting(string settingName, string settingValue)
        {
            var setting = settingsList.FirstOrDefault(set => set.SettingName == settingName);

            if (setting == null)
            {
                setting = new Setting { SettingName = settingName};
                settingsList.Add(setting);
            }

            setting.SettingValue = settingValue;
        }

        static void WorkerThreadMethod()
        {
            //  Build the track objects here
            TrackLabel currentTrack = new TrackLabel
            {
                LabelLocation = currentTrackLabel
            };

            Console.WriteLine("Application is Running . . . Close to Stop");

            while (true)
            {
                FileController.ReadHtml(currentTrack, null);
                Thread.Sleep(parseTime);
            }
        }
    }
}
