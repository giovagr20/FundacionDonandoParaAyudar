using System.ComponentModel.DataAnnotations;

namespace FundacionDonandoParaAyudar.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El campo usuario es mandatorio.")]
        [EmailAddress]
        public string Username { get; set; }

        [Required(ErrorMessage = "El campo clave es mandatorio.")]
        [MinLength(6)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
