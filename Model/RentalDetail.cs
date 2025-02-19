using System.ComponentModel.DataAnnotations.Schema;

namespace SalomonAPI.Model
{
    public class RentalDetail
    {
        public int Id { get; set; }
        [ForeignKey("RentalId")]
        public int RentalId { get; set; }
        public Rental Rentals { get; set; }
    }
}
