using System;

namespace roadrunnerapi.Models
{
    public class EmployeeDocument
    {        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public bool IsApproved { get; set; }

        public virtual Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        
    }
}