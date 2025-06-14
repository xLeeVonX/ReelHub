﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReelHub.Website.Models.Database
{
    [Table("MovieActors")]
    public class MovieActor
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid MovieId { get; set; }

        [ValidateNever]
        public Movie Movie { get; set; } = null!;
        
        [Required]
        public Guid ActorId { get; set; }

        [ValidateNever]
        public Actor Actor { get; set; } = null!;

        [DataType(DataType.Text)]
        [Display(Name = "Character name")]
        public string? CharacterName { get; set; }
    }
}
