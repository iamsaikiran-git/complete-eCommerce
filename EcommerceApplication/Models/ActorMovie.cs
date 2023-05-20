using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApplication.Models
{
    public class ActorMovie
    {
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        [ForeignKey("ActorId")]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
