using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReelHub.Website.Models.Database
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string? Title { get; set; }

        [Required]
        [Display(Name = "Release date")]
        [Range(1875, 2025)]
        public int ReleaseDate { get; set; }

        [Required]
        [Range(30, 300)]
        public int Length { get; set; }

        //  Lists...
        public List<MovieActor> Actors { get; set; } = new List<MovieActor>();
        public List<MovieDirector> Directors { get; set; } = new List<MovieDirector>();
    }
}
