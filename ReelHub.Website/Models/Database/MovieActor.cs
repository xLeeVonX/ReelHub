using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReelHub.Website.Models.Database
{
    [Table("MovieActors")]
    public class MovieActor
    {
        [Key]
        [Required]
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; }

        [Key]
        [Required]
        public Guid ActorId { get; set; }
        public Actor? Actor { get; set; }
    }
}
