using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FundacionDonandoParaAyudar.Web.Data.Entities
{
    public class FoundationEntity
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 6, ErrorMessage = "El {0} campo debe tener {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es mandatorio.")]
        [Display(Name = "Comentarios")]
        public string Comments { get; set; }

        public UserEntity User { get; set; }
    }
}
