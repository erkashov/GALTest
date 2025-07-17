using GALTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace GALTest.Services
{
    public class OffersDbService : IOfferService
    {
        private readonly AppDBContext _context;

        public OffersDbService(AppDBContext context)
        {
            _context = context;
        }
        public async Task<OfferSearchResult> GetOffers(string search)
        {
            var offerSearchResult = new OfferSearchResult();
            offerSearchResult.Offers = await _context.Offers.Include(p=>p.Supplier)
                                                            .Where(p => p.Brand.Contains(search)
                                                                || p.Model.Contains(search)
                                                                || p.Supplier.Name.Contains(search)).ToListAsync();
            return offerSearchResult;
        }

        public async Task<Offer> PostOffer(Offer offer)
        {
            if (offer == null || !offer.IsValid())
            {
                return null;
            }
            offer.RegisteredAt = DateTime.Now;
            _context.Offers.Add(offer);
            await _context.SaveChangesAsync();

            return offer;
        }

        public async Task<IEnumerable<TopSuppliersResult>> GetTopSuppliers()
        {
            return await _context.Offers
                                .GroupBy(p => p.SupplierId)
                                .Select(p => new TopSuppliersResult()
                                {
                                    Supplier = p.First().Supplier,
                                    Count = p.Count()
                                })
                                .OrderBy(p => p.Count)
                                .Take(3)
                                .ToListAsync();
        }
    }
}
