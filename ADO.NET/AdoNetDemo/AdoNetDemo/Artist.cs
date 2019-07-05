using System.Collections.Generic;

namespace AdoNetDemo
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }

        public List<Album> Albums { get; set; }

        public Artist()
        {
            Albums = new List<Album>();
        }

    }
}