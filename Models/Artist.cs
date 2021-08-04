using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist_Demo.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Music> Musics { get; set; }

        public Artist()
        {

            Musics = new HashSet<Music>();
        }
    }
}
