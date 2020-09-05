using System.Collections.Generic;
using System.Threading.Tasks;
using roadrunnerapi.Models;

namespace roadrunnerapi.Services.EmployeeService
{
    public interface IEmployeeService
    {
         bool SaveChanges();
         Task<IEnumerable<Employee>> GetAllEmployee();
         Employee GetEmployeeByID(int id);
         void CreateEmployee(Employee employee);
         void UpdateEployee(Employee employee);
        Task <EmployeeDocument> GetPhoto(int id);

        void AddDocuments(EmployeeDocument doc);

        Task<IEnumerable<EmployeeDocument>> GetAllDocuments(int empid);

          EmployeeDocument GetMain(int empid);

         void SaveAttendance(Attendance atd);
         void UpdateAttendance(Attendance atd);
         Attendance GetAttendanceByID(int id);
    }
}