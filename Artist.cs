using System.Collections.Generic;

public class Artist
{
    // Properties
    public string ArtistName { get; set; }
    public int ArtistId { get; set; }
    public List<Album> Albums { get; set; }

    // Constructor
    public Artist(int artistId, string artistName)
    {
        ArtistId = artistId;
        ArtistName = artistName;
        Albums = new List<Album>();
    }

    // Method to add an album to an artist
    public void AddAlbum(Album album)
    {
        Albums.Add(album);
    }

    // Method to get a list of artists
    public static List<Artist> GetArtists()
    {
        List<Artist> artists = new List<Artist>()
        {
            new Artist(1, "Imagine Dragons"),
            new Artist(2, "Alan Walker"),
            new Artist(3, "VALORANT"),
            new Artist(4, "Bemax"),
            new Artist(5, "The Living Tombstone")
        };

        // Add songs for each artist

        // Add albums for each artist
        artists[0].AddAlbum(new Album("Imagine Dragons TOP 10"));
        artists[1].AddAlbum(new Album("Alan Walkers Summer songs"));
        artists[2].AddAlbum(new Album("VALORANT Champions Tour"));
        artists[3].AddAlbum(new Album("Bemax's chill songs"));
        artists[4].AddAlbum(new Album("Five Nights At Freddy's 2023"));

        return artists;
    }
}
