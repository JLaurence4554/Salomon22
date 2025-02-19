using System.ComponentModel.DataAnnotations.Schema;

namespace SalomonAPI.Model
{
    public class Rental
    {
        public int Id { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }
        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        public Movie Movies { get; set; }

        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public ICollection<RentalDetail> RentalDetails { get; set; }
    }
}
