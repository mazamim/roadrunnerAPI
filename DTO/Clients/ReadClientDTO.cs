using System;

namespace roadrunnerapi.DTO.Clients
{
    public class ReadClientDTO
    {
        
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string Mobile { get; set; }
        public string Emailadd { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

         public DateTime Updated { get; set; }
    }
}