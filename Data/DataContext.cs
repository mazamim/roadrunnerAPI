using Microsoft.EntityFrameworkCore;
using roadrunnerapi.Models;

namespace roadrunnerapi.Data
{
    public class DataContext: DbContext
    {
    public DataContext(DbContextOptions<DataContext> options): base (options) {}

      
       public DbSet<User> Users { get; set; }
       public DbSet<Photo> Photos { get; set; }

        public DbSet<Employee> Employees{ get; set; }

        public DbSet<EmployeeDocument> EmployeeDocuments{ get; set; }

        public DbSet<Attendance> Attendances{ get; set; }
        public DbSet<Client> Clients{ get; set; }

        public DbSet<Customer> Customers{ get; set; }

        public DbSet<RateCard> RateCards{ get; set; }

        public DbSet<Ticket> Tickets{ get; set; }
        public DbSet<EmployeeTicket> EmployeeTickets{ get; set; }
     //    public DbSet<RateTicket> RateTickets{ get; set; }

          public DbSet<TicketDocumet> TicketDocumets{ get; set; }

        

    }

}
