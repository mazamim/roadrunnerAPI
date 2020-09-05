using System.Collections.Generic;
using roadrunnerapi.Models;

namespace roadrunnerapi.DTO.Employee
{
    public class UpdateEmployeeDTO
    {

        public string EmployeeName { get; set; }
        public string Lastname { get; set; }
        public string Position { get; set; }
        public string Mobile { get; set; }
        public string Emailadd { get; set; }
        public string Description { get; set; }
        public string Skills { get; set; }
        public string Address { get; set; }
        public string Salarytype { get; set; }
        public int Salary { get; set; }
        public string Payment_mode { get; set; }
        public string Bankdetails { get; set; }
        public string Status { get; set; }

        
    }
}