using System.Collections.Generic;

namespace AdoNetDemo
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public List<Track> Tracks { get; set; }

        public Album()
        {
            Tracks = new List<Track>();
        }
    }
}