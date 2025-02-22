using Microsoft.EntityFrameworkCore;

namespace Mission6Assignment.Models;

public class FilmInfoContext : DbContext
{
    public FilmInfoContext(DbContextOptions<FilmInfoContext> options) : base(options) //constructor
    {
        
    }
    public DbSet<Movies> Movies { get; set; }  //a record (one row on the database)
    public DbSet<Categories> Categories { get; set; } //categories

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categories>().HasData();
    }
}