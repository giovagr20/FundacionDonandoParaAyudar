﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FundacionDonandoParaAyudar.Web.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}