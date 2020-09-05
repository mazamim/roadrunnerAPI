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

    }

}
