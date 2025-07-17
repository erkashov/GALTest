using GALTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace GALTest.Services
{
    public interface IOfferService
    {
        Task<OfferSearchResult> GetOffers(string search);
        Task<Offer> PostOffer(Offer offer);
        Task<IEnumerable<TopSuppliersResult>> GetTopSuppliers();
    }
}
