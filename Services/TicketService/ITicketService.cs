using System.Collections.Generic;
using System.Threading.Tasks;
using roadrunnerapi.DTO.Tickets;
using roadrunnerapi.Models;

namespace roadrunnerapi.Services.TicketService
{
    public interface ITicketService
    {
        
        bool SaveChanges();
         Task<IEnumerable<Ticket>> GetAllTicket();

         Task<Ticket> GetSingleTicketbyID(int id);
        void CreatebulkRecord(List<Ticket> collection);
         void UpdateTicket(Ticket ticket);

          Task<IEnumerable<EmployeeTicket>> GetAllEmpTicket(int ticketID);
         
    }
}