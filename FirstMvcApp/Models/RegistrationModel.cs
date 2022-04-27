namespace FirstMvcApp.Models
{
    public class RegistrationModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }
    }
}
