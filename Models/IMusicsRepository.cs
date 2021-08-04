using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist_Demo.Models
{
    public interface IMusicsRepository : IDisposable
    {
        public IEnumerable<Music> GetAllMusics();

        // GET: api/Musics/5
        public Music GetMusic(int id);
    }
}
