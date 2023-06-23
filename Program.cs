using System;
using System.Collections.Generic;
using System.Threading;

namespace Spotify
{
    class Program
    {
        static void Main(string[] args)
        {
            BootUpDelay();

            bool restart = true;

            while (restart)
            {
                // Welcome screen with unicode support.
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                Console.WriteLine("Welcome to \u001b[31mR\u001b[33my\u001b[32mt\u001b[34mh\u001b[35mm\u001b[36m!\u001b[0m");
                Console.WriteLine("What would you like to see?");
                Console.WriteLine("[1] \U0001F4D6 Playlists");
                Console.WriteLine("[2] \U0001F9D1 Artists");
                Console.WriteLine("[3] \U0001F3B5 Songs");
                Console.WriteLine("[4] \U0001F465 Friendlist");
                Console.WriteLine("[5] \u274C Exit");

                int input = Convert.ToInt32(Console.ReadLine());


                // Switch case for menu that handles different methods.
                switch (input)
                {
                    case 1:
                        HandlePlaylists();
                        break;
                    case 2:
                        HandleArtists();
                        break;
                    case 3:
                        HandleSongs();
                        break;
                    case 4:
                        HandleFriendlist();
                        break;
                    case 5:
                        restart = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

                // If-else statement to restart the program and/or exit it.
                if (restart)
                {
                    Console.WriteLine("Press [B] to start over.");
                    string restartInput = Console.ReadLine();
                    restart = (restartInput == "B" || restartInput == "b");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Leaving Rythm, but the beats will forever echo in your soul.");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }
            }
        }

        // Method that simulates booting up the program.
        static void BootUpDelay()
        {
            Console.WriteLine("Launching Rythm... Get ready to groove!");

            for (int count = 1000; count >= 0; count -= 10)
            {
                Console.Write(count.ToString().PadLeft(4, '0') + " ");
                Thread.Sleep(10);
                Console.SetCursorPosition(Console.CursorLeft - 5, Console.CursorTop);
            }

            Console.Clear();
        }

        // Method that opens the selected playlist, shows the songs in a playlist, and plays the song.
        static void HandlePlaylists()
        {
            Console.WriteLine("List of Playlists:");
            Console.WriteLine("Which playlist would you like to open?");

            List<Playlist> playlists = Playlist.GetPlaylists();
            foreach (var playlist in playlists)
            {
                Console.WriteLine($"[{playlist.PlaylistId}] {playlist.PlaylistTitle}");
            }

            int playlistNumber = Convert.ToInt32(Console.ReadLine());

            if (playlistNumber >= 1 && playlistNumber <= playlists.Count)
            {
                Playlist selectedPlaylist = playlists[playlistNumber - 1];
                Console.WriteLine($"Opening playlist: {selectedPlaylist.PlaylistTitle}");

                List<Song> songs = selectedPlaylist.GetSongs();
                PrintSongs(songs);

                Console.WriteLine("Enter the song number to play (or 0 to play all songs):");
                int songNumber = Convert.ToInt32(Console.ReadLine());

                if (songNumber == 0)
                {
                    PlayAllSongs(songs);
                }
                else if (songNumber >= 1 && songNumber <= songs.Count)
                {
                    PlaySong(songs[songNumber - 1]);
                }
                else
                {
                    Console.WriteLine("Invalid song number. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid playlist number. Please try again.");
            }
        }

        // Method that opens a list of artists, shows the albums of the selected artist, and plays the song.
        static void HandleArtists()
        {
            Console.WriteLine("List of Artists:");

            List<Artist> artists = Artist.GetArtists();
            foreach (var artist in artists)
            {
                Console.WriteLine($"[{artist.ArtistId}] {artist.ArtistName}");
            }

            Console.WriteLine("Which artist would you like to see?");
            int artistId = Convert.ToInt32(Console.ReadLine());

            Artist selectedArtist = artists.Find(artist => artist.ArtistId == artistId);
            if (selectedArtist != null)
            {
                Console.WriteLine($"Selected artist: {selectedArtist.ArtistName}");

                List<Album> albums = selectedArtist.Albums;
                Console.WriteLine("List of Albums:");
                foreach (var album in albums)
                {
                    Console.WriteLine(album.AlbumTitle);
                }
            }
            else
            {
                Console.WriteLine("Invalid artist number. Please try again.");
            }
        }

        // Method that opens a list of songs and plays the song.
        static void HandleSongs()
        {
            Console.WriteLine("List of Songs:");

            List<Song> songs = Song.GetSongList();
            PrintSongs(songs);

            Console.WriteLine("Enter the song number to play:");
            int songNumber = Convert.ToInt32(Console.ReadLine());

            if (songNumber >= 1 && songNumber <= songs.Count)
            {
                PlaySong(songs[songNumber - 1]);
            }
            else
            {
                Console.WriteLine("Invalid song number. Please try again.");
            }
        }

        // Method that opens a list of friends.
        static void HandleFriendlist()
        {
            Console.WriteLine("My friends:");

            List<Friend> friends = Friend.GetFriends();
            foreach (var friend in friends)
            {
                Console.WriteLine($"[{friend.FriendId}] {friend.Name}");
            }
        }

        // Method that prints the songs in a playlist.
        static void PrintSongs(List<Song> songs)
        {
            foreach (var song in songs)
            {
                Console.WriteLine($"[{song.SongId}] {song.Title} - {song.Artist} [Duration: {song.Playtime}]");
            }
        }

        // Method that plays a single song.
        static void PlaySong(Song song)
        {
            Console.WriteLine($"Playing: {song.Title} - {song.Artist}");

            Console.Write("Playing song! ");
            for (int remainingSeconds = song.Playtime; remainingSeconds > 0; remainingSeconds--)
            {
                string colorCode = "\u001b[32m";        // Green
                if (remainingSeconds <= 5)
                {
                    if (remainingSeconds == 5)
                        colorCode = "\u001b[33m";       // Yellow
                    else if (remainingSeconds == 4)
                        colorCode = "\u001b[38;5;208m"; // Orange
                    else if (remainingSeconds <= 3)
                        colorCode = "\u001b[31m";       // Red
                }

                Console.Write(colorCode + remainingSeconds.ToString().PadLeft(2) + " ");
                Thread.Sleep(1000);
                Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
            }

            Console.WriteLine("\u001b[0m\nSong finished!"); // Reset color to default
        }

        // Method that plays all songs in a playlist.
        static void PlayAllSongs(List<Song> songs)
        {
            Console.WriteLine("Playing all songs in the playlist:");

            foreach (var song in songs)
            {
                PlaySong(song);
                Console.WriteLine();
            }
        }
    }
}
