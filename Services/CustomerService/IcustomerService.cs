using System.Collections.Generic;
using System.Threading.Tasks;
using roadrunnerapi.Models;

namespace roadrunnerapi.Services.CustomerService
{
    public interface IcustomerService
    {
        bool SaveChanges();
         Task<IEnumerable<Customer>> GetAllCustomer();
        Task <Customer> GetCustomerByID(int id);
         void CreateCustomer(Customer customer);
         void UpdateCustomer(Customer customer);
    }
}