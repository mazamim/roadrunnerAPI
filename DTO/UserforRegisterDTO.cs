using System;
using System.ComponentModel.DataAnnotations;

namespace roadrunnerapi.DTO
{
    public class UserforRegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters")]
        public string Password { get; set; }

              
        [Required]
        public string Address { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

        public string Contact { get; set; }

              public UserforRegisterDTO()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
    }
}