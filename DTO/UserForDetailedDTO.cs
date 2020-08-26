using System;

namespace roadrunnerapi.DTO
{
    public class UserForDetailedDTO
    {
          public int Id { get; set; }

        public string Username { get; set; }

        
        public string Address { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public string Contact { get; set; }

    
    }
}