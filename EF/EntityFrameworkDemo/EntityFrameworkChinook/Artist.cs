using System;
using System.Collections.Generic;

namespace EntityFrameworkChinook
{
    public partial class Artist
    {
        public Artist()
        {
            Album = new HashSet<Album>();
        }

        public int ArtistId { get; set; }
        public string Name { get; set; }
        public DateTime? Updated { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}
