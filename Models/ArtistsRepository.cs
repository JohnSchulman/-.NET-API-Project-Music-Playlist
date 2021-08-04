using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist_Demo.Models
{
    public class ArtistsRepository
    {
        private readonly MyContext _context;

        public ArtistsRepository(MyContext con)
        {
            _context = con;
        }

        public async Task<ActionResult<IEnumerable<Artist>>> GetAllArtists()
        {
            return await _context.Artist.ToListAsync();
        }

        // GET: api/Musics/5
        public async Task<ActionResult<Artist>> GetArtistById(int id)
        {
            return await _context.Artist.FindAsync(id);
        }

        // PUT: api/Musics/5
        public async Task<ActionResult<Artist>> UpdateArtist(int id, Artist art)
        {
            /*if (id != artist.Id)
            {
                return null;
            }*/
            var artist = await _context.Artist.FindAsync(id);
            if (artist == null)
                return null;
            
             artist.Image = art.Image;
             artist.Name = art.Name;
           
                
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return artist;
            
        }


        public async Task<ActionResult<Artist>> CreateArtist(Artist artist)
        {
            _context.Artist.Add(artist);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<ActionResult<Artist>> RemoveArtist(int id)
        {
            var artist = await _context.Artist.FindAsync(id);
            if (artist == null)
            {
                return null;
            }

            _context.Artist.Remove(artist);
            await _context.SaveChangesAsync();

            return artist;
        }

        private bool ArtistExists(int id)
        {
            return _context.Artist.Any(e => e.Id == id);
        }

    }
}

