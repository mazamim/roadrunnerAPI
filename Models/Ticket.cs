using System;
using System.Collections.Generic;

namespace roadrunnerapi.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string JobType { get; set; }
        public string Address { get; set; }
        public string Describtion { get; set; }
        public string Status { get; set; }
         public string Remarks { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual Client Client { get; set; }
        public int ClientId { get; set; }

        public virtual ICollection<EmployeeTicket> EmployeeTicket { get; set; }
        public virtual ICollection<TicketDocumet> TicketDocument { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}