//  System
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
//  Agilty
using HtmlAgilityPack;
//  Newtonsoft
using Newtonsoft.Json;
//  Projcet
using NickScotney.SeratoNowPlaying.Logic.Models;

namespace NickScotney.SeratoNowPlaying.Logic.Helpers
{
    internal class FileHelper
    {
        static string folderLocation;
        static string parseAddress;

        public static string FolderLocation { set { folderLocation = value; } }
        public static string ParseAddress { set { parseAddress = value; } }


        public static void ClearFile(string fileName)
         => File.WriteAllText(fileName, String.Empty);

        public static List<Setting> LoadSettings()
        {
            //  If the folder path hasn't been set, return errorcode 1
            if (String.IsNullOrEmpty(folderLocation))
                return null;

            string settingsPath = Path.Combine(folderLocation, "Settings.json");

            //  If the file doesn't exist, return errorcode 2
            if (!File.Exists(settingsPath))
                return null;

            List<Setting> settingsList = null;

            try
            {
                using (StreamReader sr = new StreamReader(settingsPath))
                {
                    //  If the file contains any data
                    if (sr.Peek() > -1)
                    {
                        settingsList = JsonConvert.DeserializeObject<List<Setting>>(sr.ReadToEnd());
                    }

                    sr.Close();
                }
            }
            catch (Exception e)
            { /* Something went wrong here so do something about it */ }

            return settingsList;
        }

        public static void GetTrackNames(TrackLabel currentTrack, TrackLabel previousTrack, ref string currentTrackName, ref string previousTrackName)
        {
            try
            {
                //  Get the HTML document nodes here
                var doc = new HtmlWeb().Load(parseAddress);
                var nodes = doc.DocumentNode.Descendants("div")
                    .Where(div => div.GetAttributeValue("id", "") == "playlist_tracklist").ToList();

                //  Get the current track names here from Serato Live
                string[] currentTracks = new string[2];
                currentTracks[0] = GetTrackName(0, nodes);
                currentTracks[1] = GetTrackName(1, nodes);

                //  Check here to see if there was an update in either of the track names
                if ((currentTracks[0] != currentTrackName) || currentTracks[1] != previousTrackName)
                {
                    //  Check to see if we need to write the new track names here
                    if (currentTracks[0] != currentTrackName)
                    {
                        WriteLabelFiles(currentTrack, currentTracks[0]);
                        currentTrackName = currentTracks[0];
                    }

                    //  Only write the previous track if wee  have the setting enables and the name is different
                    if ((previousTrack != null) && currentTracks[1] != previousTrackName)
                    {
                        WriteLabelFiles(previousTrack, currentTracks[1]);
                        previousTrackName = currentTracks[1];
                    }
                }
            }
            catch { }
        }

        public static int SaveSettingsFile(List<Setting> settingsList)
        {
            //  If the folder path hasn't been set, return errorcode 1
            if (String.IsNullOrEmpty(folderLocation))
                return 1;
            
            string settingsPath = Path.Combine(folderLocation, "Settings.json");

            //  If the file doesn't exist, return errorcode 2
            if (!File.Exists(settingsPath))
                return 2;

            var errorCode = 0;

            try
            {
                //  Open the settings file for writing
                using (StreamWriter writer = new StreamWriter(settingsPath))
                {
                    //  Write the list object directly to the file, overwriting what was there originally
                    writer.Write(JsonConvert.SerializeObject(settingsList));
                    //  Close the writer
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                //  A file error occured, return errorcode 3
                errorCode = 3;
            }

            //  Return zero if everything went according to plan
            return errorCode;
        }


        static string GetTrackName(int trackIndex, List<HtmlNode> nodes)
        {
            var trackName = String.Empty;

            try
            {
                //  Get the Track node we need
                var trackNodes = nodes[0].ChildNodes
                    .Where(node => node.Name == "div")
                    .Reverse()
                    .ToList()[trackIndex];

                //  Get the track title node
                var trackTitleNode = trackNodes.ChildNodes
                    .Where(node => node.HasClass("playlist-trackname"))
                    .ToList()[0];

                //  Finally, just get the track text
                if (trackTitleNode != null)
                    trackName = trackTitleNode.InnerText.Trim();
            }
            catch { trackName = String.Empty; }

            return trackName;
        }

        static void WriteLabelFiles(TrackLabel trackLabel, string labelValue)
        {
            //  If the file doesn't exist, create it
            if (!File.Exists(trackLabel.LabelLocation))
                File.Create(trackLabel.LabelLocation);

            //  Write the data to the label file here
            using (var writer = new StreamWriter(trackLabel.LabelLocation))
            {
                var output = String.Empty;

                if (!String.IsNullOrEmpty(trackLabel.LabelPrefix))
                    output += $"{trackLabel.LabelPrefix} ";

                output += labelValue;

                if (!String.IsNullOrEmpty(trackLabel.LabelSuffix))
                    output += $" {trackLabel.LabelSuffix}";

                writer.WriteLine(output);
                writer.Close();
            }
        }
    }
}