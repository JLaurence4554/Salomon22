using Microsoft.EntityFrameworkCore;

namespace SalomonAPI.Model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        [Precision(18,2)]
        public decimal Price { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }
}
