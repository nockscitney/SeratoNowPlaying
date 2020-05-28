//  System
using System;
//  Project 
using NickScotney.SeratoNowPlaying.Logic.Helpers;
using NickScotney.SeratoNowPlaying.Logic.Models;

namespace NickScotney.SeratoNowPlaying.Logic.Controllers
{
    public class FileController
    {
        static string currentTrackValue, previousTrackValue;

        public static void ClearFiles(string currentTrack, string previousTrack)
        {
            FileHelper.ClearFile(currentTrack);

            if (!string.IsNullOrEmpty(previousTrack))
                FileHelper.ClearFile(previousTrack);

            //  Clear any value from the local track variables here
            currentTrack = String.Empty;
            previousTrack = String.Empty;
        }

        public static void ReadHtml(TrackLabel currentTrack, TrackLabel previousTrack)
            => FileHelper.GetTrackNames(currentTrack, previousTrack, ref currentTrackValue, ref previousTrackValue);

        public static void SetFolderPath(string folderPath)
            => FileHelper.FolderLocation = folderPath;

        public static void SetParseAddress(string parseAddress)
            => FileHelper.ParseAddress = parseAddress;
    }
}