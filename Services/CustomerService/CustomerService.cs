using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using roadrunnerapi.Data;
using roadrunnerapi.Models;

namespace roadrunnerapi.Services.CustomerService
{
    public class CustomerService : IcustomerService
    {
        private readonly DataContext _context;

           public CustomerService(DataContext context)
        {
            _context = context;
        }
        public void CreateCustomer(Customer customer)
        {
                    if(customer == null)
                {
                        throw new ArgumentNullException(nameof(customer));
                }

            _context.Customers.Add(customer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
                 var x = await(_context.Customers.ToListAsync());
            return  x;
        }

        public async Task<Customer> GetCustomerByID(int id)
        {
               var x = await _context.Customers.FirstOrDefaultAsync(obj=>obj.Id==id);
             return x;
        }

        public bool SaveChanges()
        {
                return (_context.SaveChanges()>=0);
        }

        public void UpdateCustomer(Customer customer)
        {
             //nothing
        }
    }
}