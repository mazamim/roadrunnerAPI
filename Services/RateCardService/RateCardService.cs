using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using roadrunnerapi.Data;
using roadrunnerapi.Models;

namespace roadrunnerapi.Services.RateCardService
{
    public class RateCardService : IRateCardService
    {
        private readonly DataContext _context;

        public RateCardService(DataContext context)
        {
            _context = context;

        }

        public void CreatebulkRecord(List<RateCard> collection)
        {
              if(collection == null)
                {
                        throw new ArgumentNullException(nameof(collection));
                }
                foreach(var item in collection)
                
                {
                          _context.RateCards.Add(item);

                }
        }

        public async Task<IEnumerable<RateCard>> GetAllRateCard()
        {
                 var x = await(_context.RateCards.ToListAsync());
                 return  x;
        }

        public async Task<RateCard> GetRateCardByID(int id)
        {
             var x = await _context.RateCards.FirstOrDefaultAsync(obj=>obj.Id==id);
             return x;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public void UpdateRateCard(RateCard customer)
        {
              //nothing
        }
    }
}