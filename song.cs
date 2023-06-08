using System;
using System.Collections.Generic;

namespace Spotify
{
    public class Song
    {
        public int Playtime { get; set; }
        public int SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }

        public Song(int playtime, int songId, string title, string artist)
        {
            Playtime = playtime;
            SongId = songId;
            Title = title;
            Artist = artist;
        }

        public static List<Song> GetSongList()
        {
            List<Song> songs = new List<Song>()
            {
                new Song(2, 1, "Flashback", "Aproaching Nervana"),
                new Song(2, 2, "Counting Stars", "Artist 2"),
                new Song(2, 3, "Outside", "Artist 3"),
                new Song(2, 4, "NIGHT DANCER", "Artist 4"),
                new Song(20, 5, "Carol Of The Bells", "Artist 5"),
                new Song(20, 6, "Mercury", "Artist 6"),
                new Song(20, 7, "Wonderland", "Neoni"),
                new Song(20, 8, "All Falls Down", "Alan Walker"),
                new Song(20, 9, "Soldier", "NEFFEX")
            };

            return songs;
        }

        public void PauseSong()
        {
        } 

        public void ResumeSong()
        {

        }

        public void StopSong()
        {

        }
    }
}
