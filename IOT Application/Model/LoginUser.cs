using System.ComponentModel.DataAnnotations;

namespace IOT_Application.Model
{
    public class LoginUser
    {

        [Required]
        [Key]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
