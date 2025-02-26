using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using mission6real_Smith.Models;

namespace mission6real_Smith.Models
{
    public class MovieEnterContext : DbContext
    {
        public MovieEnterContext(DbContextOptions<MovieEnterContext> options) : base (options)
        { 

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
