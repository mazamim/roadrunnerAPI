using System;
using System.Collections.Generic;
using roadrunnerapi.DTO.Employee;
using roadrunnerapi.Models;

namespace roadrunnerapi.DTO.Tickets
{
    public class ReadTicketDTO
    {
        public int Id  { get; set; }
       public string JobType { get; set; }
        public string Address { get; set; }
        public string Describtion { get; set; }
        public string Status { get; set; }
         public string Remarks { get; set; }
        public string CustomerName { get; set; }
      
        public string ClientName { get; set; }
          public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}