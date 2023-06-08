using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Playlist
    {
        public string PlaylistTitle { get; set; } 
        public int PlaylistId { get; set; }

        //public int PlaylistSelectId { get; set; }

        public Playlist(int playlistId, string playlistTitle)
        {
            PlaylistId = playlistId;
            PlaylistTitle = playlistTitle;
           // PlaylistSelectId = PlaylistSelectId;
        }

        public static List<Playlist> GetPlaylists() 
        {
            List<Playlist> playlists = new List<Playlist>()
            {
                new Playlist(1, "Favourites"),
                new Playlist(2, "YOASOBI"),
                new Playlist(3, "THis is NEFFEX"),
                new Playlist(4, "Neoni"),
                new Playlist(5, "Lofi Chill Beats") 
            };

            return playlists;
        }
    }
}
