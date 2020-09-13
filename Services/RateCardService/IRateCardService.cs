using System.Collections.Generic;
using System.Threading.Tasks;
using roadrunnerapi.Models;

namespace roadrunnerapi.Services.RateCardService
{
    public interface IRateCardService
    {
         
        bool SaveChanges();
         Task<IEnumerable<RateCard>> GetAllRateCard();
        Task <RateCard> GetRateCardByID(int id);
         //void CreateCustomer(RateCard customer);
         void UpdateRateCard(RateCard customer);
    }
}