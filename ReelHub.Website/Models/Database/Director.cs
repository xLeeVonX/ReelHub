using System.ComponentModel.DataAnnotations.Schema;

namespace ReelHub.Website.Models.Database
{
    [Table("Directors")]
    public class Director : Person
    {
        public List<MovieDirector> Movies { get; set; } = new List<MovieDirector>();
    }
}
