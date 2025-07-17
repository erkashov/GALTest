using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GALTest.Models;
using GALTest.Services;

namespace GALTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OffersController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        // GET: api/Offers?search=search
        [HttpGet]
        public async Task<OfferSearchResult> GetOffers(string search)
        {
            return await _offerService.GetOffers(search);
        }

        // POST: api/Offers
        [HttpPost]
        public async Task<ActionResult<Offer>> PostOffer(Offer offer)
        {
            var result = await _offerService.PostOffer(offer);
            if(result == null)
            {
                return BadRequest("Оффер невалидный");
            }
            return result;
        }

        [HttpGet("topSuppliers")]
        public async Task<IEnumerable<TopSuppliersResult>> GetTopSuppliers()
        {
            return await _offerService.GetTopSuppliers();
        }
    }
}
