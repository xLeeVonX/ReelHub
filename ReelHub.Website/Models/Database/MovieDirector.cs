using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReelHub.Website.Models.Database
{
    [Table("MovieDirectors")]
    public class MovieDirector
    {
        [Key]
        [Required]
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
        
        [Required]
        public Guid DirectorId { get; set; }
        public Director Director { get; set; } = null!;
    }
}
