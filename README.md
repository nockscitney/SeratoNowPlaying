# SeratoNowPlaying
A tool which allows users to get the currently (and previously) playing track names from Serato DJ

## Current Version (1.1.0.2)
Dowload the Current Version Here: https://github.com/nockscitney/SeratoNowPlaying/releases/tag/1.1.0.2

## About
This tool will write the current and previous track to a text file, which can then be used by streaming services such as IceCast & BUTT.  It can also be used directly by broadcasting software such as OBS Studio, to update an on screen text field.

Rather than trying to open and read the Serato library files directly (and while they are in use), this tool will leverage the "Live Playlist" feature within Serato DJ.  Once track information is being sent to Serato, the tool will poll your "Live" playlist page and update the text tags accordingly.  More information about Live Playlists  and how to enable it within your Serato DJ can be found here - https://support.serato.com/hc/en-us/articles/228019568-Live-Playlists

## Setup
**You must be connected to the internet for this to work.  You must also be able to use the Serato Playlists feature within your Serato Account**

A step by step video for configuring Serato Now Playing has been created by  a member on the Serato DJ Forums (9807852) and can be found here: https://drive.google.com/open?id=1IhNut9AnhNJ7z8J2hwvhJFlmJKoTcB2s

1. Download and install the tool
2. Once installed, run the tool and configure the settings which are
..* Parse Time: The time in milliseconds which the tool will look for updates
..* Live Feed Location: The URL address where your Serato live feed will be updated
..* Current Track Label: The location of the text file where the current track name will be saved to 
..* Previous Track Label: The location of the text file where the previous track name will be saved to (if enabled)
3. Start Serato DJ and Connect your DJ hardware
4. Enable Live-Playlists as per the Serato article linked above (this part can be a little fiddly and you may need to restart Serato after doing this)
5. Click the "Start Live Session" button in Serato's "History" tab.  You may see an on-screen prompt. Press Yes and a web page should open in your browser.  Press "Continue" on the web page to be taken to the Live Playlist Screen.  On the Live Playlist Screen, you'll need to make the playlist public.  To do this select "Edit Details" and change Privacy to "Public".  Press "Save Changes" at the bottom of the screen.  **PLEASE NOTE** I have an issue sometimes where the Live-Playlists button isn't visible. To correct this, go into Serato's Settings > Expansion Packs > Serato Playlist.  Un-Tick the boxes that say "Enable Serato Playlists" and "Enable Live Playlists". Exit the settings screen and then go back and tick both boxes.  This will make the "Start Live Playlist" button appear.
6. With all the settings on the tool configured, press "Start" and the tool will then begin to update the text files.

## Issues
If you find any issues with the tool or would like to suggest any improvements, please use the "Issues Tab
