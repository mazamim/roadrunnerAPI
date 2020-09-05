using System;

namespace roadrunnerapi.DTO.Employee
{
    public class UpdateAttendanceDTO
    {
        
         public DateTime PunchOut { get; set; } 

        public int EmployeeId { get; set; }
    }
}