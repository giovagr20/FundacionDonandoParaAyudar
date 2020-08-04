using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FundacionDonandoParaAyudar.Web.Models
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "Clave actual")]
        [Required(ErrorMessage = "El campo {0} es mandatorio.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} campo debe contener entre {2} y {1} caracteres.")]
        public string OldPassword { get; set; }

        [Display(Name = "Nueva clave")]
        [Required(ErrorMessage = "El campo {0} es mandatorio.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} campo debe contener entre {2} y {1} caracteres.")]
        public string NewPassword { get; set; }

        [Display(Name = "Confirmar clave")]
        [Required(ErrorMessage = "El campo {0} es mandatorio.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "El {0} campo debe contener entre {2} y {1} caracteres.")]
        [Compare("NewPassword")]
        public string Confirm { get; set; }

    } 
}
