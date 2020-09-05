using System;

namespace roadrunnerapi.DTO.Employee
{
    public class ReadAttendanceDTO
    {
             public int Id { get; set; }
         public DateTime PunchIn { get; set; } 
         public DateTime PunchOut { get; set; } 
         public int EmployeeId { get; set; } 
    }
}