using System;

namespace roadrunnerapi.Models
{
    public class TicketDocumet
    {
           public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public bool IsApproved { get; set; }

        public virtual Ticket Ticket { get; set; }
        public int TicketId { get; set; }
    }
}