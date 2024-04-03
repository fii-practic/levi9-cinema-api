using Levi9.Cinema.Api;
using Microsoft.EntityFrameworkCore;

public class PostgresDbContext : MoviesDbContext
{
    public PostgresDbContext(IConfiguration configuration)
        : base(configuration)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration["PostgreSqlConnection:ConnectionString"]);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
        .HasData(
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "The Avengers",
                Cover = "https://m.media-amazon.com/images/M/MV5BNDYxNjQyMjAtNTdiOS00NGYwLWFmNTAtNThmYjU5ZGI2YTI1XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_FMjpg_UX1000_.jpg",
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "The Avengers: Age of Ultron movie poster",
                Cover = "https://www.slashfilm.com/wp/wp-content/images/International-Avengers-Age-of-Ultron-Poster-700x989.jpg"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Spider-man: Home Coming",
                Cover = "https://media.vanityfair.com/photos/592592596736887ada186bcd/master/w_1600%2Cc_limit/spider-man-homecoming-SMH_DOM_Online_FNL_1SHT_3DRD3DIMX_AOJ_300dpi_01_rgb.jpg",
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Harry Potter and The Philosopher's Stone",
                Cover = "https://m.media-amazon.com/images/I/713KEd-8jyL._AC_SL1500_.jpg"
            },
            new Movie
            {
                Id = Guid.NewGuid(),
                Title = "Star Wars: The Last Jedi",
                Cover = "https://lumiere-a.akamaihd.net/v1/images/swtlj_imax_oversize_1-sht_v6_lg_d4edae12.jpeg?region=0%2C0%2C827%2C1200"
            }
        );
    }
}
