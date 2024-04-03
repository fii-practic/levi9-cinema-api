
namespace Levi9.Cinema.Api.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll(string? title = null, MovieStatus? status = null);
        Movie Get(Guid id);
        Task Add(Movie Movie);
        Task Update(Movie Movie);
        Task Delete(Guid id);
    }
}