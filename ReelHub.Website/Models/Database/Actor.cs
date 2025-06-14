using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReelHub.Website.Models.Database
{
    [Table("Actors")]
    public class Actor
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First name")]
        public string? FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last name")]
        public string? LastName { get; set; }

        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "Full name")]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [DataType(DataType.Date)]
        public DateOnly Birthdate { get; set; }
        
        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }

        //  Lists...
        public List<MovieActor> Movies { get; set; } = new List<MovieActor>();
    }
}
