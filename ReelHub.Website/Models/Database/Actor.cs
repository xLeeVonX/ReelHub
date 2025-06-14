using System.ComponentModel.DataAnnotations.Schema;

namespace ReelHub.Website.Models.Database
{
    [Table("Actors")]
    public class Actor : Person
    {
        public List<MovieActor> Movies { get; set; } = new List<MovieActor>();
    }
}
