using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Playlist_Demo.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Music> Music { get; set; }
      
        // faut mettre un paramètre générique <MyContext> comme j'ai généré un context d'authentficatio
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public MyContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}

