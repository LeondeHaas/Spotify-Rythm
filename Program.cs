using System;
using System.Collections.Generic;

namespace Spotify
{
    class Program
    {
        static void Main(string[] args)
        {
            bool restart = true;

            while (restart)
            {
                Console.WriteLine("Welcome to Spotify!");
                Console.WriteLine("Choose an option :");
                Console.WriteLine("[1] Playlists");
                Console.WriteLine("[2] Albums");
                Console.WriteLine("[3] Songs");
                Console.WriteLine("[4] Friendlist");

                int input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(input);

                if (input == 1) // Shows playlists
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
                        foreach (var song in songs)
                        {
                            Console.WriteLine($"[{song.SongId}] {song.Title} - {song.Artist} [Duration: {song.Playtime}]");
                        }
                    }
                    else
                    {
                        Console.WriteLine("The playlist you selected is either invalid or does not exist. Please try again.");
                    }
                }
                else if (input == 2) // Shows albums
                {
                    Console.WriteLine("List of albums");
                }
                else if (input == 3) // Shows songs
                {
                    Console.WriteLine("List of Songs:");
                    Console.WriteLine("Which song would you like to play?");
                    List<Song> songs = Song.GetSongList();
                    foreach (var song in songs)
                    {
                        Console.WriteLine($"[{song.SongId}] {song.Title} - {song.Artist} [Duration: {song.Playtime}]");
                    }

                    int songNumber = Convert.ToInt32(Console.ReadLine());

                    if (songNumber >= 1 && songNumber <= songs.Count)
                    {
                        Song selectedSong = songs[songNumber - 1];
                        Console.WriteLine("Currently playing: " + selectedSong.Title + " by " + selectedSong.Artist);

                        Console.Write("Playing song!: ");

                        for (int remainingSeconds = selectedSong.Playtime; remainingSeconds > 0; remainingSeconds--)
                        {
                            Console.Write(remainingSeconds.ToString().PadLeft(2) + " ");
                            System.Threading.Thread.Sleep(1000); // Sleep for 1 second
                            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop); // Move cursor back to overwrite the previous number
                        }

                        Console.WriteLine("\nSong finished!");
                    }
                    else
                    {
                        Console.WriteLine("The song you selected is either invalid or does not exist. Please try again.");
                    }
                }
                else if (input == 4) // Shows friend list
                {
                    Console.WriteLine("List of Friends");
                }

                // Restart the program
                Console.WriteLine("Press [B] to start over.");
                string restartInput = Console.ReadLine();
                restart = (restartInput == "B" || restartInput == "b");
                Console.WriteLine();
            }
        }
    }
}
