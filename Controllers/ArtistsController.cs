using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Playlist_Demo.Models;

namespace Playlist_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {

        // private readonly MyContext _context;
        ArtistsRepository repo;

        public ArtistsController(MyContext con)
        {
            // _context = context;
            // Le constructeur de ArtistController contient desormais la repo artists avec la connexion du MyContext
            repo = new ArtistsRepository(con);
        }


        // GET: api/Musics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtistAsync()
        {
            return await repo.GetAllArtists();
        }

        // GET: api/Musics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await repo.GetArtistById(id);
            if (artist == null)
            {
                return NotFound();
            }
            return artist;
        }

        // PUT: api/Musics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist art)
        {
            var res = await repo.UpdateArtist(id,art);
            if (res == null)
                return NotFound();
            return NoContent();
        }

        // POST: api/Artists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Music>> PostArtist(Artist artist)
        {
            await repo.CreateArtist(artist);

            return CreatedAtAction("GetArtist", new { id = artist.Id }, artist);
        }
        // DELETE: api/Artists/5
        // DELETE: api/Musics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Artist>> DeleteArtist(int id)
        {
            var artist = await repo.RemoveArtist(id);
            if (artist == null)
            {
                return NotFound();
            }
            return artist;
        } 
    }
}
