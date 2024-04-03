using System.ComponentModel.DataAnnotations;

namespace Levi9.Cinema.Api
{
    public class Movie
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public float Rating { get; set; }

        [Required]
        public string Cover { get; set; }

        public MovieStatus Status { get; set; }
    }

    public enum MovieStatus
    {
        Whishlist,
        Seen
    }
}
