using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using roadrunnerapi.Data;
using roadrunnerapi.DTO.Tickets;
using roadrunnerapi.Models;

namespace roadrunnerapi.Services.TicketService
{
    public class TicketService : ITicketService
    {

            private readonly DataContext _context;
           public TicketService(DataContext context)
        {
            _context = context;

        }

        public void AddDocuments(TicketDocumet doc)
        {
            throw new NotImplementedException();
        }

        public void CreatebulkRecord(List<Ticket> collection)
         {
                  if(collection == null)
                {
                        throw new ArgumentNullException(nameof(collection));
                }
                foreach(var item in collection)
                
                {
                          _context.Tickets.Add(item);

                }

            }

        public async Task<IEnumerable<EmployeeTicket>> GetAllEmpTicket(int ticketID)
        {


        var x  = await _context.EmployeeTickets
                .Where(obj=>obj.TicketId==ticketID).ToListAsync();
            
            return x;
        
         }

        public async Task<IEnumerable<Ticket>> GetAllTicket()
        {
             var x =await _context.Tickets
                .Where(obj=>obj.Status=="Assigned").ToListAsync();
                 return  x;
        }

        public async Task<IEnumerable<TicketDocumet>> GetAllTicketDocuments(int tktID)
        {
                var x  = await _context.TicketDocumets.Where(obj=>obj.TicketId==tktID).ToListAsync();
             return x;
        }

        public async Task<Ticket> GetSingleTicketbyID(int id)
        {
           var x= await _context.Tickets.FirstOrDefaultAsync(obj=>obj.Id==id);

            return x;
        }

        public bool SaveChanges()
        {
             return (_context.SaveChanges()>=0);
        }

        public void UpdateTicket(Ticket ticket)
        {
        //nothing
        }
    }
}