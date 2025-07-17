namespace GALTest.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime CreatedAt { get; set; }

        public ICollection<Offer> Offers { get; set; } = new List<Offer>();
    }
}
