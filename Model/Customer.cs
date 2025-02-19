namespace SalomonAPI.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Rental> Rentals { get; set; }

    }
}
