using ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MovieShopDbContext: DbContext
{
    public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Genres> Genres { get; set; }
    public DbSet<Casts> Casts { get; set; }
    public DbSet<Movies> Movies { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<MovieGenres> MovieGenres { get; set; }
    public DbSet<MovieCasts> MovieCasts { get; set; }
    public DbSet<Trailers> Trailers { get; set; }
    public DbSet<Favorites> Favorites { get; set; }
    public DbSet<Reviews> Reviews { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<Purchases> Purchases { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    
    // Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        /*****************************/
        /* Movies and Casts Relation */
        /*****************************/
        
        // Define the composite key for MovieCasts
        modelBuilder.Entity<MovieCasts>()
            .HasKey(mc => new { mc.MovieId, mc.CastId });

        // Define the relationship between Movies and MovieCasts
        modelBuilder.Entity<MovieCasts>()
            .HasOne(mc => mc.Movie)
            .WithMany(m => m.MovieCasts)
            .HasForeignKey(mc => mc.MovieId);

        // Define the relationship between Casts and MovieCasts
        modelBuilder.Entity<MovieCasts>()
            .HasOne(mc => mc.Cast)
            .WithMany(c => c.MovieCasts)
            .HasForeignKey(mc => mc.CastId);
        
        /*****************************/
        /* Movies and Genres Relation */
        /*****************************/
        
        // Define the composite key for MovieCasts
        modelBuilder.Entity<MovieGenres>()
            .HasKey(mc => new { mc.MovieId, mc.GenreId });

        // Define the relationship between Movies and MovieCasts
        modelBuilder.Entity<MovieGenres>()
            .HasOne(mc => mc.Movie)
            .WithMany(m => m.MovieGenres)
            .HasForeignKey(mc => mc.MovieId);

        // Define the relationship between Casts and MovieCasts
        modelBuilder.Entity<MovieGenres>()
            .HasOne(mc => mc.Genre)
            .WithMany(c => c.MovieGenres)
            .HasForeignKey(mc => mc.GenreId);
        
    }
}