using System;

namespace roadrunnerapi.DTO.Tickets
{
    public class ReturnallTicketDocumentsDTO
    {
        
          public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public bool IsApproved { get; set; }
       public int TicketId { get; set; }
    }
}