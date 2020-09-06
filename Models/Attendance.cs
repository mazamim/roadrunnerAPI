using System;

namespace roadrunnerapi.Models
{
    public class Attendance
    {
        public int Id { get; set; }
         public DateTime PunchIn { get; set; } 
         public DateTime PunchOut { get; set; } 
        public virtual Employee Employee { get; set; }

        public int EmployeeId { get; set; }

        public bool IsPunch { get; set; }
        
    }
}