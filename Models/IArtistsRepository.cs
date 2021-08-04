using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist_Demo.Models
{
    public interface IArtistsRepository : IDisposable
    {
        IEnumerable<Artist> GetAllArtists();
        Artist GetArtistById(int ArtistId);
        int AddEmployee(Artist artistEntity);
        int UpdateArtist(Artist artistEntity);
        void DeleteArtist(int ArtistId);

    }
}
