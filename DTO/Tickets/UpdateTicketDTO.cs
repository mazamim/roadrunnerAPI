using System;

namespace roadrunnerapi.DTO.Tickets
{
    public class UpdateTicketDTO
    {
       
       public string JobType { get; set; }
        public string Address { get; set; }
        public string Describtion { get; set; }
        public string Status { get; set; }
         public string Remarks { get; set; }
 
         public int CustomerId { get; set; }
      

           public int ClientId { get; set; }
          public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}