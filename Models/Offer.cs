namespace GALTest.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string Brand { get; set; } = default!;
        public string Model { get; set; } = default!;
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; } = default!;
        public DateTime RegisteredAt { get; set; }

        public bool IsValid()
        {
            return !String.IsNullOrWhiteSpace(Brand) && !String.IsNullOrWhiteSpace(Model);
        }
    }

}
