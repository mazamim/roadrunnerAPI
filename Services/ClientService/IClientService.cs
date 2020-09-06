using System.Collections.Generic;
using System.Threading.Tasks;
using roadrunnerapi.Models;

namespace roadrunnerapi.Services.ClientService
{
    public interface IClientService
    {
        bool SaveChanges();
         Task<IEnumerable<Client>> GetAllClients();
       Task <Client> GetClientByID(int id);
         void CreateClient(Client client);
         void UpdateClient(Client client);
    }
}