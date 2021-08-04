using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist_Demo.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
