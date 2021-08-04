using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist_Demo.Models
{
    public class MusicsRepository {
    private readonly MyContext _context;

    public MusicsRepository(MyContext con)
    {
            _context = con;
    }

    public async Task<ActionResult<IEnumerable<Music>>> GetAllMusics()
    {
        return await _context.Music.ToListAsync();
    }

    // GET: api/Musics/5
    public async Task<ActionResult<Music>> GetMusicById(int id)
    {
           return await _context.Music.FindAsync(id); 
    }

        // PUT: api/Musics/5
        public async Task<ActionResult<Music>> UpdateMusic(int id, Music mus)
        {
            /*if (id != artist.Id)
            {
                return null;
            }*/
            var Music = await _context.Music.FindAsync(id);
            if (Music == null)
                return null;

            Music.Title = mus.Title;
            Music.URL = mus.URL;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return Music;

        }


    // Post: api/Musics
    public async Task<ActionResult<Music>> CreateMusic(Music music)
    {
        _context.Music.Add(music);
        await _context.SaveChangesAsync();
        return null;
    }

    public async Task<ActionResult<Music>> RemoveMusic(int id)
    {
        var music = await _context.Music.FindAsync(id);
        if (music == null)
        {
            return null;
        }

        _context.Music.Remove(music);
        await _context.SaveChangesAsync();

        return music;
    }

    private bool MusicExists(int id)
    {
        return _context.Music.Any(e => e.Id == id);
    }

}

}
