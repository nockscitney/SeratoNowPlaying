# SeratoNowPlaying
A tool which allows users to get the currently (and previously) playing track names from Serato DJ.  This is split into two different applications, depending on your operating system.
- **Windows Users:** Use SeratoNowPlaying
- **Mac Users:** Use SeratoNowPlaying-Lite

## Current Version (1.1.1.0)
Dowload the Current Version Here: https://github.com/nockscitney/SeratoNowPlaying/releases/tag/1.1.1.0

## SeratoNowPlaying-Lite (1.0.1.0)
I have now ported over a lite version to the .net Core framework.  This has been tested on both Windows and Mac and detailed install / setup instructions can be found below.: https://github.com/nockscitney/SeratoNowPlaying/releases/tag/snpl-1.0.1.0

## About
This tool will write the current and previous track to a text file, which can then be used by streaming services such as IceCast & BUTT.  It can also be used directly by broadcasting software such as OBS Studio, to update an on screen text field.

Rather than trying to open and read the Serato library files directly (and while they are in use), this tool will leverage the "Live Playlist" feature within Serato DJ.  Once track information is being sent to Serato, the tool will poll your "Live" playlist page and update the text tags accordingly.  More information about Live Playlists  and how to enable it within your Serato DJ can be found here - https://support.serato.com/hc/en-us/articles/228019568-Live-Playlists

## Setup
**You must be connected to the internet for this to work.  You must also be able to use the Serato Playlists feature within your Serato Account**

### Serato Now Playing

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

A step by step video for configuring Serato Now Playing has been created by  a member on the Serato DJ Forums (9807852) and can be found here: https://drive.google.com/open?id=1IhNut9AnhNJ7z8J2hwvhJFlmJKoTcB2s

An alternative tutorial has been created by DJ Lazy Eyez, which can also be found here - https://www.youtube.com/watch?v=coX1m5A_GEQ

### Serato Now Playing Lite

1. If you don't already have it, download and Install the .NET Core Framework from here - https://dotnet.microsoft.com/download/dotnet-core/3.1.  There are many options on this page.  At time of release, the latest version is 3.1.7.  When visiting the page, look for the downloads marked "**.NET Core Runtime 3.1.7**".  You will then see a table with various downloads and you want the **macOS x64 Installer**.  Download this and install on your Mac.
2. Create a new, blank text file on your Mac.  To do this find the **TextEdit** app on the Mac.  Once opened, click **Format** in the menu at the top and select **Make Plain Text**.  Save the document to your Mac (I recommend something like "CurrentTrack.txt" and then close TextEdit.
3. Download the latest version of SeratoNowPlaying-Lite. At time of writing, it is the Zip Download below.  Once downloaded, double click the zip file to extract it to it's own folder.
4. Open the **Terminal** app and navigate to the folder where you downloaded SeratoNowPlaying-Lite to.  To do this type the command: ***cd "/Users/USERNAME/Downloads/SeratoNowPlaying-Lite v1.0.0.0/" (this path assumes you downloaded the file to your users's downloads folder (where **USERNAME** is your username).  Please update the link accordingly to match your location
5. No you can run the application by typing **dotnet SeratoNowPlaying-Lite.dll**.  The Application will start and will prompt you to configure the options
6. Enter the number of seconds you wish to check for new tracks (or leave it at the default of 10)
7. Enter the URL for your Serato Live Playlist Page
8. Enter the file path of the Text file you're saving the track information to (i.e. if your file is on the desktop, you'd type "/Users/USERNAME/Desktop/CurrentTrack.txt" where USERNAME is your user account name and CurrentTrack.txt is the name of your text file

That's it.  The application will now run and monitor the Current track until you close it.  To run it after this initial configuration, simply repeat steps 4 and 5 to re-run the application

## Issues
If you find any issues with the tool or would like to suggest any improvements, please use the "Issues Tab
