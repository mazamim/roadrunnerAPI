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
         void CreatebulkRecord(List<RateCard> collection);
                
         void UpdateRateCard(RateCard customer);

          void CreateRatetoaTicket(List<RateCardTicket> collection);

        Task <IEnumerable<RateCardTicket>>  Getratesbyticket(int tkt);

        void UpdateRatecardtoTicket(List<RateCardTicket> collection,int tktid);


    }
}