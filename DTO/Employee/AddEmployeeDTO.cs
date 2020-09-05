using System.ComponentModel.DataAnnotations;

namespace roadrunnerapi.DTO.Employee
{
    public class AddEmployeeDTO
    {
   
        [Required]
         public string EmployeeName { get; set; }

        [Required]
        public string Lastname { get; set; }
        public string Position { get; set; }
          
        [Required]
        public string Mobile { get; set; }
        public string Emailadd { get; set; }
        public string Description { get; set; }
    }
}