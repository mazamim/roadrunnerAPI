using System;
using System.Collections.Generic;

namespace roadrunnerapi.Models
{
    public class User
    {
         
         public int Id { get; set; }

        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

         public string Contact { get; set; }

        public string Address { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
       

    }
}