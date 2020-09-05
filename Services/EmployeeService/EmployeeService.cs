using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using roadrunnerapi.Data;
using roadrunnerapi.Models;

namespace roadrunnerapi.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;

        public EmployeeService(DataContext context)
        {
            _context = context;
        }

        public void CreateEmployee(Employee employee)
        {
                if(employee == null)
                {
                        throw new ArgumentNullException(nameof(employee));
                }

            _context.Employees.Add(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            var x = await(_context.Employees.ToListAsync());
            return  x;
        }

        public Employee GetEmployeeByID(int id)
        {
            var x = _context.Employees.FirstOrDefault(obj=>obj.Id==id);
             return  x;
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges()>=0);
        }

        public void UpdateEployee(Employee employee)
        {
            //nothing
        }

              public async Task<EmployeeDocument> GetPhoto(int id)
        {
            var photo = await _context.EmployeeDocuments
                .FirstOrDefaultAsync(p => p.Id == id);

                   

                     return photo;
        }

        public void AddDocuments(EmployeeDocument doc)
        {
                         if(doc == null)
                {
                        throw new ArgumentNullException(nameof(doc));
                }

            _context.EmployeeDocuments.Add(doc);
        }

        public async Task<IEnumerable<EmployeeDocument>> GetAllDocuments(int empid)
        {
              var x  = await _context.EmployeeDocuments.Where(obj=>obj.EmployeeId==empid).ToListAsync();
             return x;
        }

        public EmployeeDocument GetMain(int empid)
        {
            var x  = _context.EmployeeDocuments
            .Where(obj=>obj.IsMain==true)
            .Where(obj=>obj.EmployeeId==empid).FirstOrDefault();
            
            
             return x;
        }

        public void SaveAttendance(Attendance atd)
        {
                 if(atd == null)
                {
                        throw new ArgumentNullException(nameof(atd));
                }

            _context.Attendances.Add(atd);
        }

        public void UpdateAttendance(Attendance atd)
        {
                         //nothing
        }

        public Attendance GetAttendanceByID(int id)
        {
            var x = _context.Attendances.FirstOrDefault(obj=>obj.Id==id);
             return  x;
        }
    }
}