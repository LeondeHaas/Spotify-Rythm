using System;
using System.Collections.Generic;

namespace Spotify
{
    public class Friend
    {
        // Properties
        public int FriendId { get; set; }
        public string Name { get; set; }

        // Constructor
        public Friend(int friendId, string name)
        {
            FriendId = friendId;
            Name = name;
        }

        // Method to get a list of friends
        public static List<Friend> GetFriends()
        {
            List<Friend> friends = new List<Friend>()
            {
                new Friend(1, "John"),
                new Friend(2, "Emily"),
                new Friend(3, "Michael"),
                new Friend(4, "Jessica"),
                new Friend(5, "David"),
                new Friend(6, "Sophia"),
                new Friend(7, "Daniel"),
                new Friend(8, "Olivia"),
                new Friend(9, "James"),
                new Friend(10, "Emma")
            };


            // when chosing a friend of whicj you'd like to see the playlist, you can see the songs that they have added to their playlist.
            // the user can then choose to play the songs in their playlist
            // the user can also remove the selected friend from their friend list
            // the user can also copy their playlist to their own playlist

            return friends;
        }
    }
}
