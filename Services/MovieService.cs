namespace Levi9.Cinema.Api.Services
{
    public class MovieService : IMovieService
    {
        private readonly MoviesDbContext dbContext;
        private readonly IAwsS3Service s3Service;

        public MovieService(MoviesDbContext dbContext, IAwsS3Service s3Service)
        {
            this.dbContext = dbContext;
            this.s3Service = s3Service;
        }

        public IEnumerable<Movie> GetAll(string? title = null, MovieStatus? status = null)
        {
            var movies = dbContext.Movies.AsQueryable();

            if (title != null)
            {
                movies = movies.Where(x => x.Title.ToLower().Contains(title.ToLower()));
            }

            if (status != null)
            {
                movies = movies.Where(x => x.Status == status);
            }

            return movies;
        }

        public Movie Get(Guid id)
        {
            return dbContext.Movies.Single(m => m.Id == id);
        }

        public async Task Add(Movie movie)
        {
            movie.Id = Guid.NewGuid();
            movie.Cover = await s3Service.PutImageToS3(movie.Id.ToString(), movie.Cover);

            await dbContext.Movies.AddAsync(movie);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(Movie movie)
        {
            movie.Cover = await s3Service.PutImageToS3(movie.Id.ToString(), movie.Cover);
            dbContext.Movies.Update(movie);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var movie = Get(id);
            if (movie is null)
                return;

            dbContext.Movies.Remove(movie);
            await dbContext.SaveChangesAsync();
        }
    }
}
