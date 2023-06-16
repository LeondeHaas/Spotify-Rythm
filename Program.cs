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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome to Spotify!");
                Console.ResetColor();

                Console.WriteLine("Choose an option:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[1] Playlists");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("[2] Artists");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[3] Songs");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("[4] Friendlist");

                int input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(input);

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
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("Press [B] to start over.");
                string restartInput = Console.ReadLine();
                restart = (restartInput == "B" || restartInput == "b");
                Console.WriteLine();
            }
        }

        static void HandlePlaylists()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("List of Playlists:");
            Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Opening playlist: {selectedPlaylist.PlaylistTitle}");
                Console.ResetColor();

                List<Song> songs = selectedPlaylist.GetSongs();
                PrintSongs(songs);

                Console.WriteLine("Enter the song number to play:");
                int songNumber = Convert.ToInt32(Console.ReadLine());

                if (songNumber >= 1 && songNumber <= songs.Count)
                {
                    PlaySong(songs[songNumber - 1]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The song you selected is either invalid or does not exist. Please try again.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The playlist you selected is either invalid or does not exist. Please try again.");
                Console.ResetColor();
            }
        }

        static void HandleArtists()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("List of Artists:");
            Console.ResetColor();

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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Selected artist: {selectedArtist.ArtistName}");
                Console.ResetColor();

                List<Album> albums = selectedArtist.Albums;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("List of Albums:");
                Console.ResetColor();
                foreach (var album in albums)
                {
                    Console.WriteLine(album.AlbumTitle);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Artist you selected is either invalid or does not exist. Please try again.");
                Console.ResetColor();
            }
        }

        static void HandleSongs()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("List of Songs:");
            Console.ResetColor();

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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The song you selected is either invalid or does not exist. Please try again.");
                Console.ResetColor();
            }
        }

        static void HandleFriendlist()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Friendlist is currently unavailable. Please try again later."); //this is temporary
            Console.ResetColor();
        }

        static void PrintSongs(List<Song> songs)
        {
            foreach (var song in songs)
            {
                Console.WriteLine($"[{song.SongId}] {song.Title} - {song.Artist} [Duration: {song.Playtime}]");
            }
        }

        static void PlaySong(Song song)
        {
            Console.WriteLine("Currently playing: " + song.Title + " by " + song.Artist);

            Console.Write("Playing song!: ");
            for (int remainingSeconds = song.Playtime; remainingSeconds > 0; remainingSeconds--)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(remainingSeconds.ToString().PadLeft(2) + " ");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
                Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
            }

            Console.WriteLine("\nSong finished!");
        }
    }
}