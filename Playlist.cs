using System.Collections.Generic;

namespace Spotify
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string PlaylistTitle { get; set; }
        private List<Song> Songs { get; set; }

        public Playlist(int playlistId, string playlistTitle)
        {
            PlaylistId = playlistId;
            PlaylistTitle = playlistTitle;
            Songs = new List<Song>();
        }

        public void AddSong(Song song)
        {
            Songs.Add(song);
        }

        public List<Song> GetSongs()
        {
            return Songs;
        }

        public static List<Playlist> GetPlaylists()
        {
            List<Playlist> playlists = new List<Playlist>()
            {
                new Playlist(1, "Favourites"),
                new Playlist(2, "YOASOBI"),
                new Playlist(3, "This is NEFFEX"),
                new Playlist(4, "Neoni"),
                new Playlist(5, "Lofi Chill Beats")
            };

            //Favourites playlist || index 0
            playlists[0].AddSong(new Song(180, 1, "IDOL", "YOASOBI"));
            playlists[0].AddSong(new Song(210, 2, "Die In a Fire", "The Living Tombstone"));
            playlists[0].AddSong(new Song(190, 3, "Never Gonna Give You Up", "Rick Astley"));

            //YOASIBI playlist || index 1
            playlists[1].AddSong(new Song(180, 1, "夜に駆ける", "YOASOBI"));
            playlists[1].AddSong(new Song(200, 2, "もう少しだけ", "YOASOBI"));
            playlists[1].AddSong(new Song(200, 3, "あの夢をなぞって", "YOASOBI"));

            //NEFFEX playlist || index 2
            playlists[2].AddSong(new Song(220, 1, "Cold", "NEFFEX"));
            playlists[2].AddSong(new Song(240, 2, "Careless", "NEFFEX"));
            playlists[2].AddSong(new Song(240, 3, "Soldier", "NEFFEX"));

            //Neoni playlist || index 3
            playlists[3].AddSong(new Song(200, 1, "DARKSIDE", "Neoni"));
            playlists[3].AddSong(new Song(210, 2, "WONDERLAND", "Neoni"));
            playlists[3].AddSong(new Song(210, 3, "Haunted House", "Neoni"));

            //Lofi Chill Beats playlist || index 4
            playlists[4].AddSong(new Song(190, 1, "The Girl I Haven't Met", "Lofi Beats"));
            playlists[4].AddSong(new Song(180, 2, "letting go", "Lofi Beats"));
            playlists[4].AddSong(new Song(180, 2, "Pine Leaves", "Lofi Beats"));

            return playlists;
        }
    }
}
