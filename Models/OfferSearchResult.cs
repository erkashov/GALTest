namespace GALTest.Models
{
    public class OfferSearchResult
    {
        public IEnumerable<Offer> Offers { get; set; } = new List<Offer>();
        public int Count => Offers?.Count() ?? 0;
    }
}
