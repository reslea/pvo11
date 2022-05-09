using System.ComponentModel.DataAnnotations;

namespace FirstMvcApp.Models
{
    public class LoginModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), MinLength(3)]
        public string Password { get; set; }
    }
}
