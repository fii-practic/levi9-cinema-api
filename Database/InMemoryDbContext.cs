using Microsoft.EntityFrameworkCore;

public class InMemoryDbContext : MoviesDbContext
{
    public InMemoryDbContext(IConfiguration configuration)
        : base(configuration)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase(Configuration["InMemoryDbConnection:Name"]);
    }
}
