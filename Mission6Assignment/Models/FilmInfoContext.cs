using Microsoft.EntityFrameworkCore;

namespace Mission6Assignment.Models;

public class FilmInfoContext : DbContext
{
    public FilmInfoContext(DbContextOptions<FilmInfoContext> options) : base(options) //constructor
    {
        
    }
    public DbSet<Movie> Movies { get; set; }  //a record (one row on the database)
}