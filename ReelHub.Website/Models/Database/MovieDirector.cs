using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReelHub.Website.Models.Database
{
    [Table("MovieDirectors")]
    public class MovieDirector
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid MovieId { get; set; }

        [ValidateNever]
        public Movie Movie { get; set; } = null!;
        
        [Required]
        public Guid DirectorId { get; set; }

        [ValidateNever]
        public Director Director { get; set; } = null!;
    }
}
