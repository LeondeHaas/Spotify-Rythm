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

        public Playlist(string playlistTitle)
        {
            PlaylistTitle = playlistTitle;
        }

        public static List<Playlist> GetPlaylists()
        {
            List<Playlist> playlists = new List<Playlist>()
            {
                new Playlist("[1] Favourites"),
                new Playlist("[2] Playlist #2"),
                new Playlist("[3] Playlist #3"),
                new Playlist("[4] Playlist #4"),
                new Playlist("[5] Playlist #5")
            };

            return playlists;
        }
        public class addPlaylist
        {

        }

        public class showSongs
        {

        }

        public class removeSongs
        {

        }
    }
}
