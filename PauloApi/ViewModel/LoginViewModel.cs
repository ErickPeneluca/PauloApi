using System.ComponentModel.DataAnnotations;

namespace PauloApi.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o apelido do usuario")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Informe a senha do usuario")] 
        public string Password { get; set; }
    }
}
