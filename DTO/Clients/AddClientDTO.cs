using System;

namespace roadrunnerapi.DTO.Clients
{
    public class AddClientDTO
    {     
        
        public string ClientName { get; set; }
        public string Mobile { get; set; }
        public string Emailadd { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

         public DateTime Updated { get; set; }
           public AddClientDTO()
        {
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }
    }
}