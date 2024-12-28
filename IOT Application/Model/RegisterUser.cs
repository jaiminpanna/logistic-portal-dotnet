using System.ComponentModel.DataAnnotations;

namespace IOT_Application.Model
{
    public class RegisterUser
    {
       
        public string Name { get; set; }

        public string Email { get; set; }

        [Required]
        [Key]
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
