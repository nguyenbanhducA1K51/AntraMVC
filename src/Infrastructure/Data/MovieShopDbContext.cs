using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class MovieShopDbContext: DbContext
{
    public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options): base(options)
    {
        
    }
    
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movie { get; set; }
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<Cast> Cast { get; set; }
    public DbSet<MovieCast> MovieCast { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Movie>(entity =>
        // {
        //     entity.Property(e => e.Title).HasColumnType("varchar(20");
        //     entity.HasKey(e => e.Id);
        // });

        modelBuilder.Entity<Movie>(ConfigureMovie);
        modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
    }

    private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> modelBuilder)
    {
        modelBuilder.HasKey(x => new { x.MovieId, x.GenreId });
        modelBuilder.HasOne(x => x.Movie)
            .WithMany(x => x.MovieGenres)
            .HasForeignKey(x => x.MovieId);
        modelBuilder.HasOne(x => x.Genre)
            .WithMany(x => x.MovieGenres)
            .HasForeignKey(x => x.GenreId);
    }

  

    public void Configure(EntityTypeBuilder<MovieCast> modelBuilder)
    {
    modelBuilder.HasKey(x => new { x.MovieId, x.CastId });    
    modelBuilder.HasOne(x=>x.Movie)
        .WithMany(x=>x.MovieCasts)
        .HasForeignKey(x => x.MovieId);
    modelBuilder.HasOne(x => x.Cast)
        .WithMany(x => x.MovieCasts)
        .HasForeignKey(x => x.CastId);
    }
    public void ConfigureMovie(EntityTypeBuilder<Movie> builder)
    {
   
        builder.ToTable("Movies");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Title).HasColumnType("varchar(20)");
        builder.Property(m => m.Overview).HasColumnType("varchar(512)");
        builder.Property(m => m.Title).HasColumnType("varchar(500)");
        
        

    }
}