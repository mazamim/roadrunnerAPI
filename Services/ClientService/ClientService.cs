using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using roadrunnerapi.Data;
using roadrunnerapi.Models;

namespace roadrunnerapi.Services.ClientService
{
    public class ClientService : IClientService
    {
         private readonly DataContext _context;

           public ClientService(DataContext context)
        {
            _context = context;
        }
        public void CreateClient(Client client)
        {
                 if(client == null)
                {
                        throw new ArgumentNullException(nameof(client));
                }

            _context.Clients.Add(client);
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
        var x = await _context.Clients.ToListAsync();
        return x;
        }

        public async Task<Client> GetClientByID(int id)
        {
           return await _context.Clients.FirstOrDefaultAsync(obj=>obj.Id==id);
        }

        public bool SaveChanges()
        {
             return (_context.SaveChanges()>=0);
        }

        public void UpdateClient(Client client)
        {
            
             //nothing
        }
    }
}