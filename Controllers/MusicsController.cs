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
    public class MusicsController : ControllerBase
    {
        // private readonly MyContext _context;
        MusicsRepository repo;

        public MusicsController(MyContext con)
        {
            // _context = context;
            repo = new MusicsRepository(con);
        }

        // GET: api/Musics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Music>>> GetMusicAsync()
        {
            return await repo.GetAllMusics();
        }

        // GET: api/Musics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Music>> GetMusic(int id)
        {
            var music = await repo.GetMusicById(id);
            if (music == null)
            {
                return NotFound();
            }
            return music;
        }

        // PUT: api/Musics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Music>> PutMusic(int id, Music music)
        {
            var res = await repo.UpdateMusic(id, music);
            if (res == null)
                return NotFound();
            return res;
        }

        // POST: api/Musics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Music>> PostMusic(Music music)
        {
            await repo.CreateMusic(music);

            return CreatedAtAction("GetMusic", new { id = music.Id }, music);
        }

        // DELETE: api/Musics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Music>> DeleteMusic(int id)
        {
            var music = await repo.RemoveMusic(id);
            if (music == null)
            {
                return NotFound();
            }
            return music;
        }
    }
}
