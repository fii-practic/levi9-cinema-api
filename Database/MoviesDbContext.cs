using Levi9.Cinema.Api;
using Microsoft.EntityFrameworkCore;

public class MoviesDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    protected MoviesDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public DbSet<Movie> Movies { get; set; }
}
