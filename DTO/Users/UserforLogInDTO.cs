using System.ComponentModel.DataAnnotations;

namespace roadrunnerapi.DTO
{
    public class UserforLogInDTO
    {
           [Required]
        public string Username { get; set; }


       [Required]
       [StringLength(8, MinimumLength = 4 , ErrorMessage = "Minimum 8 ")]
        public string Password { get; set; }
    }
}